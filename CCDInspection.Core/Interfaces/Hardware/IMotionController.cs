using System;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Models;

namespace CCDInspection.Core.Interfaces.Hardware
{
    /// <summary>
    /// 运动控制器接口 — 管理 ZMC 控制器的连接、轴控制和 IO 操作
    /// </summary>
    public interface IMotionController : IDisposable
    {
        /// <summary>控制器是否已连接</summary>
        bool IsConnected { get; }
        /// <summary>Z轴实例</summary>
        IAxis ZAxis { get; }

        /// <summary>异步连接控制器</summary>
        Task<bool> ConnectAsync(string ipAddress, CancellationToken ct = default);
        /// <summary>异步断开连接</summary>
        Task DisconnectAsync();
        /// <summary>异步紧急停止</summary>
        Task EmergencyStopAsync();

        /// <summary>同步连接（兼容旧代码）</summary>
        bool Connect(string ipAddress);
        /// <summary>同步断开（兼容旧代码）</summary>
        void Disconnect();
        /// <summary>同步紧急停止（兼容旧代码）</summary>
        void EmergencyStop();

        /// <summary>获取控制器原生句柄</summary>
        IntPtr GetHandle();
        /// <summary>读取指定输入点的状态</summary>
        bool ReadInput(int index);
        /// <summary>设置指定输出点的状态</summary>
        void WriteOutput(int index, bool value);
        /// <summary>配置轴参数（ATYPE、速度、限位等）</summary>
        void ConfigureAxis(int axisIndex, AxisConfig config);
        /// <summary>清除指定轴的报警</summary>
        void ClearAlarm(int axisIndex);

        /// <summary>控制器报警事件（轴号, 错误描述）</summary>
        event Action<int, string> OnAlarm;
    }
}
