using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Models;

namespace CCDInspection.Core.Interfaces.Hardware
{
    /// <summary>
    /// 视觉分析器接口 — 加载视觉算法方案，处理图像并返回分析结果
    /// </summary>
    public interface IVisionAnalyzer : IDisposable
    {
        /// <summary>
        /// 视觉方案是否已加载
        /// </summary>
        bool IsLoaded { get; }
        /// <summary>
        /// 当前加载的视觉方案路径
        /// </summary>
        /// <param name="solPath"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> LoadSolutionAsync(string solPath, CancellationToken ct = default);
        /// <summary>
        /// 卸载当前视觉方案，释放资源
        /// </summary>
        /// <returns></returns>
        Task UnloadAsync();
        /// <summary>
        /// 异步分析输入图像，返回视觉分析结果（是否通过、缺陷位置等）
        /// </summary>
        /// <param name="image"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<VisionResult> AnalyzeAsync(Bitmap image, CancellationToken ct = default);
        bool LoadSolution(string solPath);
        /// <summary>
        /// 卸载当前视觉方案，释放资源
        /// </summary>
        void Unload();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="passed"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        bool Run(out Bitmap image, out bool passed, out string reason);
        /// <summary>
        /// 直接输入原始图像数据进行分析，适用于高性能场景（如相机回调），避免 Bitmap 转换开销
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pixelFormat"></param>
        void FeedRawImage(IntPtr pData, int width, int height, int pixelFormat = 0);
    }
}
