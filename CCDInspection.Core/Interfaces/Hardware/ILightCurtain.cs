using System;

namespace CCDInspection.Core.Interfaces.Hardware
{
    /// <summary>
    /// 安全光栅接口 — 检测光栅是否被遮挡，触发安全事件
    /// </summary>
    public interface ILightCurtain : IDisposable
    {
        /// <summary>光栅当前是否被遮挡</summary>
        bool IsBlocked { get; }

        /// <summary>光栅被遮挡事件</summary>
        event Action OnBlocked;
        /// <summary>光栅恢复通畅事件</summary>
        event Action OnUnblocked;
    }
}
