using System;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core;

namespace CCDInspection.Device.IO
{
    public class Cylinder : ICylinder
    {
        private readonly IMotionController _motion;
        private readonly int _outBit, _extendSensor, _retractSensor;
        private bool _disposed;

        public bool IsExtended => _motion.IsConnected && _motion.ReadInput(_extendSensor);
        public bool IsRetracted => _motion.IsConnected && _motion.ReadInput(_retractSensor);
        public event Action<string> OnFault;

        public Cylinder(IMotionController motion, int outBit, int extendSensor, int retractSensor)
        { _motion = motion; _outBit = outBit; _extendSensor = extendSensor; _retractSensor = retractSensor; }

        // 兼容旧代码（无CancellationToken）
        public Task<bool> ExtendAsync(int timeoutMs) => ExtendAsync(timeoutMs, CancellationToken.None);
        public Task<bool> RetractAsync(int timeoutMs) => RetractAsync(timeoutMs, CancellationToken.None);

        public Task<bool> ExtendAsync(int timeoutMs, CancellationToken ct) => Task.Run(() =>
        {
            try
            {
                ct.ThrowIfCancellationRequested();
                LogService.Information("[气缸] 伸出开始 | OutBit={B} Timeout={T}ms", _outBit, timeoutMs);
                _motion.WriteOutput(_outBit, false);
                int e = 0;
                while (!_motion.ReadInput(_extendSensor))
                {
                    ct.ThrowIfCancellationRequested();
                    if (e >= timeoutMs) { LogService.Error("[气缸] 伸出超时"); OnFault?.Invoke("气缸伸出超时"); return false; }
                    Thread.Sleep(10); e += 10;
                }
                LogService.Information("[气缸] 伸出到位 | 耗时={T}ms", e);
                return true;
            }
            catch (OperationCanceledException) { LogService.Information("[气缸] 伸出已取消"); return false; }
            catch (Exception ex) { LogService.Error(ex, "[气缸] 伸出异常"); OnFault?.Invoke(ex.Message); return false; }
        }, ct);

        public Task<bool> RetractAsync(int timeoutMs, CancellationToken ct) => Task.Run(() =>
        {
            try
            {
                ct.ThrowIfCancellationRequested();
                LogService.Information("[气缸] 缩回开始 | OutBit={B} Timeout={T}ms", _outBit, timeoutMs);
                _motion.WriteOutput(_outBit, true);
                int e = 0;
                while (!_motion.ReadInput(_retractSensor))
                {
                    ct.ThrowIfCancellationRequested();
                    if (e >= timeoutMs) { LogService.Error("[气缸] 缩回超时"); OnFault?.Invoke("气缸缩回超时"); return false; }
                    Thread.Sleep(10); e += 10;
                }
                LogService.Information("[气缸] 缩回到位 | 耗时={T}ms", e);
                return true;
            }
            catch (OperationCanceledException) { LogService.Information("[气缸] 缩回已取消"); return false; }
            catch (Exception ex) { LogService.Error(ex, "[气缸] 缩回异常"); OnFault?.Invoke(ex.Message); return false; }
        }, ct);

        public void Dispose() { _disposed = true; }
    }
}
