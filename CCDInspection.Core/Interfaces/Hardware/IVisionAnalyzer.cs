using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Models;

namespace CCDInspection.Core.Interfaces.Hardware
{
    public interface IVisionAnalyzer : IDisposable
    {
        bool IsLoaded { get; }
        Task<bool> LoadSolutionAsync(string solPath, CancellationToken ct = default);
        Task UnloadAsync();
        Task<VisionResult> AnalyzeAsync(Bitmap image, CancellationToken ct = default);
        bool LoadSolution(string solPath);
        void Unload();
        bool Run(Bitmap image, out bool passed, out string reason);
        void FeedRawImage(IntPtr pData, int width, int height, int pixelFormat = 0);
    }
}
