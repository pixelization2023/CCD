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
using CCDInspection.Device.Camera;
using CCDInspection.Device.IO;
using CCDInspection.Device.Vision;
using CCDInspection.Core;
using CCDInspection.UI.Assisat;
using IVisionProcessor = CCDInspection.Core.Interfaces.Hardware.IVisionAnalyzer;
using VMControls.Winform.Release.ExportControl;
using Sunny.UI;

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

        public string _operatorId;
        public string _currentUser;

        ProductTypeConfig.ProductType _currentProduct;//当前产品型号
        string _productIndex;
        List<InspectionRecord> _inspectionRecords = new List<InspectionRecord>();//检测记录
        System.Drawing.Bitmap[] images = new System.Drawing.Bitmap[3];
        int index;
        Stopwatch sw = new Stopwatch();
        string[] _imageFiles;


        PositionConfig _positionConfig;//位置配置
        public MyBaseCamera _camera = null;//相机对象
        MyCameraInfo _cameraInfo = null;//相机信息
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
                LogService.Information("[初始化] ====== FrmMain加载开始 ======");

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
                LogService.Information("[初始化] 配置加载完成 | AxisIP={IP} | CameraSN={SN}",
 _config.Axis.IpAddress, _config.Camera.SerialNumber);

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

                // 关键：使用 DI 中已连接的 ZmcController / HkCamera，不重新 InitializeAll
                IMotionController motion;
                ICamera camera;
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
                    camera = CompositionRoot.Resolve<ICamera>();
                }
                catch
                {
                    camera = new HkCamera(_config.Camera); camera.Connect();
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
                    Camera = camera,
                    Vision = vision
                };

                // 配置轴参数（ZmcController 已在 DI 中完成连接，这里只配轴不重复连接）
                motion.ConfigureAxis(0, _config.Axis);
                LogService.Information("[初始化] DeviceManager就绪 | Motion={M} Camera={C} Vision={V}",
                    motion.IsConnected, camera.IsConnected, vision.IsLoaded);

                SetMachineStatus(MachineStatus.Initial);

                // 3. 初始化状态机
                LogService.Information("[初始化] 步骤3 创建状态机...");
                var cylinder = new Cylinder(motion,
                    IOMapping.OUT_Cylinder, IOMapping.IN_CylinderExtendOk, IOMapping.IN_CylinderRetractOk);
                // AlarmHandler 必须用 FrmMain 自己的 DeviceManager，不能从 DI 拿（DI 里的 DeviceManager 设备为空）

                var alarmHandler = new AlarmHandler(_deviceManager);


                var lightCurtain = new LightCurtain(motion, IOMapping.IN_LightCurtain);
                _deviceManager.Alarm = alarmHandler;
                _deviceManager.LightCurtain = lightCurtain;
                lightCurtain.StartMonitoring();
                _stationController = new StationController(
                    motion, camera, vision,
                    cylinder, alarmHandler, lightCurtain, _statsService, _config, _configService);
                _stationController.OnInspectionCompleted += record =>
                    SafeBeginInvoke(() =>
                    {
                        lbl_TotalResult.Text = record.Result;
                        lbl_TotalResult.BackColor = record.Result == "OK" ? Color.LightGreen : Color.Red;
                        UpdateStatsUI(_statsService.Current);
                    });
                _stationController.OnStatusChanged += msg =>
                    SafeBeginInvoke(() =>
                    {
                        WriteMsg(msg, UserTheadStatus.SoftOptStatus);
                        if (msg.Contains("复位中"))
                            SetThreeColorLight(MachineStatus.Initial);
                        else if (msg.Contains("复位完成"))
                        {
                            _isAxisHomed = true;
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
                ckb_CameraShieldI.Checked = f.ShieldCamera;
                ckb_ShieldBuzzer.Checked = f.ShieldBuzzer;
                _shieldBuzzerCached = f.ShieldBuzzer;
                ckb_ShieldLightCurtain.Checked = f.ShieldLightCurtain;
                ckb_CylinderShield.Checked = f.ShieldCylinder;
                ckb_SaveSourceImage.Checked = f.SaveOkImage;
                ckb_SaveNGSourceImage.Checked = f.SaveNgImage;
    
                _ioInputs = new IO_In[] { iO_In0, iO_In1, iO_In2, iO_In3, iO_In4, iO_In5, iO_In6, iO_In7, iO_In8, iO_In9, iO_In10, iO_In11, iO_In12, iO_In13, iO_In14, iO_In15 };
                _ioOutputs = new IO_Out[] { iO_Out0, iO_Out1, iO_Out2, iO_Out3, iO_Out4, iO_Out5, iO_Out6, iO_Out7, iO_Out8, iO_Out9, iO_Out10, iO_Out11, iO_Out12, iO_Out13, iO_Out14, iO_Out15 };
                string[] inNames = { "门禁", "设备启动", "急停", "复位", "气缸伸出到位", "气缸缩回到位", "保留", "流程启动", "停止", "IN9", "IN10", "IN11", "IN12", "IN13", "IN14", "IN15" };
                string[] outNames = { "电磁阀", "OUT1", "光源COM123", "光源COM4", "OUT4", "黄灯", "绿灯", "红灯", "蜂鸣器", "OUT9", "OUT10", "OUT11", "OUT12", "OUT13", "OUT14", "OUT15" };
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

                // 7. 连接相机
                LogService.Information("[初始化] 步骤6 连接相机...");
                if (!InitialCamera()) { _initSuccess = false; LogService.Error("[初始化] 相机连接失败"); }
                else LogService.Information("[初始化] 相机连接成功");

                cmb_CameraSet.SelectedIndex = 0;
                cmb_TriggerModel.SelectedIndex = 0;
                if (_buzzerThread?.ThreadState != System.Threading.ThreadState.Running)
                {
                    _buzzerThread = new Thread(new ThreadStart(Buzzer)) { IsBackground = true };
                    _buzzerThread.Start();
                }
                if (uiTabControl1 != null)
                {
                    uiTabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                }

                _initFinished = true;
                _initSuccess = true;
                // 开机保持红灯（安全状态），等待用户手动复位后才变绿灯
                SetMachineStatus(MachineStatus.SoftwareOpen);
                CheckSafeStartupCondition();
                _stationController.StartIdlePolling(); // 窗口就绪后才启动硬件IO轮询
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
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            LogService.Information("[AutoSize] OnResizeEnd W={W} H={H} oldCtrl={Cnt}", this.Width, this.Height, _autoSize.oldCtrl.Count);
            _autoSize.controlAutoSize(this);
        }
        private void FrmMain_ResizeEnd(object sender, EventArgs e) { } // Designer reference
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
            switch (status)
            {
                case MachineStatus.Alarm:
                    red = true;
                    buzz = true;
                    text = "机台报警中";
                    color = Color.Red;
                    _buzzerEnabled = true;
                    break;
                case MachineStatus.Initial:
                    yellow = true;
                    text = "机台初始化中...";
                    color = Color.LightYellow;
                    _buzzerEnabled = false;
                    break;
                case MachineStatus.Initialed:
                    green = true;
                    text = "机台初始化完成";
                    color = Color.LightGreen;
                    _buzzerEnabled = false;
                    break;
                case MachineStatus.Start:
                    green = true;
                    text = "机台运行中";
                    color = Color.LightGreen;
                    _buzzerEnabled = false;
                    break;
                case MachineStatus.Stop:
                    red = true;
                    text = "机台已停止";
                    color = Color.Red;
                    _buzzerEnabled = false;
                    break;
                default:
                    red = true;
                    text = "软件打开未初始化，请勿启动";
                    color = Color.Red;
                    break;
            }

            bool buzzerShielded = _configService?.Load()?.Features?.ShieldBuzzer ?? false;
            _deviceManager?.SetTowerLight(green, red, yellow, buzz && !buzzerShielded);

            // 修复：使用 SafeInvoke
            SafeInvoke(() =>
            {
                lbl_MachineStatus.Text = text;
                lbl_MachineStatus.BackColor = color;
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
            f.ShieldCamera = ckb_CameraShieldI.Checked;
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
            // 从 UI 控件读取参数 → 写入 JSON → 同步到 DI 的 HkCamera
            var config = _configService?.Load() ?? new AppConfig();
            var cam = config.Camera;
            cam.SerialNumber = txt_CameraSN1.Text.Trim();
            cam.ExposureTime = Convert.ToInt32(txt_Exposure.Text.Trim());
            cam.Gain = Convert.ToInt32(txt_Gain.Text.Trim());
            var triggerText = cmb_TriggerModel.SelectedItem?.ToString() ?? "软触发";
            if (triggerText.Contains("硬触发")) cam.TriggerMode = CCDInspection.Core.Enums.TriggerMode.Hardware;
            else if (triggerText.Contains("连续")) cam.TriggerMode = CCDInspection.Core.Enums.TriggerMode.Continuous;
            else cam.TriggerMode = CCDInspection.Core.Enums.TriggerMode.Software;

            _configService?.Save(config);
            // 同步到 DI 的 HkCamera（StationController 实际使用的）
            var diCamera = _deviceManager?.Camera as HkCamera;
            if (diCamera != null)
            {
                diCamera.Config = config.Camera;
                diCamera.ApplyConfig();
            }
            LogService.Information("[相机] 参数已保存 SN={SN} Exp={Exp} Gain={Gain} Trig={Trig}",
                cam.SerialNumber, cam.ExposureTime, cam.Gain, cam.TriggerMode);
        }

        private bool InitialCamera()
        {
            try
            {
                var camCfg = _configService?.Load()?.Camera ?? new CCDInspection.Core.Models.CameraConfig();
                _cameraInfo = new MyCameraInfo(camCfg.SerialNumber)
                {
                    ExposeTime = camCfg.ExposureTime,
                    Gain = camCfg.Gain,
                    TrigerModel = camCfg.TriggerMode == CCDInspection.Core.Enums.TriggerMode.Software ? MyTriger.Software : MyTriger.External
                };
                _camera = new MyHKCamera(_cameraInfo);
                if (!_camera.Connect())
                {
                    WriteNGMsg("相机连接失败", UserTheadStatus.Initial, new Exception());
                    return false;
                }
                WriteMsg("相机连接成功", UserTheadStatus.Initial);
                ConfigToUICamera();
                AddCameraEvent();
                return true;
            }
            catch (Exception ex)
            {
                WriteNGMsg("相机初始化失败" + ex.Message, UserTheadStatus.Initial, ex);
                return false;
            }
        }



        private void ConfigToUICamera()
        {
            txt_CameraSN1.Text = _cameraInfo.SerialNumber;
            txt_Exposure.Text = _cameraInfo.ExposeTime.ToString();
            txt_Gain.Text = _cameraInfo.Gain.ToString();
            if (_cameraInfo.TrigerModel == MyTriger.External)
            {
                for (int i = 0; i < cmb_TriggerModel.Items.Count; i++)
                {
                    if (cmb_TriggerModel.Items[i].ToString() == "硬触发")
                    {
                        cmb_TriggerModel.SelectedIndex = i;
                    }
                }
            }
            else if (_cameraInfo.TrigerModel == MyTriger.Software)
            {
                for (int i = 0; i < cmb_TriggerModel.Items.Count; i++)
                {
                    if (cmb_TriggerModel.Items[i].ToString() == "软触发")
                    {
                        cmb_TriggerModel.SelectedIndex = i;
                    }
                }
            }
            else if (_cameraInfo.TrigerModel == MyTriger.Continue)
            {
                for (int i = 0; i < cmb_TriggerModel.Items.Count; i++)
                {
                    if (cmb_TriggerModel.Items[i].ToString() == "连续触发")
                    {
                        cmb_TriggerModel.SelectedIndex = i;
                    }
                }
            }
            switch_Gama.Active = _cameraInfo.Gamable ? true : false;
            txt_Gama.Text = _cameraInfo.Gama.ToString();
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
            try
            {
                txt_ManualSpeed.Text = cfg.ManualSpeed.ToString();
                txt_PulseEquivalent.Text = cfg.PulseEquivalent.ToString();
                txt_AutoSpeed.Text = cfg.AutoSpeed.ToString();
                txt_Acceleration.Text = cfg.Acceleration.ToString();
                txt_Deceleration.Text = cfg.Deceleration.ToString();
                txt_PositiveSoftLimit.Text = cfg.PositiveSoftLimit.ToString();
                txt_NegativeSoftLimit.Text = cfg.NegativeSoftLimit.ToString();
                txt_HomeSpeed.Text = cfg.HomeSpeed.ToString();
                txt_SlowSpeed.Text = cfg.CreepSpeed.ToString();
                txt_PositivePoint.Text = cfg.PosLimitIo.ToString();
                txt_NegtivePoint.Text = cfg.NegLimitIo.ToString();
                txt_OriginPoint.Text = cfg.OriginIo.ToString();
                txt_AlarmPoint.Text = cfg.AlarmIo.ToString();
                for (int i = 0; i < cmb_HomeModel.Items.Count; i++)
                    if (Convert.ToInt32(cmb_HomeModel.Items[i].ToString()) == cfg.HomeModel)
                        cmb_HomeModel.SelectedIndex = i;
            }
            catch (Exception ex) { WriteNGMsg(ex.Message, UserTheadStatus.SoftOptStatus, ex); }
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
            AddCameraEvent();
            _isRunning = false;
            _isAutoRun = false;
            _transferTask?.Stop();
            Task.Run(async () => await _stationController?.StopAsync());
            SetControlsEnabledDuringRunning(false);
            SetMachineStatus(MachineStatus.Initialed);
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

        private void btn_LoadSetImage_Click_1(object sender, EventArgs e)
        {
            index = 0;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择图片文件";
            dialog.Filter = "图片文件(*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _imageFiles = dialog.FileNames.ToArray();
                if (_imageFiles != null && _imageFiles.Length > 0)
                {
                    ShowImage(index);
                    WriteMsg("已加载 " + _imageFiles.Length + " 张图片", UserTheadStatus.SoftOptStatus);
                }
                else
                {
                    WriteMsg("未选择任何图片文件", UserTheadStatus.SoftOptStatus);
                }
            }
        }

        private void ShowImage(int imageIndex)
        {
            if (_imageFiles == null || _imageFiles.Length == 0)
                return;

            if (imageIndex < 0 || imageIndex >= _imageFiles.Length)
                return;

            try
            {
                string filePath = _imageFiles[imageIndex];
                index = imageIndex;
                if (hWindow_Camera != null && File.Exists(filePath))
                {
                    hWindow_Camera.Image?.Dispose();
                    hWindow_Camera.Image = Image.FromFile(filePath);
                }
            }
            catch (Exception ex)
            {
                WriteMsg("加载图片失败: " + ex.Message, UserTheadStatus.SoftOptStatus);
            }
        }

        private void btn_Preview_Click_1(object sender, EventArgs e)
        {
            if (_imageFiles == null || _imageFiles.Length == 0)
            {
                WriteMsg("请先读取图片", UserTheadStatus.SoftOptStatus);
                return;
            }

            index--;
            if (index < 0)
                index = _imageFiles.Length - 1;

            WriteMsg("上一张: " + (index + 1) + "/" + _imageFiles.Length, UserTheadStatus.SoftOptStatus);
            ShowImage(index);
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
            WriteMsg("轴报警已清除", UserTheadStatus.AxisStatus);

            // 同步清除状态机报警并复位
            Task.Run(async () =>
            {
                try { if (_stationController != null) await _stationController.ResetAsync(); }
                catch (Exception ex) { LogService.Error(ex, "软件复位异常"); }
            });
        }


        /// <summary>
        /// 按照图中流程执行检测（气缸移载方式）
        /// 流程：人工上料 → 移载气缸伸出 → 到达检测位 → 光源开启 → Z轴调整 → 拍照检测 → 光源关闭 → 移载气缸缩回 → 人工取件
        /// CT要求：30-40S/Pcs
        /// </summary>
        private float _detectZHeight = 20f; // 自动检测高度(mm)，UI输入框可修改

        /// <summary>
        /// 执行一次自动检测流程（气缸移载方式）
        /// 流程：Z轴移动到检测高度 → 双手启动 → 气缸伸出 → 光源开 → Z轴到位
        ///       → 相机拍照 → VM视觉处理 → 保存结果 → 光源关 → Z轴回零 → 气缸缩回 → 循环
        /// </summary>
        private async void ExecuteCylinderDetection()
        {
            // 构造 VM 方案路径并加载
            var solPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "VmSol", _currentProductPort, _currentProductModel + ".sol");
            LogService.Information("[主界面] 加载VM方案: {Path}", solPath);
            if (File.Exists(solPath))
            {
                try { _deviceManager.Vision.LoadSolution(solPath); }
                catch (Exception ex) { LogService.Error(ex, "[主界面] VM方案加载失败"); }
            }
            else
            {
                LogService.Warning("[主界面] VM方案不存在: {Path}", solPath);
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
            if (_camera != null)
            {
                _camera.BitmapCallevent += _Camera_BitmapCallevent;
                _camera.RawImageCallevent += _Camera_RawImageCallevent;
            }
        }
        private void _Camera_BitmapCallevent(Bitmap bitmap) { hWindow_Camera.Image = bitmap; }
        private void _Camera_RawImageCallevent(IntPtr pData, int w, int h, int fmt)
        {
            try { _deviceManager?.Vision?.FeedRawImage(pData, w, h, fmt); }
            catch (Exception ex) { WriteMsg("图像传递失败: " + ex.Message, UserTheadStatus.SoftOptStatus); }
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
            if (cmb_TriggerModel.SelectedIndex != 0)
            {
                //MessageBox.Show("请将相机触发模式选择到软触发");
            }
            _deviceManager?.Camera?.Disconnect();
            _camera?.DisConnect();
            _deviceManager.Dispose();
            Application.Exit();
        }


        private void iO_Out0_CheckedChanged(object sender, IO_outEventArgs e)
        {
            _deviceManager?.Motion?.WriteOutput(e.Id, e.isChecked);
        }

        private void iO_In0_StatusChanged(object sender, StatusEventArgs e)
        {
            if (e.Status)
            {
                _ioFlags[e.Id] = true;
            }
            switch (e.Id)
            {
                case IOMapping.IN_CylinderExtendOk: // IN4 气缸伸出到位 — 光栅检测
                    if (!e.Status && _ioFlags[IOMapping.IN_CylinderExtendOk])
                    {
                        _ioFlags[IOMapping.IN_CylinderExtendOk] = false;
                        _buzzerEnabled = true;
                        _deviceManager?.Motion?.ZAxis?.Stop();
                    }
                    break;

                case IOMapping.IN_CylinderRetractOk: // IN5 气缸缩回到位
                    if (e.Status && _ioFlags[IOMapping.IN_CylinderRetractOk])
                    {
                        _ioFlags[IOMapping.IN_CylinderRetractOk] = false;
                        btn_StartAutoTest_Click(null, null);
                        SetMachineStatus(MachineStatus.Start);
                    }
                    break;

                case IOMapping.IN_EmergencyStop: // IN2 急停（常闭，LOW=按下）
                    if (!e.Status && !_hwEmgTriggered)
                    {
                        _hwEmgTriggered = true;
                        _buzzerEnabled = true;
                        EmergencyStopAll();
                    }
                    else if (e.Status)
                    {
                        _hwEmgTriggered = false;
                        _buzzerEnabled = false;
                    }
                    break;
            }
        }

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
            if (cmb_TriggerModel.SelectedIndex != 0) { WriteNGMsg("请将相机触发模式改为软触发", UserTheadStatus.SoftOptStatus); return false; }
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
                cmb_TriggerModel.Enabled = !isRunning;
                btn_StartAutoTest.Enabled = !isRunning;
                btn_StopAutoTest.Enabled = isRunning;
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
            if (_initFinished)
            {
                try
                {
                    if (cmb_TriggerModel.SelectedItem.ToString() == "软触发")
                    {
                        _cameraInfo.TrigerModel = MyTriger.Software;
                        btnSoftTriOnce.Enabled = true;
                    }
                    else if (cmb_TriggerModel.SelectedItem.ToString() == "硬触发")
                    {
                        _cameraInfo.TrigerModel = MyTriger.External;
                        btnSoftTriOnce.Enabled = false;
                    }
                    else if (cmb_TriggerModel.SelectedItem.ToString() == "连续触发")
                    {
                        _cameraInfo.TrigerModel = MyTriger.Continue;
                        btnSoftTriOnce.Enabled = false;
                    }
                    _cameraInfo.ExposeTime = Convert.ToInt32(txt_Exposure.Text.Trim());
                    _cameraInfo.Gain = Convert.ToInt32(txt_Gain.Text.Trim());
                    _cameraInfo.Gamable = switch_Gama.Active;
                    _cameraInfo.Gama = float.Parse(txt_Gama.Text);
                    _camera.UpDateCameraInfo(_cameraInfo);
                    SaveCameraSet(); // 同时保存到 JSON 并同步到 HkCamera
                }
                catch (Exception ex)
                {
                    WriteNGMsg("相机参数设置失败", UserTheadStatus.SoftOptStatus, ex);
                }
            }
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
        /// 加载方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ManualPlan_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "VM方案文件|*.sol";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    WriteMsg($"正在加载方案: {openFile.FileName}", UserTheadStatus.SoftOptStatus);

                    bool loadok = _deviceManager.Vision.LoadSolution(openFile.FileName);

                    if (loadok)
                    {
                        WriteMsg("方案加载成功", UserTheadStatus.SoftOptStatus);
                    }
                    else
                    {
                        string errorMsg = "方案加载失败";
                        WriteNGMsg("方案加载失败: " + errorMsg, UserTheadStatus.SoftOptStatus);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteNGMsg("方案加载异常: " + ex.Message, UserTheadStatus.SoftOptStatus, ex);
            }
        }

        /// <summary>
        /// 保存并显示检测记录
        /// </summary>
        /// <param name="isOK">检测结果 true=OK false=NG</param>
        /// <param name="ngReason">NG原因</param>
        private void SaveInspectionRecord(bool isOK, string ngReason = "")
        {
            var record = new CCDInspection.Core.Models.InspectionRecord
            {
                Time = DateTime.Now,
                Result = isOK ? "OK" : "NG",
                ProductIndex = _currentProduct.ProductIndex ?? "?",
                NgReason = ngReason
            };

            _inspectionRecords.Add(record);

            if (_inspectionRecords.Count > 100)
                _inspectionRecords.RemoveAt(0);

            ShowInspectionResult(record);
        }

        private void ShowInspectionResult(CCDInspection.Core.Models.InspectionRecord record)
        {
            bool isOK = record.Result == "OK";
            string resultText = $"[{record.Time:HH:mm:ss}] 检测结果:{(isOK ? "OK" : "NG")} 产品:{record.ProductIndex}";

            if (!isOK && !string.IsNullOrEmpty(record.NgReason))
                resultText += $" NG原因:{record.NgReason}";

            resultText += $" CT:{record.CycleTimeMs}ms";

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

        private void MoveAxis(int axisIndex, int direction)
        {
            if (_deviceManager?.Motion?.IsConnected != true)
            {
                WriteNGMsg("未连接到控制器", UserTheadStatus.AxisStatus);
                return;
            }
            if (_axisHandle == IntPtr.Zero)
            {
                WriteNGMsg("轴句柄无效", UserTheadStatus.AxisStatus);
                return;
            }
            if (!float.TryParse(txt_ManualSpeed.Text.Trim(), out float speed) || speed <= 0)
            {
                WriteNGMsg("手动速度无效", UserTheadStatus.AxisStatus);
                return;
            }

            float stepDist = _configService?.Load()?.Axis?.ManualDistance ?? 10f;
            float distance = direction * stepDist;

            Task.Run(async () =>
            {
                if (!await _deviceManager.Motion.ZAxis.MoveRel(distance, speed))
                    WriteNGMsg("轴移动失败", UserTheadStatus.SoftOptStatus);
            });
        }


        private void Begin_AddPlcPoint_Btm_Click(object sender, EventArgs e)
        {
            try
            {
                Button temp_button = (Button)sender;
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
                            var item1 = row.Cells[0].Value.ToString();
                            var item2 = row.Cells[1].Value.ToString();
                            var item3 = row.Cells[2].Value.ToString();
                            var item4 = row.Cells[3].Value.ToString();
                            _productModels.Add(new ProductModel() { Product_model = item1, Product_port = item2, Product_color = item3, Product_code = item4 });
                            var json = JsonConvert.SerializeObject(_productModels);
                            var configDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
                            if (!Directory.Exists(configDir)) Directory.CreateDirectory(configDir);
                            File.WriteAllText(Path.Combine(configDir, "ProductConfig.json"), json);
                        }

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
