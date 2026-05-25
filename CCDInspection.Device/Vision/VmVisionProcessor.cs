using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core.Models;
using ImageSourceModuleCs;
using CCDInspection.Core;
using VM.Core;
using VM.PlatformSDKCS;

namespace CCDInspection.Device.Vision
{
    public class VmVisionProcessor : IVisionAnalyzer
    {
        private VmProcedure _procedure;
        private ImageSourceModuleTool _imageSource;
        private readonly object _lock = new object();
        private bool _disposed;

        public bool IsLoaded { get; private set; }

        // 兼容旧代码（通过Task.Run避免UI线程死锁）
        public bool LoadSolution(string solPath) => Task.Run(() => LoadSolutionAsync(solPath)).GetAwaiter().GetResult();
        public void Unload() => UnloadCore();
        public bool Run(Bitmap img, out bool passed, out string reason) { var r = AnalyzeCore(img); passed = r.Passed; reason = r.Reason; return r.Success; }
        public void FeedRawImage(IntPtr pData, int w, int h, int fmt) { if (!IsLoaded || _imageSource == null || pData == IntPtr.Zero) return; lock (_lock) { try { int sz = fmt == 1 ? w * h * 3 : fmt == 2 ? w * h * 4 : w * h; var d = new byte[sz]; Marshal.Copy(pData, d, 0, sz); _imageSource.SetImageData(new ImageBaseData(d, (uint)sz, w, h, fmt)); } catch { } } }

        public Task<bool> LoadSolutionAsync(string solPath, CancellationToken ct = default) => Task.Run(() => LoadSolutionCore(solPath), ct);
        public Task UnloadAsync() => Task.Run(() => UnloadCore());
        public Task<VisionResult> AnalyzeAsync(Bitmap img, CancellationToken ct = default) => Task.Run(() => AnalyzeCore(img), ct);

        private bool LoadSolutionCore(string solPath)
        {
            UnloadCore();
            lock (_lock)
            {
                try
                {
                    if (!System.IO.File.Exists(solPath)) { LogService.Error("VM方案不存在: {Path}", solPath); return false; }
                    VmSolution.Load(solPath); Thread.Sleep(100);
                    _procedure = VmSolution.Instance["流程1"] as VmProcedure;
                    if (_procedure == null) { LogService.Error("VM未找到'流程1'"); VmSolution.Instance?.Dispose(); return false; }
                    try { _imageSource = VmSolution.Instance["0图像源1"] as ImageSourceModuleTool; } catch { }
                    if (_imageSource == null) foreach (var k in new[] { "图像源", "ImageSource", "0ImageSource", "1图像源" }) { try { _imageSource = VmSolution.Instance[k] as ImageSourceModuleTool; if (_imageSource != null) break; } catch { } }
                    IsLoaded = true;
                    LogService.Information("VM方案加载成功: {Path}", solPath); return true;
                }
                catch (Exception ex) { LogService.Error(ex, "VM方案加载异常"); IsLoaded = false; return false; }
            }
        }

        private void UnloadCore() { lock (_lock) { try { VmSolution.Instance?.Dispose(); } catch { } _procedure = null; _imageSource = null; IsLoaded = false; } }

        private VisionResult AnalyzeCore(Bitmap image)
        {
            if (!IsLoaded || _procedure == null) return new VisionResult { Success = false, Passed = false, Reason = "VM未加载" };
            lock (_lock)
            {
                try
                {
                    if (image != null && _imageSource != null) { var d = BitmapToGrayBytes(image); if (d != null) _imageSource.SetImageData(new ImageBaseData(d, (uint)d.Length, image.Width, image.Height, 0)); }
                    _procedure.Run();
                    var output = _procedure.Outputs["发送数据1_发送数据"];
                    if (output != null) { string r = output.ToString(); return new VisionResult { Success = true, Passed = r.Contains("OK") || r.Contains("True"), Reason = r.Contains("OK") || r.Contains("True") ? "" : r }; }
                    return new VisionResult { Success = true, Passed = true };
                }
                catch (Exception ex) { LogService.Error(ex, "VM检测异常"); return new VisionResult { Success = false, Passed = false, Reason = ex.Message }; }
            }
        }

        private static byte[] BitmapToGrayBytes(Bitmap bmp)
        {
            try { int w = bmp.Width, h = bmp.Height; var rect = new Rectangle(0, 0, w, h); if (bmp.PixelFormat == PixelFormat.Format8bppIndexed) { var data = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat); var bytes = new byte[data.Stride * h]; Marshal.Copy(data.Scan0, bytes, 0, bytes.Length); bmp.UnlockBits(data); if (data.Stride == w) return bytes; var r = new byte[w * h]; for (int y = 0; y < h; y++) Buffer.BlockCopy(bytes, y * data.Stride, r, y * w, w); return r; } var bd = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat); var sb = new byte[bd.Stride * h]; Marshal.Copy(bd.Scan0, sb, 0, sb.Length); bmp.UnlockBits(bd); int bpp = bmp.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4; var gray = new byte[w * h]; for (int y = 0; y < h; y++) for (int x = 0; x < w; x++) { int si = y * bd.Stride + x * bpp; gray[y * w + x] = (byte)((sb[si] + sb[si + 1] + sb[si + 2]) / 3); } return gray; } catch { return null; }
        }

        public void Dispose() { if (!_disposed) { UnloadCore(); _disposed = true; } }
    }
}
