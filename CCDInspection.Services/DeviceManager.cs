using System;
using CCDInspection.Core.Enums;
using CCDInspection.Core.Interfaces;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core.Models;
using IVisionProcessor = CCDInspection.Core.Interfaces.Hardware.IVisionAnalyzer;
using CCDInspection.Device.Camera;
using CCDInspection.Device.IO;
using CCDInspection.Device.Motion;
using CCDInspection.Device.Vision;
using CCDInspection.Core;
using IAlarmHandler = CCDInspection.Core.Interfaces.Services.IAlarmHandler;

namespace CCDInspection.Services
{
    /// <summary>
    /// 设备管理器 — 统一管理所有硬件设备的生命周期
    /// </summary>
    public class DeviceManager : IDisposable
    {
        public IMotionController Motion { get; set; }
        public ICamera Camera { get; set; }
        public IVisionProcessor Vision { get; set; }
        public IAlarmHandler Alarm { get; set; }
        public ILightCurtain LightCurtain { get; set; }

        /// <summary>
        /// 所有设备是否已准备就绪（运动控制器连接、相机连接、视觉处理器加载）
        /// </summary>
        public bool IsAllReady =>
            Motion?.IsConnected == true &&
            Camera?.IsConnected == true &&
            Vision?.IsLoaded == true;

        /// <summary>
        /// 当前设备状态
        /// </summary>
        public MachineStatus Status { get; private set; } = MachineStatus.SoftwareOpen;

        /// <summary>
        /// 设备状态变更事件 — 订阅后可在状态变化时执行相应操作（如界面更新、日志记录等）
        /// </summary>
        public event Action<MachineStatus> OnStatusChanged;

        /// <summary>
        /// 初始化所有设备 — 包括连接运动控制器、相机和加载视觉处理器
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public bool InitializeAll(AppConfig config)
        {
            SetStatus(MachineStatus.Initial);

            try
            {
                Motion = new ZmcController();
                if (!Motion.Connect(config.Axis.IpAddress))
                {
                    LogService.Error("运动控制器初始化失败");
                    SetStatus(MachineStatus.Alarm);
                    return false;
                }

                Camera = new HkCamera(config.Camera);
                if (!Camera.Connect())
                {
                    LogService.Error("相机初始化失败");
                    SetStatus(MachineStatus.Alarm);
                    return false;
                }

                Vision = new VmVisionProcessor();

                SetStatus(MachineStatus.Initialed);
                LogService.Information("所有设备初始化完成");
                return true;
            }
            catch (Exception ex)
            {
                LogService.Error(ex, "设备初始化异常");
                SetStatus(MachineStatus.Alarm);
                return false;
            }
        }

        public void Shutdown()
        {
            SetStatus(MachineStatus.Stop);
            Vision?.Unload();
            Camera?.Disconnect();
            Camera?.Dispose();
            Motion?.Disconnect();
            Motion?.Dispose();
            LogService.Information("所有设备已关闭");
        }

        // ================================================================
        // IO 便捷方法（引用 IOMapping 集中常量）
        // ================================================================

        public bool IsDualStartPressed() =>
            Motion.ReadInput(IOMapping.IN_FlowStart);

        public void CylinderExtend(int timeoutMs = 20000)
        {
            Motion.WriteOutput(IOMapping.OUT_Cylinder, false);
            int elapsed = 0;
            while (!Motion.ReadInput(IOMapping.IN_CylinderExtendOk))
            {
                if (elapsed >= timeoutMs) throw new TimeoutException("气缸伸出超时");
                System.Threading.Thread.Sleep(10);
                elapsed += 10;
            }
        }

        public void CylinderRetract(int timeoutMs = 20000)
        {
            Motion.WriteOutput(IOMapping.OUT_Cylinder, true);
            int elapsed = 0;
            while (!Motion.ReadInput(IOMapping.IN_CylinderRetractOk))
            {
                if (elapsed >= timeoutMs) throw new TimeoutException("气缸缩回超时");
                System.Threading.Thread.Sleep(10);
                elapsed += 10;
            }
        }

        public void LightOn() => Motion.WriteOutput(IOMapping.OUT_Light, true);
        public void LightOff() => Motion.WriteOutput(IOMapping.OUT_Light, false);
        public bool IsStartPressed() => Motion.ReadInput(IOMapping.IN_MachineStart);

        public void SetTowerLight(bool green, bool red, bool yellow, bool buzzer = false)
        {
            Motion.WriteOutput(IOMapping.OUT_GreenLight, green);
            Motion.WriteOutput(IOMapping.OUT_RedLight, red);
            Motion.WriteOutput(IOMapping.OUT_YellowLight, yellow);
            if (buzzer)
            {
                Motion.WriteOutput(IOMapping.OUT_Buzzer, true);
                System.Threading.Thread.Sleep(500);
                Motion.WriteOutput(IOMapping.OUT_Buzzer, false);
            }
        }

        private void SetStatus(MachineStatus status)
        {
            Status = status;
            OnStatusChanged?.Invoke(status);
        }

        public void Dispose()
        {
            Shutdown();
        }
    }
}
