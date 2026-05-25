using System;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Enums;
using CCDInspection.Core.Models;

namespace CCDInspection.Core.Interfaces.Services
{
    /// <summary>
    /// 检测工位接口 — 管理单个工位的自动检测流程和状态机
    /// </summary>
    public interface IInspectionStation
    {
        /// <summary>当前工位状态</summary>
        StationState CurrentState { get; }
        /// <summary>最近一次检测记录</summary>
        InspectionRecord LastRecord { get; }

        /// <summary>启动自动检测流程</summary>
        Task StartAsync(ProductConfig product, CancellationToken ct = default);
        /// <summary>停止检测，回到空闲状态</summary>
        Task StopAsync();
        /// <summary>复位：清除报警 → 气缸缩回 → 轴回零 → 空闲</summary>
        Task ResetAsync();

        /// <summary>单次检测完成事件</summary>
        event Action<InspectionRecord> OnInspectionCompleted;
        /// <summary>状态变更事件（状态描述文本）</summary>
        event Action<string> OnStatusChanged;
        /// <summary>报警事件（报警码, 报警消息）</summary>
        event Action<string, string> OnAlarm;
    }
}
