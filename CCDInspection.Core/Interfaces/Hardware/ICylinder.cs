using System;
using System.Threading;
using System.Threading.Tasks;

namespace CCDInspection.Core.Interfaces.Hardware
{
    /// <summary>
    /// 气缸控制器接口 — 控制气缸伸出/缩回并检测到位传感器
    /// </summary>
    public interface ICylinder : IDisposable
    {
        /// <summary>气缸是否已伸出到位</summary>
        bool IsExtended { get; }
        /// <summary>气缸是否已缩回到位</summary>
        bool IsRetracted { get; }

        /// <summary>气缸伸出（异步，带超时和取消支持）</summary>
        Task<bool> ExtendAsync(int timeoutMs = 2000, CancellationToken ct = default);
        /// <summary>气缸缩回（异步，带超时和取消支持）</summary>
        Task<bool> RetractAsync(int timeoutMs = 2000, CancellationToken ct = default);

        /// <summary>气缸异常事件（故障描述）</summary>
        event Action<string> OnFault;
    }
}
