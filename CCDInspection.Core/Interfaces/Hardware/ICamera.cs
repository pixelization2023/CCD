using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Models;

namespace CCDInspection.Core.Interfaces.Hardware
{
    /// <summary>
    /// 相机接口 — 支持海康等工业相机的连接、触发和图像采集
    /// </summary>
    public interface ICamera : IDisposable
    {
        /// <summary>相机是否已连接</summary>
        bool IsConnected { get; }
        /// <summary>相机参数配置</summary>
        CameraConfig Config { get; set; }

        /// <summary>异步连接相机</summary>
        Task<bool> ConnectAsync(CancellationToken ct = default);
        /// <summary>异步断开连接</summary>
        Task DisconnectAsync();
        /// <summary>异步软触发拍照，返回采集结果</summary>
        Task<ImageCaptureResult> TriggerAsync(CancellationToken ct = default);

        /// <summary>同步连接（兼容旧代码）</summary>
        bool Connect();
        /// <summary>同步断开（兼容旧代码）</summary>
        void Disconnect();
        /// <summary>同步触发拍照（兼容旧代码）</summary>
        bool Trigger(out Bitmap image);

        /// <summary>图像采集完成事件</summary>
        event Action<ImageCaptureResult> OnImageCaptured;
    }
}
