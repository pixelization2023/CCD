using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core;
using CCDInspection.Core.Enums;
using CCDInspection.Core.Interfaces;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core.Interfaces.Services;
using CCDInspection.Core.Models;
using CCDInspection.Device.IO;
using IVisionProcessor = CCDInspection.Core.Interfaces.Hardware.IVisionAnalyzer;
using IAlarmHandler = CCDInspection.Core.Interfaces.Services.IAlarmHandler;
using IInspectionStation = CCDInspection.Core.Interfaces.Services.IInspectionStation;

namespace CCDInspection.Services
{
    /// <summary>
    /// 工位控制器 — 双层状态机驱动自动检测流程
    /// ==============================================
    ///
    /// 【运行说明】
    ///
    /// 1. 开机 → 红灯，软件已连接ZMC/轴已使能，但未复位
    /// 2. 按 IN3 或点"清除报警" → 黄灯(复位中) → 回零完成 → 绿灯(就绪)
    /// 3. 点"启动自动测试" → 绿灯(运行中) → 状态机进入 WaitStart
    /// 4. 同时按下 IN6(左启动)+IN7(右启动) → 执行一次检测流程
    /// 5. 每轮完成后必须松开双手再按，才能触发下一轮（安全规范）
    ///
    /// 【检测流程（10步，VM内置拍照）】
    ///   S1 WaitStart(IN7) → S2 CylinderRetract → S3 LightOn+ZAxisMove+Vision(Run拍照+检测)+Save+LightOff+ZAxisReturn
    ///   → S4 CylinderExtend → S5 Completed → 等IN7松开 → 下一轮 S1
    ///
    /// 【安全机制】
    ///   - 光栅遮挡(IN0) → 立即报警，停止所有动作
    ///   - 急停(IN2) → 硬件急停 + 报警
    ///   - 限位触发 → 停止轴 + 报警，反向点动退出
    ///   - 报警后必须人工复位(IN3或软件按钮)才能继续
    ///   - 报警→复位：气缸缩回 + Z轴回零 → 回到就绪
    ///
    /// 【屏蔽功能（界面复选框，即时生效无需重启）】
    ///   屏蔽相机    = 跳过拍照，用虚拟图像
    ///   屏蔽蜂鸣器  = 报警时蜂鸣器不响
    ///   屏蔽光栅    = 遮挡不触发报警
    ///   气缸屏蔽    = 跳过气缸传感器检测
    ///
    /// 【三层架构】
    ///   顶层状态机 (StationState) = 控制运行模式：Idle / AutoRun / Paused / Alarm / Resetting
    ///   流程状态机 (InspectionFlowState) = 控制检测步骤序列
    ///   抽象设备接口 = IAxis / ICamera / ICylinder / ILightCurtain / IAlarmHandler
    /// </summary>
    public class StationController : IInspectionStation
    {
        // ================================================================
        // 设备接口（硬件抽象，仿真/真实硬件一键切换）
        // ================================================================
        private readonly IMotionController _motion;   // ZMC 运动控制器
        private readonly IVisionProcessor _vision;    // VisionMaster 视觉处理器（自带相机触发）
        private readonly ICylinder _cylinder;         // 气缸
        private readonly IAlarmHandler _alarm;        // 报警处理器
        private readonly ILightCurtain _lightCurtain; // 安全光栅
        private readonly StatisticsService _stats;    // 生产统计
        private readonly AppConfig _config;           // 应用配置（轴参数/相机/检测设置）
        private readonly IConfigService _configService; // JSON配置读写（运行时读最新屏蔽设置）

        // ================================================================
        // 双层状态机
        // ================================================================
        /// <summary>顶层状态机 — 控制运行模式</summary>
        private readonly StateMachine<StationState> _topSM;
        /// <summary>流程状态机 — 控制检测步骤序列</summary>
        private readonly StateMachine<InspectionFlowState> _flowSM;

        // ================================================================
        // 运行时状态
        // ================================================================
        /// <summary>停止标志，为true时AutoRun循环和流程handler会退出</summary>
        private volatile bool _stopRequested;
        /// <summary>当前检测的产品配置（Z轴高度、视觉方案路径等）</summary>
        private ProductConfig _currentProduct;
        /// <summary>用于取消等待中的异步操作</summary>
        private CancellationTokenSource _cycleCts;

        // ================================================================
        // 信号量（替代传统死循环轮询，减少CPU占用）
        // ================================================================
        /// <summary>Idle状态退出信号 — StartAsync/StopAsync 唤醒</summary>
        private TaskCompletionSource<bool> _idleSignal;
        /// <summary>Paused状态退出信号 — 恢复或停止时唤醒</summary>
        private TaskCompletionSource<bool> _pausedSignal;
        /// <summary>Alarm状态退出信号</summary>
        private TaskCompletionSource<bool> _alarmSignal;

        /// <summary>最近一次检测记录</summary>
        public InspectionRecord LastRecord { get; private set; }
        /// <summary>当前工位顶层状态</summary>
        public StationState CurrentState => _topSM.CurrentState;

        // ================================================================
        // 外部事件（UI订阅）
        // ================================================================
        /// <summary>单次检测完成事件</summary>
        public event Action<InspectionRecord> OnInspectionCompleted;
        /// <summary>状态变更事件（"复位中"/"复位完成"/"自动运行"等）</summary>
        public event Action<string> OnStatusChanged;
        /// <summary>报警事件（报警码, 报警消息）</summary>
        public event Action<string, string> OnAlarm;

        // ================================================================
        // 运行时读取最新屏蔽配置 — 每次访问都从JSON文件读取
        // 界面勾选 → SaveOptionalConfig()写JSON → 此处读取 → 毫秒级生效
        // ================================================================
        private FeaturesConfig Features => _configService.Load()?.Features ?? _config.Features;

        /// <summary>
        /// 构造函数 — 注入所有设备接口和配置
        /// </summary>
        public StationController(IMotionController motion, IVisionProcessor vision,
            ICylinder cylinder, IAlarmHandler alarm, ILightCurtain lightCurtain, StatisticsService stats,
            AppConfig config, IConfigService configService)
        {
            _motion = motion;
            _vision = vision;
            _cylinder = cylinder;
            _alarm = alarm;
            _lightCurtain = lightCurtain;
            _stats = stats;
            _config = config;
            _configService = configService;

            // 始终订阅光栅事件，运行时根据屏蔽配置决定是否报警（支持界面动态切换）
            _lightCurtain.OnBlocked += () =>
            {
                if (Features.ShieldLightCurtain)
                {
                    LogService.Information("[诊断-光栅] 光栅遮挡(已屏蔽，不报警)");
                    return;
                }
                if (_motion?.IsConnected != true)
                {
                    LogService.Warning("[诊断-光栅] 忽略遮挡事件(设备已断开)");
                    return;
                }
                _ = TriggerAlarmAsync("LIGHT_CURTAIN", "安全光栅被遮挡");
            };

            // 初始化信号量
            _idleSignal = new TaskCompletionSource<bool>();
            _pausedSignal = new TaskCompletionSource<bool>();
            _alarmSignal = new TaskCompletionSource<bool>();

            // 创建双层状态机
            _topSM = new StateMachine<StationState>(StationState.Idle);
            _flowSM = new StateMachine<InspectionFlowState>(InspectionFlowState.Completed); // ≠Init，保证第一次 TransitionToAsync(Init) 执行

            // 诊断：记录所有状态切换
            _topSM.OnStateChanged += (old, cur) =>
                LogService.Information("[诊断-状态机] 顶层 {Old} → {New}", old, cur);
            _flowSM.OnStateChanged += (old, cur) =>
                LogService.Information("[诊断-状态机] 流程 {Old} → {New}", old, cur);

            // 注册所有状态的处理函数
            RegisterStates();
        }

        /// <summary>启动 IdleHandler 后台轮询 — 由 FrmMain 在窗口就绪后调用</summary>
        public void StartIdlePolling() => _ = Task.Run(IdleHandler);

        /// <summary>注册两层状态机的所有状态处理函数</summary>
        private void RegisterStates()
        {
            // —— 顶层状态（5个） ——
            _topSM.Register(StationState.Idle, IdleHandler);
            _topSM.Register(StationState.Paused, PausedHandler);
            _topSM.Register(StationState.AutoRun, AutoRunHandler);
            _topSM.Register(StationState.Alarm, AlarmHandler);
            _topSM.Register(StationState.Resetting, ResettingHandler);

            // —— 流程状态（12步） ——
            _flowSM.Register(InspectionFlowState.Init, InitFlowHandler);
            _flowSM.Register(InspectionFlowState.WaitStart, WaitStartHandler);
            _flowSM.Register(InspectionFlowState.CylinderRetract, CylinderRetractHandler);
            _flowSM.Register(InspectionFlowState.LightOn, LightOnHandler);
            _flowSM.Register(InspectionFlowState.ZAxisMove, ZAxisMoveHandler);
            _flowSM.Register(InspectionFlowState.VisionProcess, VisionProcessHandler);
            _flowSM.Register(InspectionFlowState.SaveResult, SaveResultHandler);
            _flowSM.Register(InspectionFlowState.LightOff, LightOffHandler);
            _flowSM.Register(InspectionFlowState.ZAxisReturn, ZAxisReturnHandler);
            _flowSM.Register(InspectionFlowState.CylinderExtend, CylinderExtendHandler);
            _flowSM.Register(InspectionFlowState.Completed, CompletedHandler);
        }

        // ================================================================
        // 顶层状态处理器
        // ================================================================

        /// <summary>
        /// Idle（空闲）— 等待启动信号或硬件按钮
        ///   出口1: StartAsync 调用 → 去 AutoRun（软件启动按钮或IN1硬件启动按钮）
        ///   出口2: 检测到 IN1 按下 → 去 AutoRun（物理启动按钮）
        ///   出口3: 检测到 IN3 按下 → 去 Resetting（物理复位按钮）
        /// </summary>
        private async Task IdleHandler()
        {
            LogService.Information("[状态机] 进入 Idle 空闲状态");
            while (_topSM.CurrentState.Equals(StationState.Idle) && !_stopRequested)
            {
                var completed = await Task.WhenAny(_idleSignal.Task, Task.Delay(100));

                if (_idleSignal.Task.IsCompleted)
                {
                    _idleSignal = new TaskCompletionSource<bool>();
                    return; // StartAsync 唤醒 → 外部会切到 AutoRun
                }

                // 硬件启动按钮 IN1 — 等同于界面点"启动自动测试"
                if (_motion.ReadInput(IOMapping.IN_MachineStart))
                {
                    await Task.Delay(50);
                    if (_motion.ReadInput(IOMapping.IN_MachineStart))
                    {
                        LogService.Information("[状态机] Idle状态下检测到IN1，启动自动运行");
                        _idleSignal = new TaskCompletionSource<bool>();
                        await _topSM.TransitionToAsync(StationState.AutoRun);
                        return;
                    }
                }

                // 硬件复位按钮 IN3 — 回零
                if (_motion.ReadInput(IOMapping.IN_Reset))
                {
                    await Task.Delay(50);
                    if (_motion.ReadInput(IOMapping.IN_Reset))
                    {
                        LogService.Information("[状态机] Idle状态下检测到IN3，触发复位");
                        _idleSignal = new TaskCompletionSource<bool>();
                        await _topSM.TransitionToAsync(StationState.Resetting);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Paused（暂停）— 等待恢复或停止
        ///   出口1: 恢复信号 → 去 AutoRun
        ///   出口2: _stopRequested → 外部切到 Idle
        /// </summary>
        private async Task PausedHandler()
        {
            LogService.Warning("[状态机] 进入 Paused 暂停状态");
            ReportStatus("已暂停");
            await _pausedSignal.Task;
            _pausedSignal = new TaskCompletionSource<bool>();

            if (!_stopRequested)
                await _topSM.TransitionToAsync(StationState.AutoRun);
        }

        /// <summary>
        /// AutoRun（自动运行）— 循环执行检测流程
        ///   while循环每轮: WaitStart → ... → Completed
        ///   每轮结束后等双手松开（安全规范），避免一直导通导致死循环
        /// </summary>
        private async Task AutoRunHandler()
        {
            ReportStatus("自动运行");
            LogService.Information("[诊断] AutoRunHandler 进入 | Motion={M} ZAxis={Z}",
                _motion?.IsConnected, _motion?.ZAxis != null ? "OK" : "NULL");

            while (!_stopRequested && _topSM.CurrentState.Equals(StationState.AutoRun))
            {
                await _flowSM.TransitionToAsync(InspectionFlowState.Init);

                // 等 IN7(流程启动) 松开才能进下一轮，同时检测 IN8
                while (_motion.ReadInput(IOMapping.IN_FlowStart))
                {
                    if (CheckStop()) return;
                    if (_stopRequested || !_topSM.CurrentState.Equals(StationState.AutoRun)) break;
                    await Task.Delay(50);
                }
                if (CheckStop()) return;
            }
            LogService.Information("[诊断] AutoRunHandler 退出 | stopReq={S} curState={C}",
                _stopRequested, _topSM.CurrentState);
        }

        /// <summary>
        /// Alarm（报警）— 停轴，等待人工复位
        ///   清除方式1: IN3 硬件复位按钮
        ///   清除方式2: 软件 ResetAsync() → ClearAlarm
        ///   清除后自动进入 Resetting
        /// </summary>
        private bool _skipReset; // ClearAlarmOnly时跳过回零
        private async Task AlarmHandler()
        {
            LogService.Error("[状态机] 进入 Alarm 报警状态");
            _motion.ZAxis?.Stop();
            ReportStatus("报警中...等待复位(IN3或软件复位)");
            _skipReset = false;

            while (_alarm.IsAlarming && !_stopRequested)
            {
                if (_motion.ReadInput(IOMapping.IN_Reset))
                {
                    LogService.Information("[状态机] 检测到IN3复位信号，清除报警");
                    _alarm.ClearAlarm();
                    break;
                }
                await Task.Delay(100);
            }
            if (_alarm.IsAlarming)
            {
                LogService.Information("[状态机] 强制清除报警(停止请求)");
                _alarm.ClearAlarm();
            }

            if (_skipReset)
            {
                LogService.Information("[状态机] 报警已清除(软件)，跳过回零 → Idle");
                await _topSM.TransitionToAsync(StationState.Idle);
            }
            else
            {
                LogService.Information("[状态机] 报警已清除，进入 Resetting");
                await _topSM.TransitionToAsync(StationState.Resetting);
            }
        }

        /// <summary>
        /// Resetting（复位）— 气缸缩回 + Z轴回零
        ///   完成后自动进入 Idle
        /// </summary>
        private async Task ResettingHandler()
        {
            LogService.Information("[状态机] 进入 Resetting 复位状态");
            ReportStatus("复位中...");

            // 气缸伸出到初始状态 S0（屏蔽时跳过）
            if (Features.ShieldCylinder)
            {
                LogService.Information("[复位] 气缸已屏蔽，跳过伸出");
            }
            else
            {
                LogService.Information("[复位] 气缸伸出中... ShieldCylinder={S}", Features.ShieldCylinder);
                bool extendOk = await _cylinder.ExtendAsync(_config.Inspection.CylinderTimeoutMs);
                LogService.Information("[复位] 气缸伸出结果={R} IsExtended={E}", extendOk, _cylinder.IsExtended);
            }

            // Z轴回零
            if (_motion.ZAxis != null)
            {
                LogService.Information("[状态机] 回零中...");
                await _motion.ZAxis.Home(_config.Axis);
                // 回零后移动到配方检测高度（读最新JSON，支持界面切换方案后生效）
                float recipeZ = _configService.Load()?.Inspection?.DetectZHeight ?? _config.Inspection.DetectZHeight;
                if (recipeZ != 0)
                {
                    LogService.Information("[复位] Z轴→配方高度 {Z:F1}mm", recipeZ);
                    await _motion.ZAxis.MoveAbs(recipeZ);
                }
            }

            LogService.Information("[状态机] 复位完成 → Idle");
            ReportStatus("复位完成");
            await _topSM.TransitionToAsync(StationState.Idle);
        }

        // ================================================================
        // 流程状态处理器（S0→S5，按新IO规范）
        // S1 WaitStart → S2 CylinderRetract → S3 LightOn/ZAxis/Camera/Vision/Save/LightOff/ZAxisReturn → S4 CylinderExtend → S5 Completed
        // ================================================================

        /// <summary>S0→S1：初始化 → 等待启动</summary>
        private async Task InitFlowHandler() => await SafeFlowNext(InspectionFlowState.WaitStart);

        /// <summary>S1：等待流程启动 — IN7 上升沿</summary>
        private async Task WaitStartHandler()
        {
            ReportStatus("按IN7流程启动");
            LogService.Information("[诊断] WaitStart 等待IN7流程启动");
            while (!_motion.ReadInput(IOMapping.IN_FlowStart))
            {
                if (_stopRequested || CheckStop()) return;
                await Task.Delay(30);
            }
            await Task.Delay(100);
            if (!_motion.ReadInput(IOMapping.IN_FlowStart))
                return;
            await SafeFlowNext(InspectionFlowState.CylinderRetract);
        }

        /// <summary>S2：气缸缩回 — ot0=1，等待 IN5</summary>
        private async Task CylinderRetractHandler()
        {
            if (Features.ShieldCylinder)
            {
                ReportStatus("气缸已屏蔽，跳过缩回检测");
                await SafeFlowNext(InspectionFlowState.LightOn);
                return;
            }
            if (!await _cylinder.RetractAsync(_config.Inspection.CylinderTimeoutMs))
            {
                _alarm.RaiseAlarm("CYL", "气缸缩回失败");
                await _topSM.TransitionToAsync(StationState.Alarm);
                return;
            }
            await SafeFlowNext(InspectionFlowState.LightOn);
        }

        /// <summary>S3：光源开启 — OUT2通电</summary>
        private async Task LightOnHandler()
        {
            _motion.WriteOutput(IOMapping.OUT_Light, true);
            _motion.WriteOutput(IOMapping.OUT_Light2, true);
            await Task.Delay(_config.Inspection.LightOnDelayMs);
            await SafeFlowNext(InspectionFlowState.ZAxisMove);
        }

        /// <summary>S3：Z轴移动到检测高度</summary>
        private async Task ZAxisMoveHandler()
        {
            float z = _currentProduct?.ZHeight ?? 0;
            ReportStatus($"Z轴→{z}mm");
            if (_motion.ZAxis == null || !await _motion.ZAxis.MoveAbs(z))
            {
                _alarm.RaiseAlarm("Z", "Z轴失败");
                await _topSM.TransitionToAsync(StationState.Alarm);
                return;
            }
            await SafeFlowNext(InspectionFlowState.VisionProcess);
        }

        /// <summary>S3：VM视觉处理 — 调Run触发拍照检测，读Outputs解析结果</summary>
        private async Task VisionProcessHandler()
        {
            if (!_vision.IsLoaded)
            {
                ReportStatus("VM未加载，跳过视觉处理→OK");
                LastRecord = NewRecord("OK", "");
                await SafeFlowNext(InspectionFlowState.SaveResult);
                return;
            }
            try
            {
                bool ok; string reason;
                _vision.Run(null, out ok, out reason);
                LastRecord = NewRecord(ok ? "OK" : "NG", reason);
            }
            catch (Exception ex)
            {
                LogService.Error(ex, "VM流程运行异常");
                LastRecord = NewRecord("NG", ex.Message);
            }
            await SafeFlowNext(InspectionFlowState.SaveResult);
        }

        /// <summary>S3：保存结果</summary>
        private async Task SaveResultHandler()
        {
            if (LastRecord.Result == "OK") _stats.RecordOK();
            else _stats.RecordNG(LastRecord.NgReason);
            OnInspectionCompleted?.Invoke(LastRecord);
            await SafeFlowNext(InspectionFlowState.LightOff);
        }

        /// <summary>S3：光源关闭</summary>
        private async Task LightOffHandler()
        {
            _motion.WriteOutput(IOMapping.OUT_Light, false);
            _motion.WriteOutput(IOMapping.OUT_Light2, false);
            await SafeFlowNext(InspectionFlowState.ZAxisReturn);
        }

        /// <summary>S3：Z轴回零</summary>
        private async Task ZAxisReturnHandler()
        {
            if (_motion.ZAxis != null)
                await _motion.ZAxis.MoveAbs(0);
            await SafeFlowNext(InspectionFlowState.CylinderExtend);
        }

        /// <summary>S4：气缸伸出 — ot0=0，等待 IN4</summary>
        private async Task CylinderExtendHandler()
        {
            if (Features.ShieldCylinder)
            {
                ReportStatus("气缸已屏蔽，跳过伸出检测");
                await SafeFlowNext(InspectionFlowState.Completed);
                return;
            }
            if (!await _cylinder.ExtendAsync(_config.Inspection.CylinderTimeoutMs))
            {
                _alarm.RaiseAlarm("CYL", "气缸伸出失败");
                await _topSM.TransitionToAsync(StationState.Alarm);
                return;
            }
            await SafeFlowNext(InspectionFlowState.Completed);
        }

        /// <summary>S5：完成 → 等IN6松开 → 回S1</summary>
        private async Task CompletedHandler()
        {
            ReportStatus(LastRecord?.Result == "OK" ? "OK" : $"NG:{LastRecord?.NgReason}");
        }

        // ================================================================
        // 辅助方法
        // ================================================================

        /// <summary>
        /// 安全流转到流程状态机的下一个状态
        /// 只有顶层状态为 AutoRun 时才允许，防止报警/暂停时流程乱跑
        /// </summary>
        /// <summary>IN8停止按钮检测，返回true表示已触发停止</summary>
        private bool CheckStop()
        {
            if (_motion.ReadInput(IOMapping.IN_Stop))
            {
                LogService.Warning("[状态机] IN8停止按钮按下");
                _ = TriggerAlarmAsync("STOP", "停止按钮按下");
                return true;
            }
            return false;
        }

        private async Task SafeFlowNext(InspectionFlowState next)
        {
            if (CheckStop()) return;
            if (_topSM.CurrentState.Equals(StationState.AutoRun))
            {
                await _flowSM.TransitionToAsync(next);
            }
            else
            {
                LogService.Warning("[诊断-状态机] SafeFlowNext 阻止 | 顶层状态={S}≠AutoRun 跳过→{N}",
                    _topSM.CurrentState, next);
            }
        }

        // ================================================================
        // IInspectionStation 接口实现 — 外部控制入口
        // ================================================================

        /// <summary>启动自动运行 — 加载产品方案 → 唤醒Idle → 切到AutoRun</summary>
        public async Task StartAsync(ProductConfig product, CancellationToken ct = default)
        {
            LogService.Information("[诊断-状态机] StartAsync 调用 | 当前状态={S}", _topSM.CurrentState);
            // Alarm 状态禁止直接启动，必须先复位
            if (_topSM.CurrentState.Equals(StationState.Alarm))
            {
                LogService.Warning("[诊断-状态机] StartAsync 被阻止: 当前处于Alarm状态，请先复位");
                return;
            }
            _currentProduct = product;
            _stopRequested = false;
            _cycleCts = new CancellationTokenSource();

            // 方案已在 FrmLogin 加载，只有路径不同时才重新加载
            if (!string.IsNullOrEmpty(product?.SolPath) && !_vision.IsLoaded)
                _vision.LoadSolution(product.SolPath);

            ct.Register(() => _cycleCts?.Cancel());

            LogService.Information("[诊断-状态机] 唤醒 Idle TCS");
            _idleSignal?.TrySetResult(true);

            await _topSM.TransitionToAsync(StationState.AutoRun);
            LogService.Information("[诊断-状态机] StartAsync 完成 | 当前状态={S}", _topSM.CurrentState);
        }

        /// <summary>停止 — 设停止标志 → 唤醒所有信号 → 切回Idle</summary>
        public async Task StopAsync()
        {
            LogService.Information("[诊断-状态机] StopAsync 调用 | 当前状态={S}", _topSM.CurrentState);
            _stopRequested = true;
            _cycleCts?.Cancel();
            _cycleCts?.Dispose();
            _cycleCts = null;

            // 唤醒所有可能正在阻塞的Handler
            _idleSignal?.TrySetResult(true);
            _pausedSignal?.TrySetResult(true);
            _alarmSignal?.TrySetResult(true);

            await _topSM.TransitionToAsync(StationState.Idle);
            LogService.Information("[诊断-状态机] StopAsync 完成 | 当前状态={S}", _topSM.CurrentState);
        }

        /// <summary>软件复位 — 清除报警 → 去Resetting</summary>
        /// <summary>仅清除报警，不回零 — 软件"清除报警"按钮专用</summary>
        public void ClearAlarmOnly()
        {
            _skipReset = true;
            _alarm.ClearAlarm();
            _alarmSignal?.TrySetResult(true);
            LogService.Information("[诊断-状态机] ClearAlarmOnly 仅清报警，不回零");
        }

        public async Task ResetAsync()
        {
            LogService.Information("[诊断-状态机] ResetAsync 调用 | 当前状态={S} IsAlarming={A}",
                _topSM.CurrentState, _alarm.IsAlarming);
            _alarm.ClearAlarm();
            _alarmSignal?.TrySetResult(true);
            await _topSM.TransitionToAsync(StationState.Resetting);
            LogService.Information("[诊断-状态机] ResetAsync 完成 | 当前状态={S}", _topSM.CurrentState);
        }

        /// <summary>触发报警 — 任何异常统一入口，切到Alarm状态</summary>
        public async Task TriggerAlarmAsync(string code, string msg)
        {
            LogService.Error("[诊断-状态机] TriggerAlarmAsync | Code={C} Msg={M} 当前状态={S}",
                code, msg, _topSM.CurrentState);
            _alarm.RaiseAlarm(code, msg);
            OnAlarm?.Invoke(code, msg);
            await _topSM.TransitionToAsync(StationState.Alarm);
        }

        /// <summary>创建检测记录</summary>
        private InspectionRecord NewRecord(string r, string reason) => new InspectionRecord
        {
            Time = DateTime.Now,
            ProductIndex = _currentProduct?.Index ?? "?",
            Result = r,
            NgReason = reason
        };

        /// <summary>报告状态变更（UI订阅显示）</summary>
        private void ReportStatus(string msg) => OnStatusChanged?.Invoke(msg);
    }
}
