using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Models;

namespace CCDInspection.Core.Interfaces.Hardware
{
    /// <summary>
    /// 视觉分析器接口 — 基于 VisionMaster 进行图像检测分析
    /// </summary>
    public interface IVisionAnalyzer : IDisposable
    {
        /// <summary>视觉方案是否已加载</summary>
        bool IsLoaded { get; }

        /// <summary>异步加载 VM 检测方案</summary>
        Task<bool> LoadSolutionAsync(string solPath, CancellationToken ct = default);
        /// <summary>异步卸载方案</summary>
        Task UnloadAsync();
        /// <summary>异步执行视觉检测，返回分析结果</summary>
        Task<VisionResult> AnalyzeAsync(Bitmap image, CancellationToken ct = default);

        /// <summary>同步加载方案（兼容旧代码）</summary>
        bool LoadSolution(string solPath);
        /// <summary>同步卸载方案（兼容旧代码）</summary>
        void Unload();
        /// <summary>同步执行检测（兼容旧代码）</summary>
        bool Run(Bitmap image, out bool passed, out string reason);
        /// <summary>直接传入原始图像数据（兼容旧代码）</summary>
        void FeedRawImage(IntPtr pData, int width, int height, int pixelFormat = 0);
    }
}
