using Application_Common;
using Application_UI;
using KSTOPA_Task;
using Newtonsoft.Json;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM.Core;
using CCDInspection.Core.Enums;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core.Models;
using CCDInspection.Services;
using CCDInspection.Device.Motion;
using CCDInspection.Device.IO;
using CCDInspection.UI.Assisat;
using CCDInspection.Device.Vision;
using CCDInspection.Core;
using FreeSql;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using NpoiAlign = NPOI.SS.UserModel.HorizontalAlignment;
using NpoiBorder = NPOI.SS.UserModel.BorderStyle;

using IVisionProcessor = CCDInspection.Core.Interfaces.Hardware.IVisionAnalyzer;
using VMControls.Winform.Release.ExportControl;
using Sunny.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CCDInspection.UI.Forms
{
    public partial class FrmMain : Sunny.UI.UIForm
    {
        /* ============ 控件命名规范 ============
         * btn_*   = UIButton    (按钮)
         * txt_*   = UITextBox   (文本框)
         * ckb_*   = UICheckBox  (复选框)
         * cmb_*   = UIComboBox  (下拉框)
         * dgv_*   = DataGridView(表格)
         * gb_*    = UIGroupBox  (分组框)
         * lbl_*   = UILabel     (标签)
         * tslb_*  = ToolStripLabel(状态栏)
         * rtb_*   = RichTextBox (日志框)
         * iO_In*  = IO_In控件   (输入点)
         * iO_Out* = IO_Out控件  (输出点)
         * timer_* = Timer       (定时器)
         * tabPage* = 标签页
         * uiGroupBox* = Sunny分组框
         * uiLabel*   = Sunny标签(编号,见Designer)
         * ==================================== */
        #region 字段
        ProductionInfos _productInfos = new ProductionInfos();

        // 新服务层引用
        StatisticsService _statsService;
        ConfigService _configService;
        DeviceManager _deviceManager;
        StationController _stationController;

        Thread _buzzerThread;
        Thread[] _mainThreads = new Thread[3];
        bool _isHoming = false;
        DataTable _checkItemTable = new DataTable();
        CheckItemsConfig _checkItemsConfig = new CheckItemsConfig();
        int _homeCount = 0;

        bool _isRunning = false;
        bool _buzzerEnabled = false;
        OptionalConfig.OptionalParas _options = new OptionalConfig.OptionalParas();
        bool _isAxisHomed = false;
        string[] _modelFiles;
        string _positionsPath;
        string _checkItemPath;
        int _errorTimeout = 0;
        bool _isAutoRun = false;
        bool[] _ioFlags = new bool[48];
        TaskControl _transferTask = null;

        public ProductTypeConfig _productConfig = new ProductTypeConfig();//产品型号配置
        public LoginConfigs _loginConfigs = new LoginConfigs();

        //从login传来的当前登录用户、产品型号和端口 更具名称加载解决方案和轴配置
        public string _currentProductPort;
        public string _currentProductModel;
        public string _currentProductCode;
        public string _currentProductColor;
        public bool _needLoadRecipe; // FrmLogin标记：初始化完成后加载配方

        public string _operatorId;
        public string _currentUser;

        ProductTypeConfig.ProductType _currentProduct;//当前产品型号
        string _productIndex;
        List<InspectionRecord> _inspectionRecords = new List<InspectionRecord>();//检测记录
        IFreeSql _db; // FreeSql SQLite数据库
        System.Drawing.Bitmap[] images = new System.Drawing.Bitmap[3];
        int index;
        Stopwatch sw = new Stopwatch();
        string[] _imageFiles;


        PositionConfig _positionConfig;//位置配置
        string _axisIndexSelect;
        private IO_In[] _ioInputs;//输入信号数组（15个）
        private IO_Out[] _ioOutputs;//输出信号数组（16个）
        CancellationTokenSource _cancelSource;
        Int32[] _axisStopReason = new int[1];   // 单Z轴
        Int32[] _axisErrorHistory = new Int32[1];
        private float _currentZPosition;
        AxisBasicConfigs _axisConfigs = new AxisBasicConfigs();
        public string _loginConfigPath;
        bool _initFinished = false, _initSuccess = false;
        bool _transferAskBoard = false;
        bool _transferHaveBoard = false;
        bool _upDownHaveBoard = false;
        bool _outBoardAskBoard = false;
        int _stepUpDown = 0;
        int _stepOutBoard = 0;
        AutoSizeForm _autoSize = new AutoSizeForm();
        IntPtr _axisHandle;//运动控制卡句柄
        string[] _StrInformation = new string[12];
        List<ProductModel> _productModels;
        private Image _currentDisplayImage;
        private bool _shieldBuzzerCached;
        private readonly object _homeLock = new object();
        private readonly SemaphoreSlim _detectionLock = new SemaphoreSlim(1, 1);
        private System.Windows.Forms.TextBox txt_CurrentCheckTime;
        #endregion

        #region 窗体事件
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_result.Text = "";
                lbl_currentCode.Text = "";
                LogService.Information("[初始化] ====== FrmMain加载开始 ======");

                //窗口自适应：记录设计时初始尺寸（ResizeEnd 已在 Designer 中绑定）
                _autoSize.controllInitializeSize(this);

                // 1. 加载配置（优先从DI容器获取，失败则新建）
                LogService.Information("[初始化] 步骤1 加载JSON配置...");
                try
                {
                    _configService = CompositionRoot.Resolve<ConfigService>();
                }
                catch
                {
                    _configService = new ConfigService();
                }
                AppConfig _config = _configService.Load();
                LogService.Information("[初始化] 配置加载完成 | AxisIP={IP}", _config.Axis.IpAddress);

                // 2. 从 DI 获取已连接好的设备（避免重复连接 ZMC 控制器导致第二次连接失败）
                LogService.Information("[初始化] 步骤2 创建服务层...");
                try
                {
                    _statsService = CompositionRoot.Resolve<StatisticsService>();
                }
                catch
                {
                    _statsService = new StatisticsService(_configService);
                }

                // 关键：使用 DI 中已连接的 ZmcController，不重新 InitializeAll
                IMotionController motion;
                IVisionProcessor vision;
                try
                {
                    motion = CompositionRoot.Resolve<IMotionController>();
                }
                catch
                {
                    motion = new ZmcController(); motion.Connect(_config.Axis.IpAddress);
                }
                try
                {
                    vision = CompositionRoot.Resolve<IVisionProcessor>();

                }
                catch
                {
                    vision = new VmVisionProcessor();
                }

                _deviceManager = new DeviceManager
                {
                    Motion = motion,
                    Vision = vision
                };

                // 配置轴参数（ZmcController 已在 DI 中完成连接，这里只配轴不重复连接）
                motion.ConfigureAxis(0, _config.Axis);
                LogService.Information("[初始化] DeviceManager就绪 | Motion={M} Vision={V}",
                    motion.IsConnected, vision.IsLoaded);

                SetMachineStatus(MachineStatus.Initial);

                // 3. 初始化状态机
                LogService.Information("[初始化] 步骤3 创建状态机...");
                var cylinder = new Cylinder(motion,
                    IOMapping.OUT_CylinderOUT, IOMapping.OUT_CylinderIN,
                    IOMapping.IN_CylinderExtendOk, IOMapping.IN_CylinderRetractOk);
                // AlarmHandler 必须用 FrmMain 自己的 DeviceManager，不能从 DI 拿（DI 里的 DeviceManager 设备为空）

                var alarmHandler = new AlarmHandler(_deviceManager);


                var lightCurtain = new LightCurtain(motion, IOMapping.IN_LightCurtain);
                _deviceManager.Alarm = alarmHandler;
                _deviceManager.LightCurtain = lightCurtain;
                lightCurtain.StartMonitoring();
                _stationController = new StationController(
                    motion, vision,
         cylinder, alarmHandler, lightCurtain, _statsService, _config, _configService);

                // 订阅状态机完成事件

                _stationController.OnInspectionCompleted += record =>
                    SafeBeginInvoke(() =>
                    {

                        lbl_TotalResult.Text = record.Result;
                        lbl_TotalResult.BackColor = record.Result == "OK" ? Color.LightGreen : Color.Red;
                        UpdateStatsUI(_statsService.Current);
                        if (txt_CurrentCheckTime != null)
                            txt_CurrentCheckTime.Text = $"{record.CycleTimeMs} ms";
                        // 显示在 rtb_TestResult 并写入 SQLite
                        bool isOk = record.Result == "OK";
                        lbl_result.Text = record.Result=="OK"?"PASS":"Fail";
                        if (!isOk)
                        {
                            motion.WriteOutput(IOMapping.OUT_RedLight, true);

                            var config = _configService?.Load() ?? new AppConfig();
                            var config1= config.Features;
                            if (config1.ShieldBuzzer)
                            {
                                motion.WriteOutput(IOMapping.OUT_Buzzer, true);
                                
                            }
                           
                        }

                        lbl_result.BackColor = record.Result == "OK" ? Color.LightGreen : Color.Red;
                        SaveInspectionRecord(isOk, record.Reason, record.ProductCode, record.ProductColor);
                    });
                _stationController.OnStatusChanged += msg =>
                    SafeBeginInvoke(() =>
                    {
                        WriteMsg(msg, UserTheadStatus.SoftOptStatus);
                        if (msg.Contains("已停止"))
                        {
                            _isAxisHomed = false;
                            SetMachineStatus(MachineStatus.Initial);
                        }
                        else if (msg.Contains("复位中"))
                            SetThreeColorLight(MachineStatus.Initial);
                        else if (msg.Contains("复位完成"))
                        {
                            _isAxisHomed = true;
                            txt_AlarmInfo.Clear();
                            lbl_result.Text = "";
                            lbl_result.BackColor = Color.White;
                            if (txt_CurrentCheckTime != null)
                                txt_CurrentCheckTime.Text = "0 ms";
                            SetMachineStatus(MachineStatus.Initialed);
                        }
                        else if (msg.Contains("自动运行"))
                            SetMachineStatus(MachineStatus.Start);
                    });
                _stationController.OnAlarm += (code, msg) =>
                {
                    LogService.Error("[诊断-界面] 收到状态机报警 | {Code}: {Msg}", code, msg);
                    SafeBeginInvoke(() =>
                    {
                        SetThreeColorLight(MachineStatus.Alarm);
                        WriteNGMsg($"[{code}] {msg}", UserTheadStatus.AxisStatus);
                    });
                };
                LogService.Information("[初始化] 状态机创建完成 | 当前状态={State}", _stationController.CurrentState);
                LoadProductInfo();
                ControlEnable(_currentUser);
                timer_Home.Enabled = true;

                // 4. UI控件 — Designer 已绑定 CheckedChanged 事件，此处只加载初始值
                var f = _config.Features;

                ckb_ShieldBuzzer.Checked = f.ShieldBuzzer;
                _shieldBuzzerCached = f.ShieldBuzzer;
                ckb_ShieldLightCurtain.Checked = f.ShieldLightCurtain;
                ckb_CylinderShield.Checked = f.ShieldCylinder;
                ckb_SaveSourceImage.Checked = f.SaveOkImage;
                ckb_SaveNGSourceImage.Checked = f.SaveNgImage;

                _ioInputs = new IO_In[] { iO_In0, iO_In1, iO_In2, iO_In3, iO_In4, iO_In5, iO_In6, iO_In7, iO_In8, iO_In9, iO_In10, iO_In11, iO_In12, iO_In13, iO_In14, iO_In15 };
                _ioOutputs = new IO_Out[] { iO_Out0, iO_Out1, iO_Out2, iO_Out3, iO_Out4, iO_Out5, iO_Out6, iO_Out7, iO_Out8, iO_Out9, iO_Out10, iO_Out11, iO_Out12, iO_Out13, iO_Out14, iO_Out15 };
                string[] inNames = { "门禁", "设备启动", "急停", "复位", "气缸伸出到位", "气缸缩回到位", "保留", "流程启动", "停止", "IN9", "IN10", "IN11", "IN12", "IN13", "IN14", "IN15" };
                string[] outNames = { "电磁阀A", "电磁阀B", "光源COM123", "光源COM4", "OUT4", "黄灯", "绿灯", "红灯", "蜂鸣器", "OUT9", "OUT10", "OUT11", "OUT12", "OUT13", "OUT14", "OUT15" };
                for (int i = 0; i <= 15; i++) _ioInputs[i].IOName = inNames[i];
                for (int i = 0; i <= 15; i++) _ioOutputs[i].IOName = outNames[i];

                // 5. 加载轴配置到UI（直接从 JSON AxisConfig 读取）
                LogService.Information("[初始化] 步骤4 加载轴配置...");
                AxisConfigToUI(_config.Axis);

                // 6. 连接轴卡
                LogService.Information("[初始化] 步骤5 连接轴卡...");
                InitialAxis();
                LogService.Information("[初始化] 轴卡连接结果 | Connected={C} | Handle={H}",
                    _deviceManager.Motion?.IsConnected, _axisHandle);

                // 中封式电磁阀：上电初始化两路掉电，保持当前位置
                if (_deviceManager?.Motion?.IsConnected == true)
                {
                    _deviceManager.Motion.WriteOutput(IOMapping.OUT_CylinderOUT, false);
                    _deviceManager.Motion.WriteOutput(IOMapping.OUT_CylinderIN, false);
                }


                if (_buzzerThread?.ThreadState != System.Threading.ThreadState.Running)
                {
                    _buzzerThread = new Thread(new ThreadStart(Buzzer)) { IsBackground = true };
                    _buzzerThread.Start();
                }
                if (uiTabControl1 != null)
                {
                    uiTabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                }

                // 加载产品配方到 dataGridView3 和 comboBox1
                LoadProductGrid();
                InitProductCombo();
                cob_ProductType.Text = _currentProductPort;
                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                comboBox1.Text = _currentProductColor;
                lbl_currentCode.Text = _currentProductCode;
                InitDatabase();
                InitDbFilterControls();

                // 在 tabPage14 添加"完成检查时间"显示
                var lblCheckTime = new System.Windows.Forms.Label
                {
                    Text = "完成检查时间：",
                    Location = new System.Drawing.Point(24, 282),
                    AutoSize = true,
                    Font = new System.Drawing.Font("微软雅黑", 12F)
                };
                txt_CurrentCheckTime = new System.Windows.Forms.TextBox
                {
                    Location = new System.Drawing.Point(64, 302),
                    Size = new System.Drawing.Size(93, 23),
                    ReadOnly = true,
                    Text = "0 ms"
                };
                tabPage14.Controls.Add(lblCheckTime);
                tabPage14.Controls.Add(txt_CurrentCheckTime);

                _initFinished = true;
                _initSuccess = true;
                // 开机保持红灯（安全状态），等待用户手动复位后才变绿灯
                SetMachineStatus(MachineStatus.SoftwareOpen);
                CheckSafeStartupCondition();
                _stationController.StartIdlePolling();

                //  _autoSize.controlAutoSize(this);
                // 延迟加载配方（FrmLogin时DeviceManager尚未创建）
                if (_needLoadRecipe && !string.IsNullOrEmpty(_currentProductPort))
                {
                    var prod = _productModels?.FirstOrDefault(p => p.Product_port == _currentProductPort && p.Product_model == _currentProductModel);
                    UpdateCurrentProduct(_currentProductPort, _currentProductModel, prod);
                    LoadRecipeInfo(_currentProductPort, _currentProductModel, _currentProductCode);
                }
                LogService.Information("[初始化] ====== 初始化完成 Initialed ======");
            }
            catch (Exception ex)
            {
                LogService.Error(ex, "[初始化] 初始化异常");
                WriteNGMsg("初始化失败", UserTheadStatus.Initial, ex);
                _initFinished = true;
                _initSuccess = false;
            }
        }

        private void FrmMain_ResizeEnd(object sender, EventArgs e)
        {
            LogService.Information("[AutoSize] ResizeEnd W={W} H={H}", this.Width, this.Height);
            try
            {
                _autoSize.controlAutoSize(this);
            }
            catch (Exception ex)
            {
                LogService.Error(ex, "[AutoSize] ResizeEnd异常");
            }
        }
        #endregion

        #region 主程序

        /// <summary>
        /// 三色等灯控制方法，根据传入的状态设置对应的灯光和文本显示
        /// </summary>
        /// <param name="status"></param>


        private void SetThreeColorLight(MachineStatus status)
        {
            if (_deviceManager == null)
                LogService.Debug("[SetThreeColorLight] DeviceManager=null, 灯未设置 status={Status}", status);

            string text; Color color; bool green = false, red = false, yellow = false, buzz = false;
            string hint = "";
            switch (status)
            {
                case MachineStatus.Alarm:
                    red = true;
                    buzz = true;
                    text = "机台报警中";
                    color = Color.Red;
                    hint = "1. 检查并排除故障\r\n2. 点击【清除报警】\r\n3. 点击【复位】等待回零完成\r\n4. 绿灯亮后可点击【启动】";
                    _buzzerEnabled = true;
                    break;
                case MachineStatus.Initial:
                    yellow = true;
                    text = "机台复位中...";
                    color = Color.LightYellow;
                    hint = "气缸伸出 + 轴回零中，请稍候...\r\n完成后将自动变为绿灯";
                    _buzzerEnabled = false;
                    break;
                case MachineStatus.Initialed:
                    green = true;
                    text = "机台就绪";
                    color = Color.LightGreen;
                    hint = "操作提示：\r\n  ● 点击【启动】开始自动检测\r\n  ● 切换配方：在上方下拉框选择产品型号\r\n  ● 配方切换后轴将自动移到检测位置";
                    _buzzerEnabled = false;
                    break;
                case MachineStatus.Start:
                    green = true;
                    text = "自动运行中";
                    color = Color.LightGreen;
                    hint = "设备正在自动检测，请勿靠近运动部件\r\n  ● 按【停止】可中止运行\r\n  ● 如需切换配方请先停止";
                    _buzzerEnabled = false;
                    break;
                case MachineStatus.Stop:
                    red = true;
                    text = "机台已停止";
                    color = Color.Red;
                    hint = "设备已停止，轴位置保持不变\r\n  ● 点击【复位】回零后可重新启动\r\n  ● 或直接切换配方后点击【启动】";
                    _buzzerEnabled = false;
                    break;
                default:
                    red = true;
                    text = "等待初始化";
                    color = Color.Red;
                    hint = "1. 请确认急停按钮已松开\r\n2. 点击【复位】按钮初始化设备\r\n3. 等待回零完成，绿灯亮后即可操作";
                    break;
            }

            bool buzzerShielded = _configService?.Load()?.Features?.ShieldBuzzer ?? false;
            _deviceManager?.SetTowerLight(green, red, yellow, buzz && !buzzerShielded);

            SafeInvoke(() =>
            {
                lbl_MachineStatus.Text = text;
                lbl_MachineStatus.BackColor = color;
                if (lbl_about != null) lbl_about.Text = hint;
            });
        }

        /// <summary>
        /// 设置机台状态的统一方法，内部调用SetThreeColorLight控制灯光，并记录日志和处理异常
        /// </summary>
        /// <param name="status"></param>
        private void SetMachineStatus(MachineStatus status)
        {
            LogService.Information("[状态灯] → {Status} | DeviceManager={DM}", status, _deviceManager != null ? "OK" : "NULL");
            try { SetThreeColorLight(status); }
            catch (Exception ex) { LogService.Error(ex, "[状态灯] SetMachineStatus异常"); WriteNGMsg(ex.Message, UserTheadStatus.AxisStatus, ex); }
        }




        // 蜂鸣器线程，持续监控是否需要报警并控制蜂鸣器响起
        private void Buzzer()
        {
            while (true)
            {
                bool shielded = _shieldBuzzerCached;
                if (_buzzerEnabled && !shielded)
                {
                    _deviceManager?.Motion?.WriteOutput(IOMapping.OUT_Buzzer, true);
                    Thread.Sleep(500);
                    _deviceManager?.Motion?.WriteOutput(IOMapping.OUT_Buzzer, false);
                    Thread.Sleep(500);
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
        }

        private void ControlEnable(string userName)
        {
            switch (userName)
            {
                case "管理员":
                    if (gb_Optional != null) gb_Optional.Enabled = true;
                    if (gb_CheckItems != null) gb_CheckItems.Enabled = true;
                    if (gb_AxisSet != null) gb_AxisSet.Enabled = true;

                    break;
            }

        }
        #endregion

        #region 参数导入与保存

        private bool LoadProductInfo()
        {
            try
            {
                var stats = _statsService?.Current;
                if (stats == null) return false;

                this.Invoke(new Action(() => UpdateStatsUI(stats)));
                return true;
            }
            catch (Exception ex)
            {
                WriteNGMsg(ex.Message, UserTheadStatus.Initial, ex);
                return false;
            }
        }

        private void UpdateStatsUI(CCDInspection.Core.Models.ProductionStatistics stats)
        {
            if (this.InvokeRequired) { this.Invoke(new Action(() => UpdateStatsUI(stats))); return; }
            txt_CurrentOKCount.Text = stats.CurrentOkCount.ToString();
            txt_CurrentNGCount.Text = stats.CurrentNgCount.ToString();
            txt_CurrentCount.Text = stats.CurrentTotalCount.ToString();
            txt_CurrentOKYeild.Text = stats.CurrentOkYield.ToString("0.00");
            txt_CurrentNGYeild.Text = stats.CurrentNgYield.ToString("0.00");
            txt_TotalOKCount.Text = stats.TotalOkCount.ToString();
            txt_TotalNGCount.Text = stats.TotalNgCount.ToString();
            txt_TotalCount.Text = stats.TotalCount.ToString();
            txt_TotalOKYeild.Text = stats.TotalOkYield.ToString("0.00");
            txt_TotalNGYeild.Text = stats.TotalNgYield.ToString("0.00");
        }




        private void SaveOptionalConfig()
        {
            if (!_initFinished) return;
            var config = _configService?.Load() ?? new AppConfig();
            var f = config.Features;

            f.ShieldBuzzer = ckb_ShieldBuzzer.Checked;
            f.ShieldLightCurtain = ckb_ShieldLightCurtain.Checked;
            f.ShieldCylinder = ckb_CylinderShield.Checked;
            f.SaveOkImage = ckb_SaveSourceImage.Checked;
            f.SaveNgImage = ckb_SaveNGSourceImage.Checked;
            _shieldBuzzerCached = ckb_ShieldBuzzer.Checked;
            _configService?.Save(config);
        }
        #endregion



        #region 初始化
        private void SaveCameraSet()
        {
            // 相机功能已移除
        }

        private bool InitialCamera()
        {
            LogService.Information("[初始化] 相机功能已移除，跳过相机连接");
            return true;
        }

        private void ConfigToUICamera()
        {
            // 相机功能已移除
        }

        #endregion



        #region 软件状态更新与日志记录
        enum UserTheadStatus
        {
            CameraStatus,
            SoftOptStatus,
            AxisStatus,
            Initial
        }
        private void WriteNGMsg(string message, UserTheadStatus threadstatus, Exception ex = null)
        {
            WriteStatus(txt_AlarmInfo, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "--->" + message, Color.Red, 10, true);
            if (ex != null)
                LogService.Error(ex, "[{Status}] {Message}", threadstatus, message);
            else
                LogService.Error("[{Status}] {Message}", threadstatus, message);
        }

        private void WriteMsg(string message, UserTheadStatus threadstatus)
        {
            WriteStatus(txt_SoftOptStatus, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "--->" + message, Color.Black, 10, false);
            LogService.Information("[{Status}] {Message}", threadstatus, message);
        }

        private void WriteStatus(RichTextBox richTextBox_news, string text, Color color, int fontSize, bool ngmsg)
        {
            this.Invoke(new Action(() =>
            {
                if (richTextBox_news.TextLength > 10000)
                {
                    richTextBox_news.Clear();
                }
                richTextBox_news.SelectionFont = new Font("行书", 9, FontStyle.Regular);
                richTextBox_news.SelectionColor = color;
                richTextBox_news.AppendText(text + "\n");
                richTextBox_news.ScrollToCaret();
            }));
        }

        #endregion

        #region 轴控


        public void EmergencyAction(Int32[] stopReason, Int32 errorAxisNum)
        {

            //因为要在循环里不停的发送RapidStop, 所以把timer停掉.
            timer_Axis.Enabled = false;
            //*****这里只是示例把错误码拷出来,生产中可以把它写入文件或者数据库*****
            Array.Copy(stopReason, _axisErrorHistory, _axisStopReason.Length);
            string error_Code;
            switch (_axisErrorHistory[0])
            {
                case 2:
                    error_Code = "随动误差超限告警";
                    break;
                case 4:
                    error_Code = "与远程轴通讯出错";
                    break;
                case 8:
                    error_Code = "远程驱动器报错";
                    break;
                case 16:
                    error_Code = "正向硬限位";
                    break;
                case 32:
                    error_Code = "反向硬限位";
                    break;
                case 64:
                    error_Code = "找原点中";
                    break;
                case 128:
                    error_Code = "HOLD速度保持信号输入";
                    break;
                case 256:
                    error_Code = "随动误差超限出错";
                    break;
                case 512:
                    error_Code = "超过正向软限位";
                    break;
                case 1024:
                    error_Code = "超过负向软限位";
                    break;
                case 2048:
                    error_Code = "CANCEL执行中";
                    break;
                case 4096:
                    error_Code = "脉冲频率超过MAX_SPEED限制.需要修改降速或修改MAX_SPEED";
                    break;
                case 16384:
                    error_Code = "机械手指令坐标错误";
                    break;
                case 262144:
                    error_Code = "电源异常";
                    break;
                case 2097152:
                    error_Code = "运动中触发特殊运动指令失败";
                    break;
                case 4194304:
                    error_Code = "告警信号输入";
                    break;
                case 8388608:
                    error_Code = "轴进入了暂停状态";
                    break;
                default:
                    error_Code = _axisErrorHistory[0].ToString();
                    break;
            }

            WriteNGMsg(error_Code, UserTheadStatus.AxisStatus);
            LogService.Error("[诊断-急停] 启动RapidStop循环 | 错误={Code} timer=关闭", error_Code);

            //把急停循环放入新线程里, 不要卡死主线程
            _cancelSource = new CancellationTokenSource();
            CancellationToken ct = _cancelSource.Token;

            var task = Task.Run(() =>
            {
                LogService.Error("[诊断-急停] RapidStop循环已启动!");
                while (!ct.IsCancellationRequested)
                {
                    _deviceManager?.Motion?.EmergencyStop();
                }
                LogService.Information("[诊断-急停] RapidStop循环已退出");
            }, _cancelSource.Token);

        }

        private bool InitialAxis()
        {
            if (_deviceManager?.Motion?.IsConnected != true)
            {
                WriteNGMsg("轴卡未连接！", UserTheadStatus.SoftOptStatus, new Exception());
                return false;
            }
            _axisHandle = _deviceManager.Motion.GetHandle();
            // 控制器已有ZDevelop配置,跳过ConfigureAxis避免覆盖有效参数
            // SetAxisParas();
            _deviceManager.Motion.ZAxis?.Enable();
            ckb_AxisEnable.Checked = true;
            timer_Axis.Start();
            timer_IO.Start();
            WriteMsg("轴卡已就绪，已使能", UserTheadStatus.SoftOptStatus);
            return true;
        }

        private bool CloseCard()
        {
            if (_deviceManager?.Motion?.IsConnected != true) return false;
            _deviceManager.Motion.Disconnect();
            _axisHandle = (IntPtr)0;
            timer_Axis.Stop();
            timer_IO.Stop();
            WriteMsg("控制卡断开连接成功！", UserTheadStatus.SoftOptStatus);
            return true;
        }

        // JSON AxisConfig → UI 文本框
        private void AxisConfigToUI(AxisConfig cfg)
        {
            try { txt_ManualSpeed.Text = cfg.ManualSpeed.ToString(); } catch { }
            try { txt_PulseEquivalent.Text = cfg.PulseEquivalent.ToString(); } catch { }
            try { txt_AutoSpeed.Text = cfg.AutoSpeed.ToString(); } catch { }
            try { txt_Acceleration.Text = cfg.Acceleration.ToString(); } catch { }
            try { txt_Deceleration.Text = cfg.Deceleration.ToString(); } catch { }
            try { txt_PositiveSoftLimit.Text = cfg.PositiveSoftLimit.ToString(); } catch { }
            try { txt_NegativeSoftLimit.Text = cfg.NegativeSoftLimit.ToString(); } catch { }
            try { txt_HomeSpeed.Text = cfg.HomeSpeed.ToString(); } catch { }
            try { txt_SlowSpeed.Text = cfg.CreepSpeed.ToString(); } catch { }
            try { txt_PositivePoint.Text = cfg.PosLimitIo.ToString(); } catch { }
            try { txt_NegtivePoint.Text = cfg.NegLimitIo.ToString(); } catch { }
            try { txt_OriginPoint.Text = cfg.OriginIo.ToString(); } catch { }
            try { txt_AlarmPoint.Text = cfg.AlarmIo.ToString(); } catch { }
            try
            {
                for (int i = 0; i < cmb_HomeModel.Items.Count; i++)
                    if (Convert.ToInt32(cmb_HomeModel.Items[i].ToString()) == cfg.HomeModel)
                        cmb_HomeModel.SelectedIndex = i;
            }
            catch { }
        }

        // UI 文本框 → JSON AxisConfig
        private void UIToAxisConfig(AxisConfig cfg)
        {
            cfg.PulseEquivalent = float.Parse(txt_PulseEquivalent.Text);
            cfg.AutoSpeed = float.Parse(txt_AutoSpeed.Text);
            cfg.Acceleration = float.Parse(txt_Acceleration.Text);
            cfg.Deceleration = float.Parse(txt_Deceleration.Text);
            cfg.PositiveSoftLimit = float.Parse(txt_PositiveSoftLimit.Text);
            cfg.NegativeSoftLimit = float.Parse(txt_NegativeSoftLimit.Text);
            cfg.ManualSpeed = float.Parse(txt_ManualSpeed.Text);
            cfg.ManualDistance = 100;
            cfg.HomeModel = int.Parse(cmb_HomeModel.SelectedItem.ToString());
            cfg.HomeSpeed = float.Parse(txt_HomeSpeed.Text);
            cfg.CreepSpeed = float.Parse(txt_SlowSpeed.Text);
            cfg.OriginIo = int.Parse(txt_OriginPoint.Text);
            cfg.PosLimitIo = int.Parse(txt_PositivePoint.Text);
            cfg.NegLimitIo = int.Parse(txt_NegtivePoint.Text);
            cfg.AlarmIo = int.Parse(txt_AlarmPoint.Text);
        }

        /// <summary>
        /// 设置控制器参数
        /// </summary>
        public void SetAxisParas()
        {
            if (_deviceManager?.Motion?.IsConnected != true) return;
            var cfg = _configService?.Load()?.Axis;
            if (cfg == null) return;
            LogService.Information("[SetAxisParas] 配置Z轴(索引0) | PulEq={PE} Speed={Spd} Accel={Acc} Decel={Dec}",
                cfg.PulseEquivalent, cfg.AutoSpeed, cfg.Acceleration, cfg.Deceleration);
            _deviceManager.Motion.ConfigureAxis(0, cfg);
        }

        #endregion



        #region 按钮事件

        private void txt_AxisBasicCnf_TextChanged(object sender, EventArgs e)
        {

        }





        /// <summary>
        /// 【启动】按钮 — 进入自动运行模式
        /// 条件：相机软触发模式 + 初始化成功 + 轴已回零
        /// 效果：绿灯(Start) → 启动状态机 → 等待双手按钮触发检测
        /// </summary>
        private void btn_StartAutoTest_Click(object sender, EventArgs e)
        {
            LogService.Information("[诊断-界面] btn_StartAutoTest 点击");
            if (!CanStartAutomation()) return;

            _isAutoRun = true;
            _isRunning = true;
            SetControlsEnabledDuringRunning(true);
            SetMachineStatus(MachineStatus.Start);
            ExecuteCylinderDetection();
        }

        private void btn_StopAutoTest_Click(object sender, EventArgs e)
        {
            LogService.Information("[诊断-界面] btn_StopAutoTest 点击 | 当前状态机={S}",
                _stationController?.CurrentState);
            _isRunning = false;
            _isAutoRun = false;
            _isAxisHomed = false;
            _transferTask?.Stop();
            Task.Run(async () => await _stationController?.StopAsync());
            SetControlsEnabledDuringRunning(false);
            SetMachineStatus(MachineStatus.Initial);
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            FrmPermissionLogin frmPermissionLogin = new FrmPermissionLogin();
            frmPermissionLogin.m_LoginConfigs = _loginConfigs;
            if (frmPermissionLogin.ShowDialog(this) == DialogResult.OK)
            {
                _currentUser = frmPermissionLogin.m_userName;
                ControlEnable(_currentUser);
            }
        }







        private void btn_AllHome_Click(object sender, EventArgs e)
        {
            lock (_homeLock)
            {
                if (_isHoming) { WriteMsg("复位进行中，请勿重复操作", UserTheadStatus.SoftOptStatus); return; }
                _isHoming = true;
            }

            try
            {
                SetThreeColorLight(MachineStatus.Initial);
                btn_StopAutoTest_Click(null, null);

                _transferAskBoard = false;
                _transferHaveBoard = false;
                _upDownHaveBoard = false;
                _outBoardAskBoard = false;
                _stepUpDown = 0;
                _stepOutBoard = 0;
                _transferTask?.Abort();
                _transferTask?.Reset();

                if (MessageBox.Show("确认复位机台?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                   System.Windows.Forms.DialogResult.Cancel) { lock (_homeLock) _isHoming = false; return; }
                if (_deviceManager?.Motion?.IsConnected != true) { lock (_homeLock) _isHoming = false; return; }

                // 先取消可能正在运行的 RapidStop 循环
                if (_cancelSource != null)
                {
                    LogService.Information("[复位] 取消RapidStop循环再回零");
                    _cancelSource.Cancel();
                    _cancelSource.Dispose();
                    _cancelSource = null;
                }
                timer_Axis.Enabled = true;

                Task.Run(async () =>
            {
                try
                {
                    var cfg = _configService?.Load()?.Axis ?? new CCDInspection.Core.Models.AxisConfig();
                    LogService.Information("[复位] 开始回零 | Handle={H} | IsConnected={C} | ZAxis={Z} | HomeModel={M}",
                        _axisHandle, _deviceManager.Motion?.IsConnected,
                        _deviceManager.Motion?.ZAxis != null ? "OK" : "NULL", cfg.HomeModel);
                    if (_deviceManager.Motion.ZAxis != null)
                    {
                        bool homeOk = await _deviceManager.Motion.ZAxis.Home(cfg);
                        LogService.Information("[复位] 回零结果={Result}", homeOk);
                        _isAxisHomed = homeOk;
                    }
                    else { LogService.Error("[复位] ZAxis为null，无法回零"); }
                }
                finally
                {
                    lock (_homeLock) _isHoming = false;
                    this.Invoke(new Action(() => SetThreeColorLight(MachineStatus.Initialed)));
                }
            });
            }
            catch (Exception ex) { LogService.Error(ex, "[复位] 异常"); lock (_homeLock) _isHoming = false; }
        }

        private void btn_AllAxisStop_Click(object sender, EventArgs e)
        {
            _deviceManager?.Motion?.ZAxis?.Stop();
            WriteMsg("轴停止成功！", UserTheadStatus.SoftOptStatus);
        }

        private void btn_ClearAlarm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清除轴错误?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            if (_deviceManager?.Motion?.IsConnected != true)
            {
                WriteNGMsg("未连接到控制器", UserTheadStatus.AxisStatus);
                return;
            }

            // 停止 EmergencyAction 的无限 RapidStop 循环
            if (_cancelSource != null)
            {
                LogService.Information("[诊断-急停] 取消RapidStop循环");
                _cancelSource.Cancel();
                _cancelSource.Dispose();
                _cancelSource = null;
            }
            _deviceManager.Motion.ZAxis?.ClearAlarm();
            _deviceManager.Motion.ClearAlarm(0);
            timer_Axis.Enabled = true; // 重新开启轴状态监控
            LogService.Information("[诊断-急停] 报警已清除 timer=恢复");
            // 同步清除状态机报警（只清报警不回零，保持轴位不变）
            _deviceManager?.Alarm?.ClearAlarm();
            _stationController?.ClearAlarmOnly();
            WriteMsg("轴报警已清除", UserTheadStatus.AxisStatus);
        }


        /// <summary>
 
        /// CT要求：30-40S/Pcs
        /// </summary>
        private float _detectZHeight = 20f; // 自动检测高度(mm)，UI输入框可修改

        /// <summary>
        /// 执行一次自动检测流程（气缸移载方式）

        /// </summary>
        private async void ExecuteCylinderDetection()
        {
            // 通过编码前缀搜索VM方案文件并加载
            var solDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VmSol", _currentProductPort);
            var solPath = "";
            if (Directory.Exists(solDir))
            {
                var code = _currentProductCode ?? _currentProductModel;
                var solFiles = Directory.GetFiles(solDir, code + "*.sol");
                if (solFiles.Length > 0) solPath = solFiles[0];
            }
            LogService.Information("[主界面] 加载VM方案: {Path}", solPath);
            if (!string.IsNullOrEmpty(solPath) && File.Exists(solPath))
            {
                try { _deviceManager.Vision.LoadSolution(solPath); }
                catch (Exception ex) { LogService.Error(ex, "[主界面] VM方案加载失败"); }
            }
            else
            {
                LogService.Warning("[主界面] VM方案不存在, 编码={Code}", _currentProductCode);
                lbl_currentCode.Text = $"{_currentProductCode}-方案缺失";
            }

            var product = new CCDInspection.Core.Models.ProductConfig
            {
                Index = _currentProduct.ProductIndex,
                Name = _currentProduct.ProductName,
                ZHeight = _configService?.Load()?.Inspection?.DetectZHeight ?? _detectZHeight,
                Color = _currentProduct.ProductColor,
                SolPath = solPath
            };
            await _stationController.StartAsync(product);
        }

        private void AddCameraEvent()
        {
            // 相机功能已移除
        }

        uint[] _ioStates = new uint[16];

        private bool _hwEmgTriggered = false;  // 硬件急停专用
        private bool _emgTriggered = false;    // 限位报警专用（不与IO定时器共享）

        private void timer_IO_Tick(object sender, EventArgs e)
        {
            if (_deviceManager?.Motion?.IsConnected != true) return;

            // 急停硬件轮询（IN2 常闭，LOW=按下）
            bool emgState = _deviceManager.Motion.ReadInput(IOMapping.IN_EmergencyStop);
            if (!emgState && !_hwEmgTriggered)
            {
                _hwEmgTriggered = true;
                EmergencyStopAll();
            }
            else if (emgState && _hwEmgTriggered)
            {
                _hwEmgTriggered = false;
            }

            for (int i = 0; i <= 15; i++)
            {
                bool state = _deviceManager.Motion.ReadInput(i);
                _ioStates[i] = state ? 1u : 0u;
                if (i < _ioInputs.Length) _ioInputs[i].IOStatus = state;
            }
            if (_axisHandle != IntPtr.Zero)
                for (int i = 0; i <= 15; i++)
                    if (i < _ioOutputs.Length) { uint s = 0; ZmcApi.ZAux_Direct_GetOp(_axisHandle, i, ref s); _ioOutputs[i].IOStatus = s != 0; }
        }

        private const int ZMC_ZAXIS_INDEX = 0; // 与 ZmcController.ZAxisIndex 保持一致

        private void timer_Axis_Tick(object sender, EventArgs e)
        {
            if (_deviceManager?.Motion?.IsConnected != true) return;
            var zAxis = _deviceManager.Motion.ZAxis;
            if (zAxis == null) return;

            _currentZPosition = zAxis.CurrentPosition;
            float axisStatus = 0;
            ZmcApi.ZAux_Direct_GetParam(_axisHandle, "AXISSTATUS", ZMC_ZAXIS_INDEX, ref axisStatus);
            int st = (int)axisStatus;
            bool enabled = (st & 0x0001) == 0;
            bool atPosLimit = (st & 0x0010) != 0;  // 正限位
            bool atNegLimit = (st & 0x0020) != 0;  // 负限位

            // 限位报警：只报告一次，不重复Stop（让用户能反向点动退出限位）
            // 回零中或状态机复位中也不干预，让 HomeAsync 的退出限位逻辑自行处理
            bool isResetting = _isHoming || _stationController?.CurrentState == StationState.Resetting;
            if ((atPosLimit || atNegLimit) && !_emgTriggered && !isResetting)
            {
                _emgTriggered = true;
                zAxis?.Stop();
                LogService.Warning("[限位报警] 轴0 触发{Type}限位，已停止 | 位置={Pos:F1}",
                    atPosLimit ? "正向" : "负向", _currentZPosition);
                SafeBeginInvoke(() => WriteNGMsg(
                    $"{(atPosLimit ? "正向" : "负向")}限位触发！请反向点动退出限位后复位",
                    UserTheadStatus.AxisStatus));
                SafeBeginInvoke(() => SetMachineStatus(MachineStatus.Alarm));
            }
            else if (!atPosLimit && !atNegLimit && _emgTriggered)
            {
                _emgTriggered = false;
                LogService.Information("[限位报警] 轴已退出限位 | 位置={Pos:F1}", _currentZPosition);
                SafeBeginInvoke(() => WriteMsg("轴已退出限位", UserTheadStatus.AxisStatus));
            }

            string text = enabled
                ? (atPosLimit ? "正向限位" : atNegLimit ? "负向限位" : (st & 0x0200) != 0 ? "运动中" : (st & 0x0040) != 0 ? "报警" : "就绪")
                : "未使能";
            this.Invoke(new Action(() => { tslb_actionInfo.Text = $"Z:{_currentZPosition:F1} [{text}]"; tslb_img.Text = text; }));
            // 实时更新Z轴位置显示
            SafeBeginInvoke(() => { if (uiTextBox1 != null) uiTextBox1.Text = _currentZPosition.ToString("F2"); });
            // 读取轴停止原因
            float stopReason = 0;
            ZmcApi.ZAux_Direct_GetParam(_axisHandle, "AXIS_STOPREASON", ZMC_ZAXIS_INDEX, ref stopReason);
            int reason = (int)stopReason;
            if (reason != 0 && reason != 2048) // 2048="CANCEL执行中"是正常取消，忽略
            {
                _axisStopReason[0] = reason;
                LogService.Warning("[诊断-急停] AXIS_STOPREASON={Reason} 触发EmergencyAction | 当前位置={Pos:F1} 轴状态={St}",
                    reason, _currentZPosition, st);
                EmergencyAction(_axisStopReason, 0);
            }
            else if (reason == 2048)
            {
                LogService.Debug("[诊断-急停] 忽略 STOPREASON=2048 (CANCEL执行中，正常)");
            }
        }


        private void JogAxis(int direction)
        {
            LogService.Information("[诊断-点动] 请求 dir={Dir}", direction);
            if (_deviceManager?.Motion?.IsConnected != true)
            {
                LogService.Warning("[诊断-点动] 失败: 控制器未连接");
                WriteNGMsg("控制器未连接", UserTheadStatus.AxisStatus);
                return;
            }
            if (_axisHandle == IntPtr.Zero)
            {
                LogService.Warning("[诊断-点动] 失败: 轴句柄无效");
                WriteNGMsg("轴句柄无效", UserTheadStatus.AxisStatus);
                return;
            }
            if (_cancelSource != null)
            {
                LogService.Warning("[诊断-点动] 失败: RapidStop循环正在运行!");
                WriteNGMsg("轴处于急停锁定状态，请先清除报警", UserTheadStatus.AxisStatus);
                return;
            }
            if (!float.TryParse(txt_ManualSpeed.Text.Trim(), out float speed) || speed <= 0)
            {
                WriteNGMsg("手动速度无效", UserTheadStatus.AxisStatus);
                return;
            }
            LogService.Information("[诊断-点动] 执行 Jog dir={Dir} speed={Spd}", direction, speed);
            _deviceManager.Motion.ZAxis?.Jog(direction, speed);
        }

        private void StopAxis()
        {
            LogService.Information("[诊断-点动] StopAxis");
            _deviceManager?.Motion?.ZAxis?.Stop();
        }



        private void btn_ZUp_MouseDown(object sender, MouseEventArgs e) => JogAxis(-1);
        private void btn_ZUp_MouseUp(object sender, MouseEventArgs e) => StopAxis();
        private void btn_ZDown_MouseDown(object sender, MouseEventArgs e) => JogAxis(1);
        private void btn_ZDown_MouseUp(object sender, MouseEventArgs e) => StopAxis();
        private void cmb_Axis_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cfg = _configService?.Load()?.Axis;
            if (cfg != null) AxisConfigToUI(cfg);
        }

        private void VerifyPassword()
        {
            if (txt_OriginPassword.Text.Length == 0)
            {
                MessageBox.Show("请输入原密码！");
                return;
            }
            if (_loginConfigs.m_Logins.Count == 0)
            {
                _loginConfigs.m_Logins.Add(new LoginConfig { UserName = "管理员", PassWord = "123456" });
            }

            string salt;
            string password = GetPassWord("管理员", out salt);
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("未找到管理员");
                return;
            }
            if (!VerifyPassword(password, txt_OriginPassword.Text.Trim()))
            {
                MessageBox.Show("原密码错误");
                return;
            }
        }

        private bool VerifyPassword(string password, string newPassword)
        {
            return newPassword == password;
        }
        private string GetPassWord(string username, out string salt)
        {
            salt = string.Empty;
            for (int i = 0; i < _loginConfigs.m_Logins.Count; i++)
            {
                if (_loginConfigs.m_Logins[i].UserName == username)
                {
                    return _loginConfigs.m_Logins[i].PassWord;
                }
            }
            return string.Empty;
        }

        private void btn_ModifyPassWord_Click(object sender, EventArgs e)
        {
            VerifyPassword();
            string originalPassword = txt_NewPassword.Text.Trim(); // 你的用户密码
            for (int i = 0; i < _loginConfigs.m_Logins.Count; i++)
            {
                if (_loginConfigs.m_Logins[i].UserName == cmb_UserName.SelectedItem.ToString())
                {
                    _loginConfigs.m_Logins[i].PassWord = originalPassword;
                    break;
                }
            }
            _loginConfigs.SaveData(_loginConfigPath);
        }



        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _deviceManager?.Dispose();
            _db?.Dispose();
            Application.Exit();
        }


        private void iO_Out0_CheckedChanged(object sender, IO_outEventArgs e)
        {
            _deviceManager?.Motion?.WriteOutput(e.Id, e.isChecked);
        }

        private void iO_In0_StatusChanged(object sender, StatusEventArgs e)
        {
            //if (e.Status)
            //{
            //    _ioFlags[e.Id] = true;
            //}
            //switch (e.Id)
            //{
            //    case IOMapping.IN_CylinderExtendOk: // IN4 气缸伸出到位 — 光栅检测
            //        if (!e.Status && _ioFlags[IOMapping.IN_CylinderExtendOk])
            //        {
            //            _ioFlags[IOMapping.IN_CylinderExtendOk] = false;
            //            _buzzerEnabled = true;
            //            _deviceManager?.Motion?.ZAxis?.Stop();
            //        }
            //        break;

            //    case IOMapping.IN_CylinderRetractOk: // IN5 气缸缩回到位
            //        if (e.Status && _ioFlags[IOMapping.IN_CylinderRetractOk])
            //        {
            //            _ioFlags[IOMapping.IN_CylinderRetractOk] = false;
            //            btn_StartAutoTest_Click(null, null);
            //            SetMachineStatus(MachineStatus.Start);
            //        }
            //        break;

            //    case IOMapping.IN_EmergencyStop: // IN2 急停（常闭，LOW=按下）
            //        if (!e.Status && !_hwEmgTriggered)
            //        {
            //            _hwEmgTriggered = true;
            //            _buzzerEnabled = true;
            //            EmergencyStopAll();
            //        }
            //        else if (e.Status)
            //        {
            //            _hwEmgTriggered = false;
            //            _buzzerEnabled = false;
            //        }
            //        break;
            //}
        }

        /// <summary>
        /// 急停处理：立即停止所有运动，禁止再次启动 → 触发报警状态机 → 等待人工干预（清除报警、复位）
        /// </summary>
        private void EmergencyStopAll()
        {
            LogService.Error("[诊断-界面] EmergencyStopAll 触发!");
            _deviceManager?.Motion?.ZAxis?.Stop();
            _deviceManager?.Motion?.EmergencyStop();
            _stationController?.TriggerAlarmAsync("EMG", "急停按钮按下");
            SetMachineStatus(MachineStatus.Alarm);
            for (int i = 0; i <= 15; i++)
                _deviceManager?.Motion?.WriteOutput(i, false);
        }
        /// <summary>
        /// 开机安全检查：气缸位置 + 急停状态
        /// </summary>
        private void CheckSafeStartupCondition()
        {
            try
            {
                bool cylExt = _deviceManager?.Motion?.ReadInput(IOMapping.IN_CylinderExtendOk) ?? false;
                bool cylRet = _deviceManager?.Motion?.ReadInput(IOMapping.IN_CylinderRetractOk) ?? false;
                bool emg = !(_deviceManager?.Motion?.ReadInput(IOMapping.IN_EmergencyStop) ?? true);

                if (cylRet && !cylExt) { WriteNGMsg("警告：气缸处于缩回状态！请先复位再启动", UserTheadStatus.SoftOptStatus); SetMachineStatus(MachineStatus.Alarm); }
                else if (!cylExt && !cylRet) WriteMsg("提示：气缸位置未知，建议先执行复位", UserTheadStatus.SoftOptStatus);

                if (emg) { WriteNGMsg("警告：急停按钮已按下！请松开后复位", UserTheadStatus.SoftOptStatus); SetMachineStatus(MachineStatus.Alarm); }
            }
            catch (Exception ex) { LogService.Error(ex, "[安全检查] CheckSafeStartupCondition异常"); }
        }

        /// <summary>
        /// 启动前统一安全检查
        /// </summary>
        private bool CanStartAutomation()
        {

            if (!_initSuccess) { WriteNGMsg("初始化失败，无法启动机台", UserTheadStatus.SoftOptStatus); return false; }
            if (!_isAxisHomed) { WriteNGMsg("复位未完成，请复位", UserTheadStatus.SoftOptStatus); return false; }

            bool emg = !(_deviceManager?.Motion?.ReadInput(IOMapping.IN_EmergencyStop) ?? true);
            if (emg) { WriteNGMsg("急停按钮已按下，无法启动", UserTheadStatus.SoftOptStatus); return false; }

            bool cylExt = _deviceManager?.Motion?.ReadInput(IOMapping.IN_CylinderExtendOk) ?? false;
            if (!cylExt) { WriteNGMsg("气缸未伸出，请先复位", UserTheadStatus.SoftOptStatus); return false; }

            return true;
        }

        /// <summary>
        /// 运行中禁用/启用关键参数控件，防止误操作
        /// </summary>
        private void SetControlsEnabledDuringRunning(bool isRunning)
        {
            SafeInvoke(() =>
            {
                gb_AxisSet.Enabled = !isRunning;
                btn_GoHome.Enabled = !isRunning;

                //btn_StartAutoTest.Enabled = !isRunning;
                //btn_StopAutoTest.Enabled = isRunning;
                // 自动运行中禁止手动点动，防止轴位置被推偏
                btn_ZUp.Enabled = !isRunning;
                btn_ZDown.Enabled = !isRunning;
                btn_AllAxisStop.Enabled = !isRunning;
            });
        }


        private void ckb_AxisEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (_deviceManager?.Motion?.IsConnected != true) return;

            if (ckb_AxisEnable.Checked)
            {
                bool ok = _deviceManager.Motion.ZAxis?.Enable() ?? false;
                ckb_AxisEnable.Text = ok ? "Enable" : "Enable Failed";
                WriteMsg(ok ? "轴使能成功" : "轴使能失败", UserTheadStatus.AxisStatus);
            }
            else
            {
                bool ok = _deviceManager.Motion.ZAxis?.Disable() ?? false;
                ckb_AxisEnable.Text = "Disable";
                WriteMsg("轴去使能", UserTheadStatus.AxisStatus);
            }
        }

        private void btn_SaveAxisBasicCnf_Click(object sender, EventArgs e)
        {
            if (!_initFinished) return;

            try
            {
                var cfg = _configService?.Load();
                if (cfg != null)
                {
                    UIToAxisConfig(cfg.Axis);
                    _configService.Save(cfg);
                }
                SetAxisParas();
                LogService.Information("[保存轴配置] JSON 已保存");
                WriteMsg("轴配置保存成功", UserTheadStatus.SoftOptStatus);
            }
            catch (Exception ex)
            {
                WriteNGMsg(ex.Message, UserTheadStatus.SoftOptStatus, ex);
            }
        }

        private void btn_ZHome_Click(object sender, EventArgs e)
        {



        }

        private void cmb_TriggerModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 相机功能已移除
        }

        private void txt_SoftOptStatus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cms_ClearInfo.Show(txt_SoftOptStatus, e.Location);
            }
        }

        private void toolStripMenuItem_ClearInfo_Click(object sender, EventArgs e)
        {
            txt_SoftOptStatus.Text = string.Empty;
        }



        private void timer_Home_Tick(object sender, EventArgs e)
        {
            // 启动后检测回零完成状态
            if (_isAxisHomed && _initFinished && _deviceManager?.Motion?.IsConnected == true)
            {
                timer_Home.Enabled = false;
                SetMachineStatus(MachineStatus.Initialed);
            }
        }

        private void btn_AddCheckItem_Click(object sender, EventArgs e)
        {
            int index = dgv_CheckItem.RowCount;
            bool flag = true;
            foreach (DataGridViewRow item in dgv_CheckItem.Rows)
            {
                if ((string)item.Cells[2].Value == txt_ItemContent.Text.Trim())
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                dgv_CheckItem.Rows.Add(bool.Parse(cmb_ItemEnable.SelectedItem.ToString()), txt_ItemIndex.Text.Trim(), txt_ItemContent.Text.Trim());
            }
            else
            {
                WriteNGMsg("已存在该检测内容", UserTheadStatus.SoftOptStatus, new Exception());
            }
        }

        private void txt_AlarmInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cms_ClearInfo.Show(txt_SoftOptStatus, e.Location);
            }
        }



        /// <summary>
        /// 保存并显示检测记录
        /// </summary>
        /// <param name="isOK">检测结果 true=OK false=NG</param>
        /// <param name="ngReason">NG原因</param>
        private void SaveInspectionRecord(bool isOK, string ngReason = "", string productCode = "", string productColor = "")
        {
            var record = new CCDInspection.Core.Models.InspectionRecord
            {
                Time = DateTime.Now,
                Result = isOK ? "OK" : "NG",

                Reason = ngReason,
                ProductCode = productCode,
                ProductColor = productColor
            };

            _inspectionRecords.Add(record);

            if (_inspectionRecords.Count > 100)
                _inspectionRecords.RemoveAt(0);

            ShowInspectionResult(record);

            // 同步保存到 SQLite 数据库
            try
            {
                if (_db == null) { LogService.Error("[DB] _db为null"); return; }
                LogService.Debug("[DB] 准备插入...");
                var res = _db.Insert(new InspectionRecordEntity
                {
                    Time = record.Time,
                    ProductModel = _currentProduct.ProductName,
                    ProductPort = _currentProductPort,
                    ProductColor = record.ProductColor,
                    ProductCode = record.ProductCode,
                    Result = record.Result,
                    NgReason = record.Reason
                }).ExecuteAffrows();


                LogService.Debug("[DB] 写入成功");
            }
            catch (Exception ex) { LogService.Error(ex, "[DB] 保存记录失败"); }
        }

        private void ShowInspectionResult(CCDInspection.Core.Models.InspectionRecord record)
        {
            bool isOK = record.Result == "OK";
            string resultText = $"[{record.Time:HH:mm:ss}] 检测结果:{(isOK ? "OK" : "NG")} 颜色:{record.ProductColor}";

            if (!isOK && !string.IsNullOrEmpty(record.Reason))
                resultText += $" NG原因:{record.Reason.Replace("\n", " ").Replace("\r", " ")}";



            // 在gbTestResult的RichTextBox中显示
            if (rtb_TestResult.InvokeRequired)
            {
                rtb_TestResult.Invoke(new Action(() =>
                {
                    rtb_TestResult.AppendText(resultText + Environment.NewLine);
                    rtb_TestResult.ScrollToCaret();
                }));
            }
            else
            {
                rtb_TestResult.AppendText(resultText + Environment.NewLine);
                rtb_TestResult.ScrollToCaret();
            }
        }

        #region 数据库查询

        /// <summary>初始化 SQLite 数据库和 FreeSql</summary>
        private void InitDatabase()
        {
            try
            {
                var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Inspection.db");
                var dir = Path.GetDirectoryName(dbPath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                _db = new FreeSqlBuilder()
                    .UseConnectionString(FreeSql.DataType.Sqlite, $"Data Source={dbPath}")
                    .UseAutoSyncStructure(true)
                    .Build();
                // 仅在表不存在时同步，避免每次启动重建
                var tbl = _db.Ado.ExecuteScalar("select count(*) from sqlite_master where type='table' and name='InspectionRecordEntity'");
                if (tbl?.ToString() != "1")
                {
                    try { _db.CodeFirst.SyncStructure<InspectionRecordEntity>(); }
                    catch (Exception syncEx) { LogService.Error(syncEx, "[DB] 表结构同步失败"); _db.Dispose(); _db = null; return; }
                }
                LogService.Information("[DB] SQLite数据库初始化完成: {Path}", dbPath);
            }
            catch (Exception ex) { LogService.Error(ex, "[DB] 数据库初始化失败"); }
        }


        /// <summary>初始化数据库查询筛选控件 — 端口→型号→编码 三级联动 + 查询按钮</summary>
        private void InitDbFilterControls()
        {
            // 端口选择填充
            com_sqllPort.Items.Clear();
            if (_productModels != null)
            {
                var ports = _productModels.Select(p => p.Product_port).Distinct().ToList();
                foreach (var port in ports) com_sqllPort.Items.Add(port);
                if (com_sqllPort.Items.Count > 0) com_sqllPort.SelectedIndex = 0;
            }

            // 端口变化 → 筛选型号+编码
            com_sqllPort.SelectedIndexChanged += com_sqllPort_SelectedIndexChanged;
            // 型号变化 → 筛选编码
            cob_sqlProduct_model.SelectedIndexChanged += (s, e) => FilterDbProductCodes();

            // 手动触发一次
            if (com_sqllPort.Items.Count > 0)
                com_sqllPort_SelectedIndexChanged(com_sqllPort, EventArgs.Empty);

            // 查询/打印按钮由设计器绑定，不重复注册
            btn_open.Click += btn_open_Click;
        }

        private void com_sqllPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            cob_sqlProduct_model?.Items.Clear();
            com_product_code?.Items.Clear();
            var selPort = com_sqllPort.SelectedItem?.ToString() ?? "";
            if (_productModels == null) return;
            var models = _productModels
                .Where(p => p.Product_port == selPort)
                .Select(p => p.Product_model)
                .Distinct().ToList();
            foreach (var m in models) cob_sqlProduct_model.Items.Add(m);
            if (cob_sqlProduct_model.Items.Count > 0) cob_sqlProduct_model.SelectedIndex = 0;
        }

        /// <summary>根据端口+型号筛选编码</summary>
        private void FilterDbProductCodes()
        {
            if (com_product_code == null) return;
            com_product_code.Items.Clear();
            var selPort = com_sqllPort.SelectedItem?.ToString() ?? "";
            var selModel = cob_sqlProduct_model.SelectedItem?.ToString() ?? "";
            if (_productModels == null) return;
            var codes = _productModels
                .Where(p => p.Product_port == selPort && p.Product_model == selModel)
                .Select(p => p.Product_code)
                .Distinct().ToList();
            foreach (var c in codes) com_product_code.Items.Add(c);
            if (com_product_code.Items.Count > 0) com_product_code.SelectedIndex = 0;
        }

        /// <summary>查询按钮 — 根据筛选条件从 SQLite 查询并填充 dataGridView1</summary>
        private void sql_select_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_db == null) { LogService.Error("[DB] 查询失败: _db为null"); MessageBox.Show("数据库未初始化"); return; }

                var query = _db.Select<InspectionRecordEntity>();

                // 时间范围（勾选时启用）
                if (ckb_enbalestartTime.Checked || ckb_enableendtime.Checked)
                {
                    var dateFrom = ckb_enbalestartTime.Checked ? dateTimePicker1.Value.Date : DateTime.MinValue;
                    var dateTo = ckb_enableendtime.Checked ? dateTimePicker2.Value.Date.AddDays(1) : DateTime.MaxValue;
                    query = query.Where(r => r.Time >= dateFrom && r.Time < dateTo);
                }
                // 端口选择（勾选时启用）
                if (ckb_enableProt.Checked)
                {
                    var port = com_sqllPort.SelectedItem?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(port))
                        query = query.Where(r => r.ProductPort == port);
                }
                // 产品类型（勾选时启用）
                if (ckb_enableType.Checked)
                {
                    var model = cob_sqlProduct_model.SelectedItem?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(model))
                        query = query.Where(r => r.ProductModel == model);
                }
                // 产品编码（勾选时启用）
                if (ckb_enbalecode.Checked)
                {
                    var code = com_product_code.SelectedItem?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(code))
                        query = query.Where(r => r.ProductCode == code);
                }

                var list = query.OrderByDescending(r => r.Time).Take(5000).ToList();
                dataGridView1.Rows.Clear();
                foreach (var r in list)
                    dataGridView1.Rows.Add(
                        r.Time.ToString("yyyy-MM-dd HH:mm:ss"),
                        r.ProductModel ?? "",
                        r.ProductPort ?? "",
                        r.ProductColor ?? "",
                        r.ProductCode ?? "",
                        r.Result ?? "");
            }
            catch (Exception ex) { LogService.Error(ex, "[DB] 查询失败"); }
        }

        /// <summary>导出 dataGridView1 数据到 Excel 报表（NPOI .xlsx）</summary>
        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) { MessageBox.Show("无数据可导出"); return; }

                var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var file = Path.Combine(dir, $"检测报表_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

                var workbook = new XSSFWorkbook();
                var sheet = workbook.CreateSheet("检测记录");
                int colCount = dataGridView1.Columns.Count;

                // ═══ 字体 ═══
                var titleFont = workbook.CreateFont();
                titleFont.FontHeightInPoints = 16;
                titleFont.IsBold = true;
                titleFont.Color = IndexedColors.DarkBlue.Index;

                var headerFont = workbook.CreateFont();
                headerFont.IsBold = true;
                headerFont.FontHeightInPoints = 11;
                headerFont.Color = IndexedColors.White.Index;

                var dataFont = workbook.CreateFont();
                dataFont.FontHeightInPoints = 10;

                var okFont = workbook.CreateFont();
                okFont.FontHeightInPoints = 10;
                okFont.Color = IndexedColors.DarkGreen.Index;
                okFont.IsBold = true;

                var ngFont = workbook.CreateFont();
                ngFont.FontHeightInPoints = 10;
                ngFont.Color = IndexedColors.Red.Index;
                ngFont.IsBold = true;

                // ═══ 样式 ═══
                var titleStyle = workbook.CreateCellStyle();
                titleStyle.SetFont(titleFont);
                titleStyle.Alignment = NpoiAlign.Center;
                titleStyle.VerticalAlignment = VerticalAlignment.Center;

                var headerStyle = workbook.CreateCellStyle();
                headerStyle.SetFont(headerFont);
                headerStyle.FillForegroundColor = IndexedColors.DarkBlue.Index;
                headerStyle.FillPattern = FillPattern.SolidForeground;
                headerStyle.Alignment = NpoiAlign.Center;
                headerStyle.VerticalAlignment = VerticalAlignment.Center;
                headerStyle.BorderBottom = NpoiBorder.Thin;
                headerStyle.BorderTop = NpoiBorder.Thin;
                headerStyle.BorderLeft = NpoiBorder.Thin;
                headerStyle.BorderRight = NpoiBorder.Thin;

                var evenStyle = workbook.CreateCellStyle();
                evenStyle.SetFont(dataFont);
                evenStyle.FillForegroundColor = IndexedColors.LightTurquoise.Index;
                evenStyle.FillPattern = FillPattern.SolidForeground;
                evenStyle.BorderBottom = NpoiBorder.Thin;
                evenStyle.BorderTop = NpoiBorder.Thin;
                evenStyle.BorderLeft = NpoiBorder.Thin;
                evenStyle.BorderRight = NpoiBorder.Thin;

                var oddStyle = workbook.CreateCellStyle();
                oddStyle.SetFont(dataFont);
                oddStyle.BorderBottom = NpoiBorder.Thin;
                oddStyle.BorderTop = NpoiBorder.Thin;
                oddStyle.BorderLeft = NpoiBorder.Thin;
                oddStyle.BorderRight = NpoiBorder.Thin;

                var okStyle = workbook.CreateCellStyle();
                okStyle.SetFont(okFont);
                okStyle.FillForegroundColor = IndexedColors.LightGreen.Index;
                okStyle.FillPattern = FillPattern.SolidForeground;
                okStyle.Alignment = NpoiAlign.Center;
                okStyle.BorderBottom = NpoiBorder.Thin;
                okStyle.BorderTop = NpoiBorder.Thin;
                okStyle.BorderLeft = NpoiBorder.Thin;
                okStyle.BorderRight = NpoiBorder.Thin;

                var ngStyle = workbook.CreateCellStyle();
                ngStyle.SetFont(ngFont);
                ngStyle.FillForegroundColor = IndexedColors.Rose.Index;
                ngStyle.FillPattern = FillPattern.SolidForeground;
                ngStyle.Alignment = NpoiAlign.Center;
                ngStyle.BorderBottom = NpoiBorder.Thin;
                ngStyle.BorderTop = NpoiBorder.Thin;
                ngStyle.BorderLeft = NpoiBorder.Thin;
                ngStyle.BorderRight = NpoiBorder.Thin;

                int rowIdx = 0;

                // ═══ 标题行 ═══
                var titleRow = sheet.CreateRow(rowIdx++);
                titleRow.HeightInPoints = 30;
                var titleCell = titleRow.CreateCell(0);
                titleCell.SetCellValue("CCD 视觉检测报表");
                titleCell.CellStyle = titleStyle;
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, colCount - 1));

                // ═══ 信息行 ═══
                var infoRow = sheet.CreateRow(rowIdx++);
                infoRow.HeightInPoints = 20;
                var infoCell = infoRow.CreateCell(0);
                var infoStyle = workbook.CreateCellStyle();
                infoStyle.Alignment = NpoiAlign.Left;
                infoStyle.SetFont(dataFont);
                infoCell.CellStyle = infoStyle;
                infoCell.SetCellValue($"导出时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}    筛选条件: 端口={com_sqllPort.Text} 型号={cob_sqlProduct_model.Text} 编码={com_product_code.Text} 日期={dateTimePicker1.Value:yyyy-MM-dd} ~ {dateTimePicker2.Value:yyyy-MM-dd}");
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(rowIdx - 1, rowIdx - 1, 0, colCount - 1));

                // 空一行
                rowIdx++;

                // ═══ 表头行 ═══
                var headerRow = sheet.CreateRow(rowIdx++);
                headerRow.HeightInPoints = 24;
                for (int i = 0; i < colCount; i++)
                {
                    var cell = headerRow.CreateCell(i);
                    cell.SetCellValue(dataGridView1.Columns[i].HeaderText);
                    cell.CellStyle = headerStyle;
                }

                // ═══ 数据行 ═══
                int dataStart = rowIdx;
                foreach (DataGridViewRow gridRow in dataGridView1.Rows)
                {
                    if (gridRow.IsNewRow) continue;
                    var excelRow = sheet.CreateRow(rowIdx);
                    excelRow.HeightInPoints = 18;
                    bool isOk = false;
                    for (int j = 0; j < gridRow.Cells.Count; j++)
                    {
                        var val = gridRow.Cells[j].Value?.ToString() ?? "";
                        var cell = excelRow.CreateCell(j);
                        cell.SetCellValue(val);
                        // 结果列 (最后一列) 特殊着色
                        if (j == colCount - 1)
                        {
                            isOk = val == "OK";
                            cell.CellStyle = isOk ? okStyle : ngStyle;
                        }
                        else
                        {
                            cell.CellStyle = (rowIdx - dataStart) % 2 == 0 ? evenStyle : oddStyle;
                        }
                    }
                    rowIdx++;
                }

                // ═══ 列宽 ═══
                for (int i = 0; i < colCount; i++)
                {
                    sheet.AutoSizeColumn(i);
                    int width = sheet.GetColumnWidth(i);
                    sheet.SetColumnWidth(i, Math.Min(width + 1024, 65280)); // +256px 边距, 最大255字符
                }

                // ═══ 冻结表头 ═══
                sheet.CreateFreezePane(0, dataStart);

                using (var fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                    workbook.Write(fs);

                LogService.Information("[报表] 导出成功: {File}", file);
                MessageBox.Show($"导出成功: {file}", "报表导出");
                Process.Start(file);
            }
            catch (Exception ex) { LogService.Error(ex, "[报表] 导出失败"); MessageBox.Show($"导出失败: {ex.Message}"); }
        }

        /// <summary>打开报表文件夹</summary>
        private void btn_open_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                System.Diagnostics.Process.Start("explorer.exe", dir);
            }
            catch (Exception ex) { LogService.Error(ex, "[报表] 打开文件夹失败"); }
        }

        #endregion




        /// <summary>从 ProductConfig.json 加载产品数据到 dataGridView3</summary>
        private void LoadProductGrid()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "ProductConfig.json");
                if (!File.Exists(path)) return;
                var json = File.ReadAllText(path);
                _productModels = JsonConvert.DeserializeObject<List<ProductModel>>(json) ?? new List<ProductModel>();
                dataGridView3.Rows.Clear();
                foreach (var p in _productModels)
                {
                    int idx = dataGridView3.Rows.Add(
                        p.Product_model ?? "",
                        p.Product_port ?? "",
                        p.Product_color ?? "",
                        p.Product_code ?? "",
                        p.Product_zHeight ?? "20");
                }
            }
            catch (Exception ex) { LogService.Error(ex, "加载产品配方失败"); }
        }

        /// <summary>初始化产品下拉框 — 从 ProductConfig.json 加载</summary>
        /// <summary>初始化产品下拉框 — cob_ProductType筛选 + comboBox1显示</summary>
        private void InitProductCombo()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "ProductConfig.json");
                if (!File.Exists(path)) return;
                var json = File.ReadAllText(path);
                _productModels = JsonConvert.DeserializeObject<List<ProductModel>>(json) ?? new List<ProductModel>();

                // 端口类型下拉（公端/母端）
                cob_ProductType.Items.Clear();
                var ports = _productModels.Select(p => p.Product_port).Distinct().ToList();
                foreach (var port in ports) cob_ProductType.Items.Add(port);
                if (cob_ProductType.Items.Count > 0) cob_ProductType.SelectedIndex = 0;

                // cob_ProductType 变化时筛选 comboBox1
                cob_ProductType.SelectedIndexChanged += (s, e) => FilterProductList();
                com_productcode.SelectedIndexChanged += (s, e) => LoadVmCOde();

                FilterProductList();
            }
            catch { }
        }
        //这里根据产品硬编码来加载确保 相同端口 相同颜色 不会加载错误
        private void LoadVmCOde()
        {
            if (!_initFinished) return;
            var code = com_productcode.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(code)) return;

            // 安全状态检查
            if (_stationController?.CurrentState != StationState.Idle)
            {
                WriteMsg("请在空闲状态下切换方案", UserTheadStatus.SoftOptStatus);
                if (!string.IsNullOrEmpty(_currentProductCode))
                {
                    var idx = com_productcode.Items.Cast<string>().ToList().IndexOf(_currentProductCode);
                    if (idx >= 0) com_productcode.SelectedIndex = idx;
                }
                return;
            }

            var port = cob_ProductType.SelectedItem?.ToString() ?? _currentProductPort;
            // 通过编码查找产品
            var prod = _productModels?.FirstOrDefault(p => p.Product_code == code && p.Product_port == port);
            if (prod == null) return;

            _currentProductCode = code;
            _currentProductPort = prod.Product_port;
            _currentProductModel = prod.Product_model;
            _currentProductColor = prod.Product_color;
            lbl_currentCode.Text = code;
            UpdateCurrentProduct(prod.Product_port, prod.Product_model, prod);
            LoadRecipeInfo(prod.Product_port, prod.Product_model, code);
            WriteMsg($"已切换方案: {code}", UserTheadStatus.SoftOptStatus);
        }

        private void FilterProductList()
        {
            if (_productModels == null) return;
            var filter = cob_ProductType.SelectedItem?.ToString() ?? _currentProductPort ?? "";
            comboBox1.Items.Clear();
            var filtered = string.IsNullOrEmpty(filter)
                ? _productModels
                : _productModels.Where(p => p.Product_port == filter).ToList();
            foreach (var c in filtered.Select(p => p.Product_color).Distinct())
                comboBox1.Items.Add(c);
            // 选中当前产品
            if (!string.IsNullOrEmpty(_currentProductPort) && !string.IsNullOrEmpty(_currentProductModel))
            {
                var cur = $"{_currentProductPort}-{_currentProductModel}";
                var idx = comboBox1.Items.Cast<string>().ToList().IndexOf(cur);
                if (idx >= 0) comboBox1.SelectedIndex = idx;
            }
        }

        /// <summary>切换产品方案 — 安全状态下才能切换，切换后轴移到配方高度</summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_productModels == null) return;
            var sel = comboBox1.SelectedItem?.ToString()??"";
            com_productcode.Items.Clear();
            var portFilter = cob_ProductType.SelectedItem?.ToString() ?? _currentProductPort ?? "";
            var filterd = string.IsNullOrEmpty(sel) ? _productModels : _productModels.Where(p => p.Product_color == sel && p.Product_port == portFilter).ToList();
            foreach (var p in filterd) com_productcode.Items.Add(p.Product_code);


            // 选中当前产品
            if (!string.IsNullOrEmpty(_currentProductPort) && !string.IsNullOrEmpty(_currentProductColor))
            {
                var cur =_currentProductCode;
                var idx = com_productcode.Items.Cast<string>().ToList().IndexOf(cur);
                if (idx >= 0) com_productcode.SelectedIndex = idx;
            }
            lbl_currentCode.Text = com_productcode.SelectedItem?.ToString() ?? "";

        }

        /// <summary>统一加载配方信息和VM方案 — 登录和切换共用</summary>
        /// <summary>更新当前产品信息（供登录和切换方案时调用）</summary>
        private void UpdateCurrentProduct(string port, string model, ProductModel prod)
        {
            _currentProduct.ProductName = model;
            _currentProduct.ProductIndex = prod?.Product_code ?? _currentProductCode ?? "?";
            _currentProduct.ProductColor = prod?.Product_color ?? "";
            _currentProduct.ZHeight = float.TryParse(prod?.Product_zHeight, out var zh) ? zh : 0f;
        }

        public void LoadRecipeInfo(string port, string model, string code = null)
        {
            // 1. 读产品Z高度 + 获取产品编码 → Z轴移动
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "ProductConfig.json");
            List<ProductModel> list = null;
            if (File.Exists(path))
            {
                list = JsonConvert.DeserializeObject<List<ProductModel>>(File.ReadAllText(path));
                var p = list?.FirstOrDefault(x => x.Product_model == model && x.Product_port == port);
                if (p != null && float.TryParse(p.Product_zHeight, out float zh) && zh != 0)
                {
                    var cfgSvc = new ConfigService();
                    var cfg = cfgSvc.Load();
                    cfg.Inspection.DetectZHeight = zh;
                    cfgSvc.Save(cfg);
                    LogService.Information("[配方加载] {Port}-{Model} | Z高度={Z:F1}mm", port, model, zh);
                    _deviceManager?.Motion?.ZAxis?.MoveAbs(zh);
                }
            }

            // 2. 通过编码前缀搜索VM方案文件并加载
            vmRenderControl1.ModuleSource = null;
            var searchCode = code ?? list?.FirstOrDefault(x => x.Product_model == model && x.Product_port == port)?.Product_code ?? model;
            var solDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VmSol", port);
            if (!Directory.Exists(solDir)) { LogService.Warning("[配方加载] VM方案目录不存在: {Dir}", solDir); lbl_currentCode.Text = "方案目录缺失"; return; }
            var solFiles = Directory.GetFiles(solDir, searchCode + "*.sol");
            if (solFiles.Length == 0) { LogService.Warning("[配方加载] VM方案不存在, 编码={Code}", searchCode); lbl_currentCode.Text = $"{searchCode}-方案缺失"; return; }
            var solPath = solFiles[0];
            LogService.Information("[配方加载] VM方案路径: {Path}", solPath);
            try
            {
                var oldDir = Environment.CurrentDirectory;
                Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                VmSolution.Load(solPath, "", false);
                Environment.CurrentDirectory = oldDir;
                System.Threading.Thread.Sleep(200);
                VmProcedure proc = VmSolution.Instance["流程1"] as VmProcedure;
                if (proc != null) vmRenderControl1.ModuleSource = proc;
                if (_deviceManager.Vision is VmVisionProcessor vmVision)
                    vmVision.SetProcedure(proc);
                LogService.Information("[配方加载] VM方案已加载: {Path}", solPath);
            }
            catch (Exception ex) { LogService.Error(ex, "[配方加载] VM方案加载异常"); }
        }

        private void Begin_AddPlcPoint_Btm_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button temp_button = (System.Windows.Forms.Button)sender;
                switch (temp_button.Name)
                {

                    case "Begin_AddPoint_Btm":
                        dataGridView3.AllowUserToAddRows = true;
                        break;
                    case "Btn_DelConfig":
                        if (dataGridView3.SelectedRows.Count > 0)
                        {
                            // 从最大的行索引开始，防止索引变化影响循环
                            for (int i = dataGridView3.SelectedRows.Count - 1; i >= 0; i--)
                            {
                                // 获取当前选中行的索引
                                int index = dataGridView3.SelectedRows[i].Index;
                                // 删除选中行
                                dataGridView3.Rows.RemoveAt(index);
                            }
                        }
                        break;

                    case "SaveData_Button":
                        dataGridView3.AllowUserToAddRows = false;
                        _productModels = new List<ProductModel>();
                        for (int i = 0; i < dataGridView3.RowCount; i++)
                        {
                            DataGridViewRow row = dataGridView3.Rows[i];
                            if (row.IsNewRow) continue;
                            var model = row.Cells[0].Value?.ToString() ?? "";
                            var port = row.Cells[1].Value?.ToString() ?? "";
                            var color = row.Cells[2].Value?.ToString() ?? "";
                            var code = row.Cells[3].Value?.ToString() ?? "";
                            var zH = row.Cells.Count > 4 ? row.Cells[4].Value?.ToString() ?? "20" : "20";
                            _productModels.Add(new ProductModel
                            {
                                Product_model = model,
                                Product_port = port,
                                Product_color = color,
                                Product_code = code,
                                Product_zHeight = zH
                            });
                        }
                        // 全量写入一次，不再每行重复写
                        var json = JsonConvert.SerializeObject(_productModels,Formatting.Indented);
                        var configDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
                        if (!Directory.Exists(configDir)) Directory.CreateDirectory(configDir);
                        File.WriteAllText(Path.Combine(configDir, "ProductConfig.json"), json);
                        MessageBox.Show("数据保存成功！");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作异常:{ex.Message}");
            }
        }



        private void btn_DeleteCheckItem_Click(object sender, EventArgs e)
        {
            if (dgv_CheckItem.SelectedRows.Count == 1)
            {
                int index = dgv_CheckItem.SelectedIndex;
                //listView_Product.Items.RemoveAt(index);
                dgv_CheckItem.Rows.RemoveAt(index);
            }
        }

        private void btn_SaveCheckItem_Click(object sender, EventArgs e)
        {
            try
            {
                _checkItemsConfig.m_CheckItems.Clear();
                for (int i = 0; i < dgv_CheckItem.RowCount; i++)
                {
                    CheckItem ci = new CheckItem();
                    ci.ItemEnable = (bool)dgv_CheckItem.Rows[i].Cells["Column1"].Value;
                    ci.ItemIndex = int.Parse(dgv_CheckItem.Rows[i].Cells[1].Value.ToString());
                    ci.ItemContent = dgv_CheckItem.Rows[i].Cells[2].Value.ToString();
                    _checkItemsConfig.m_CheckItems.Add(ci);
                }

                if (_checkItemsConfig.SaveData(_checkItemPath))
                {
                    WriteMsg("拦截项文件成功", UserTheadStatus.SoftOptStatus);
                    dgv_CheckItem.Rows.Clear();

                }
                else
                {
                    WriteNGMsg("保存拦截项文件文件失败", UserTheadStatus.SoftOptStatus, new Exception());
                }
            }
            catch (Exception ex)
            {
                WriteNGMsg(ex.Message, UserTheadStatus.SoftOptStatus, ex);
            }
        }



        private void dgv_PathPlan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_initFinished)
            {
                return;
            }
            try
            {
                BinarySerializer.Serialize<PositionConfig>(_positionConfig, _positionsPath);
            }
            catch (Exception ex)
            {
                WriteNGMsg(ex.Message, UserTheadStatus.SoftOptStatus, ex);
            }
        }


        #endregion

        #region 公共方法

        public static T DeepCopy<T>(T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                //序列化成流
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                //反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;

        }

        #endregion

        #region 线程安全辅助方法
        private void SafeInvoke(Action action)
        {
            if (this.InvokeRequired)
                this.Invoke(action);
            else
                action();


        }

        /// <summary>
        /// 屏蔽蜂鸣器报警（如果有）在特定条件下触发，避免持续报警干扰操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckb_ShieldBuzzer_CheckedChanged(object sender, EventArgs e) => SaveOptionalConfig();
        private void ckb_ShieldLightCurtain_CheckedChanged(object sender, EventArgs e) => SaveOptionalConfig();
        private void ckb_CylinderShield_CheckedChanged(object sender, EventArgs e) => SaveOptionalConfig();
        private void ckb_SaveSourceImage_CheckedChanged(object sender, EventArgs e) => SaveOptionalConfig();
        private void ckb_SaveNGSourceImage_CheckedChanged(object sender, EventArgs e) => SaveOptionalConfig();
        private void ckb_CameraShieldI_CheckedChanged(object sender, EventArgs e) => SaveOptionalConfig();

        private void uiTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 测试按钮，预留接口，暂时无功能
        /// </summary
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_db == null) { LogService.Error("[DB] 测试查询失败: _db为null"); MessageBox.Show("数据库未初始化"); return; }

                var all = _db.Select<InspectionRecordEntity>().Take(1000).ToList();
                var msg = $"总记录数: {all.Count}\n";
                if (all.Count > 0)
                {
                    // 显示第一条的列名和值
                    var first = all[0];
                    msg += $"Id={first.Id}\n";
                    msg += $"Time={first.Time}\n";
                    msg += $"ProductModel={first.ProductModel}\n";
                    msg += $"ProductPort={first.ProductPort}\n";
                    msg += $"ProductColor={first.ProductColor}\n";
                    msg += $"ProductCode={first.ProductCode}\n";
                    msg += $"Result={first.Result}\n";

                }
                MessageBox.Show(msg, "测试查询");
            }
            catch (Exception ex) { MessageBox.Show($"查询失败: {ex.Message}"); }
        }

        private void btn_print_Click_1(object sender, EventArgs e)
        {
            btn_print_Click(sender, e);
        }



        /// <summary>
        /// 清楚当前计数，
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearCurrentCount_Click(object sender, EventArgs e)
        {
            _statsService?.ClearCurrent();
            UpdateStatsUI(_statsService?.Current);
            if (txt_CurrentCheckTime != null)
                txt_CurrentCheckTime.Text = "0 ms";
        }



          //清楚总计数
        private void btn_ClearTotalCount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清除全部计数?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.OK)
            {
                _statsService?.ClearAll();
                UpdateStatsUI(_statsService?.Current);
            }
        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }
        //添加视觉方案
        private void btn_addvm_Click(object sender, EventArgs e)
        {
            // 现在当前视觉方案 解除相机占用
            //vmRenderControl1.ModuleSource = null;

            //打开窗口
            using (FrmVM frmVM = new FrmVM())
            {
                frmVM.DeviceManager = _deviceManager;
                frmVM.ShowDialog(this);
            }

            //加载当前视觉方案 //恢复 视觉
            if (!string.IsNullOrEmpty(_currentProductPort))
                LoadRecipeInfo(_currentProductPort, _currentProductModel, _currentProductCode);
        }

        private void SafeBeginInvoke(Action action)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(action);
            else
                action();
        }
        #endregion
    }

}
