using System;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core.Models;
using CCDInspection.Core;

namespace CCDInspection.Device.Motion
{
    public class ZmcController : IMotionController
    {
        private IntPtr _handle = IntPtr.Zero;
        private const int ZAxisIndex = 0;

        public bool IsConnected { get; private set; }
        public IAxis ZAxis { get; private set; }
        public event Action<int, string> OnAlarm;

        public void UseExistingHandle(IntPtr handle) { _handle = handle; IsConnected = (_handle != IntPtr.Zero); if (IsConnected) ZAxis = new Axis(_handle, ZAxisIndex); }

        public Task<bool> ConnectAsync(string ipAddress, CancellationToken ct = default) => Task.Run(() => {
            DisconnectCore();
            int ret = ZmcApi.ZAux_FastOpen(2, ipAddress, 3000, out _handle);
            if (ret != 0 || _handle == IntPtr.Zero) { LogService.Error("ZMC连接失败 IP={Ip}", ipAddress); IsConnected = false; return false; }
            IsConnected = true; ZAxis = new Axis(_handle, ZAxisIndex);
            LogService.Information("ZMC连接成功 IP={Ip}", ipAddress); return true;
        }, ct);

        public Task DisconnectAsync() => Task.Run(() => DisconnectCore());
        public Task EmergencyStopAsync() => Task.Run(() => EmergencyStopCore());

        private void DisconnectCore() { if (_handle != IntPtr.Zero) { ZmcApi.ZAux_Close(_handle); _handle = IntPtr.Zero; } IsConnected = false; ZAxis = null; }
        private void EmergencyStopCore() { if (IsConnected) ZmcApi.ZAux_Direct_Rapidstop(_handle, 2); }

        // 兼容旧代码（通过Task.Run避免UI线程死锁）
        public bool Connect(string ip) { try { return Task.Run(() => ConnectAsync(ip)).GetAwaiter().GetResult(); } catch { return false; } }
        public void Disconnect() { try { Task.Run(() => DisconnectAsync()).GetAwaiter().GetResult(); } catch { } }
        public void EmergencyStop() { EmergencyStopCore(); }

        public bool ReadInput(int idx) { if (!IsConnected) return false; uint s = 0; ZmcApi.ZAux_Direct_GetIn(_handle, idx, ref s); return s != 0; }
        public IntPtr GetHandle() => _handle;
        public void WriteOutput(int idx, bool val) { if (IsConnected) ZmcApi.ZAux_Direct_SetOp(_handle, idx, val ? 1u : 0u); }

        public void ConfigureAxis(int iaxis, AxisConfig cfg)
        {
            if (!IsConnected) return;
            LogService.Information("[ConfigureAxis] 轴{Idx} ATYPE={AType} ret={Ret}", iaxis, cfg.AType, ZmcApi.ZAux_Direct_SetAtype(_handle, iaxis, cfg.AType));
            ZmcApi.ZAux_Direct_SetUnits(_handle, iaxis, cfg.PulseEquivalent);
            ZmcApi.ZAux_Direct_SetSpeed(_handle, iaxis, cfg.AutoSpeed);
            ZmcApi.ZAux_Direct_SetAccel(_handle, iaxis, cfg.Acceleration);
            ZmcApi.ZAux_Direct_SetDecel(_handle, iaxis, cfg.Deceleration);
            ZmcApi.ZAux_Direct_SetFsLimit(_handle, iaxis, cfg.PositiveSoftLimit);
            ZmcApi.ZAux_Direct_SetRsLimit(_handle, iaxis, cfg.NegativeSoftLimit);
            ZmcApi.ZAux_Direct_SetDatumIn(_handle, iaxis, cfg.OriginIo);
            ZmcApi.ZAux_Direct_SetFwdIn(_handle, iaxis, cfg.PosLimitIo);
            ZmcApi.ZAux_Direct_SetRevIn(_handle, iaxis, cfg.NegLimitIo);
            ZmcApi.ZAux_Direct_SetAlmIn(_handle, iaxis, cfg.AlarmIo);
            ZmcApi.ZAux_Direct_SetSramp(_handle, iaxis, cfg.Sramp);
            ZmcApi.ZAux_Direct_SetFastDec(_handle, iaxis, cfg.FastDec);
        }

        public void ClearAlarm(int iaxis) { if (!IsConnected) return; ZmcApi.ZAux_Direct_SetParam(_handle, "AXIS_STOPREASON", iaxis, 0); ZmcApi.ZAux_Direct_SetAxisEnable(_handle, iaxis, 1); }
        public bool Enable() => ZmcApi.ZAux_Direct_SetAxisEnable(_handle, ZAxisIndex, 1) == 0;
        public bool ClearAlram() => ZmcApi.ZAux_BusCmd_DriveClear(_handle, (uint)ZAxisIndex, 0) == 0;
        public void Dispose() { DisconnectCore(); }
    }
}
