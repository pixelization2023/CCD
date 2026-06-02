using System;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core;

namespace CCDInspection.Device.IO
{
    /// <summary>
    /// 中封式电磁阀气缸控制
    /// OUT0=A  OUT1=B
    /// A=0 B=0 → 中封(保持位置)
    /// A=1 B=0 → 气缸伸出
    /// A=0 B=1 → 气缸缩回
    /// A=1 B=1 → 禁止
    /// </summary>
    public class Cylinder : ICylinder
    {
        private readonly IMotionController _motion;
        private readonly int _outA, _outB, _extendSensor, _retractSensor;
        private bool _disposed;

        public bool IsExtended => _motion.IsConnected && _motion.ReadInput(_extendSensor);
        public bool IsRetracted => _motion.IsConnected && _motion.ReadInput(_retractSensor);
        public event Action<string> OnFault;

        public Cylinder(IMotionController motion, int outA, int outB, int extendSensor, int retractSensor)
        { _motion = motion; _outA = outA; _outB = outB; _extendSensor = extendSensor; _retractSensor = retractSensor; }

        // 兼容旧代码（无CancellationToken）
        public Task<bool> ExtendAsync(int timeoutMs) => ExtendAsync(timeoutMs, CancellationToken.None);
        public Task<bool> RetractAsync(int timeoutMs) => RetractAsync(timeoutMs, CancellationToken.None);

        public Task<bool> ExtendAsync(int timeoutMs, CancellationToken ct) => Task.Run(() =>
        {
            try
            {
                ct.ThrowIfCancellationRequested();
                LogService.Information("[气缸] 伸出开始 | A={A} B={B} Timeout={T}ms", _outA, _outB, timeoutMs);
                _motion.WriteOutput(_outA, true);
                _motion.WriteOutput(_outB, false);
                int e = 0;
                while (!_motion.ReadInput(_extendSensor))
                {
                    ct.ThrowIfCancellationRequested();
                    if (e >= timeoutMs) { LogService.Error("[气缸] 伸出超时"); OnFault?.Invoke("气缸伸出超时"); return false; }
                    Thread.Sleep(10); e += 10;
                }
                LogService.Information("[气缸] 伸出到位 | 耗时={T}ms", e);
                _motion.WriteOutput(_outA, false);
                _motion.WriteOutput(_outB, false);
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
                LogService.Information("[气缸] 缩回开始 | A={A} B={B} Timeout={T}ms", _outA, _outB, timeoutMs);
                _motion.WriteOutput(_outA, false);
                _motion.WriteOutput(_outB, true);
                int e = 0;
                while (!_motion.ReadInput(_retractSensor))
                {
                    ct.ThrowIfCancellationRequested();
                    if (e >= timeoutMs) { LogService.Error("[气缸] 缩回超时"); OnFault?.Invoke("气缸缩回超时"); return false; }
                    Thread.Sleep(10); e += 10;
                }
                LogService.Information("[气缸] 缩回到位 | 耗时={T}ms", e);
                _motion.WriteOutput(_outA, false);
                _motion.WriteOutput(_outB, false);
                return true;
            }
            catch (OperationCanceledException) { LogService.Information("[气缸] 缩回已取消"); return false; }
            catch (Exception ex) { LogService.Error(ex, "[气缸] 缩回异常"); OnFault?.Invoke(ex.Message); return false; }
        }, ct);

        public void Dispose() { _disposed = true; }
    }
}
