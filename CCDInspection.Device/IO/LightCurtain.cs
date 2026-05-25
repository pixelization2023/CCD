using System;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core;

namespace CCDInspection.Device.IO
{
    /// <summary>
    /// 安全光栅实现 — 轮询 IN0(门禁)，遮挡时触发事件
    /// </summary>
    public class LightCurtain : ILightCurtain, IDisposable
    {
        private readonly IMotionController _motion;
        private readonly int _inputBit;
        private readonly int _pollIntervalMs;
        private CancellationTokenSource _cts;
        private bool _wasBlocked;

        public bool IsBlocked => _motion?.IsConnected == true && !_motion.ReadInput(_inputBit);

        event Action ILightCurtain.OnBlocked { add => _onBlocked += value; remove => _onBlocked -= value; }
        event Action ILightCurtain.OnUnblocked { add => _onUnblocked += value; remove => _onUnblocked -= value; }

        private event Action _onBlocked;
        private event Action _onUnblocked;

        public LightCurtain(IMotionController motion, int inputBit = 0, int pollIntervalMs = 100)
        {
            _motion = motion;
            _inputBit = inputBit;
            _pollIntervalMs = pollIntervalMs;
        }

        public void StartMonitoring()
        {
            
            StopMonitoring();
            _cts = new CancellationTokenSource();
            _wasBlocked = IsBlocked;
            Task.Run(() => PollLoop(_cts.Token));
            LogService.Information("安全光栅监控启动, IN{Index}", _inputBit);
        }

        public void StopMonitoring()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }

        private async Task PollLoop(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    bool blocked = IsBlocked;
                    if (blocked && !_wasBlocked)
                    {
                        LogService.Warning("安全光栅被遮挡! IN{Index}", _inputBit);
                        _onBlocked?.Invoke();
                    }
                    else if (!blocked && _wasBlocked)
                    {
                        LogService.Information("安全光栅恢复");
                        _onUnblocked?.Invoke();
                    }
                    _wasBlocked = blocked;
                    await Task.Delay(_pollIntervalMs, ct);
                }
                catch (TaskCanceledException) { break; }
                catch (Exception ex) { LogService.Error(ex, "光栅轮询异常"); }
            }
        }

        public void Dispose() => StopMonitoring();
    }
}
