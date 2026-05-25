using System;
using CCDInspection.Device.IO;
using CCDInspection.Core;
using IAlarmHandler = CCDInspection.Core.Interfaces.Services.IAlarmHandler;

namespace CCDInspection.Services
{
    /// <summary>
    /// 报警处理器
    /// </summary>
    public class AlarmHandler : IAlarmHandler
    {
        private readonly DeviceManager _devices;
        public bool IsAlarming { get; private set; }

        public event Action<string, string> OnAlarm;
        public event Action OnAlarmCleared;

        public AlarmHandler(DeviceManager devices)
        {
            _devices = devices;
        }

        public void RaiseAlarm(string code, string message)
        {
            if (IsAlarming)
            {
                LogService.Warning("[诊断-报警] RaiseAlarm 忽略(已在报警中) | {Code}: {Message}", code, message);
                return;
            }
            IsAlarming = true;
            LogService.Error("[诊断-报警] RaiseAlarm | {Code}: {Message} | Motion={M} ZAxis={Z}",
                code, message,
                _devices.Motion?.IsConnected ?? false,
                _devices.Motion?.ZAxis != null ? "OK" : "NULL");

            _devices.Motion?.ZAxis?.Stop();
            _devices.Motion?.EmergencyStop();
            _devices.SetTowerLight(false, true, false, true);

            OnAlarm?.Invoke(code, message);
        }

        public void ClearAlarm()
        {
            if (!IsAlarming)
            {
                LogService.Information("[诊断-报警] ClearAlarm 忽略(不在报警中)");
                return;
            }
            IsAlarming = false;
            LogService.Information("[诊断-报警] ClearAlarm 报警已清除");
            OnAlarmCleared?.Invoke();
        }
    }
}
