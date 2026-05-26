using System;
using System.Collections.Generic;
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
    /// <summary>
    /// VM视觉处理器 — 封装VisionMaster SDK的方案加载、流程运行、结果获取
    /// ================================================================
    /// 使用方式：
    ///   1. LoadSolution(solPath) → 加载.sol方案文件
    ///   2. Run(image, out ok, out reason) → 传入图像执行检测（null=VM内部触发相机）
    ///   3. GetModuleOutput("模块名") → 读取指定模块的输出值
    ///
    /// 方案结构约定：
    ///   - "流程1" → VmProcedure 主检测流程
    ///   - "发送数据1_发送数据" → 流程输出字符串（OK/NG判定）
    ///   - "0图像源1" / "图像源" → ImageSourceModuleTool 图像输入模块
    /// </summary>
    public class VmVisionProcessor : IVisionAnalyzer
    {
        private VmProcedure _procedure;
        private ImageSourceModuleTool _imageSource;
        private readonly object _lock = new object();
        private bool _disposed;

        public bool IsLoaded { get; private set; }
        public string CurrentSolution { get; private set; }
        /// <summary>暴露 VmProcedure 供外部直接调用 Run() 和绑定渲染</summary>
        public VmProcedure Procedure => _procedure;

        // ================================================================
        // 同步兼容方法
        // ================================================================
        public bool LoadSolution(string solPath) =>
            Task.Run(() => LoadSolutionAsync(solPath)).GetAwaiter().GetResult();
        public void Unload() => UnloadCore();

        /// <summary>
        /// 执行检测 — image传null时VM内部触发相机，否则用传入图像
        /// </summary>
        public bool Run(Bitmap img, out bool passed, out string reason)
        {
            var r = AnalyzeCore(img);
            passed = r.Passed;
            reason = r.Reason;
            return r.Success;
        }

        public void FeedRawImage(IntPtr pData, int w, int h, int fmt)
        {
            if (!IsLoaded || _imageSource == null || pData == IntPtr.Zero) return;
            lock (_lock)
            {
                try
                {
                    int sz = fmt == 1 ? w * h * 3 : (fmt == 2 ? w * h * 4 : w * h);
                    var d = new byte[sz];
                    Marshal.Copy(pData, d, 0, sz);
                    _imageSource.SetImageData(new ImageBaseData(d, (uint)sz, w, h, fmt));
                }
                catch { }
            }
        }

        // ================================================================
        // 异步接口
        // ================================================================
        public Task<bool> LoadSolutionAsync(string solPath, CancellationToken ct = default) =>
            Task.Run(() => LoadSolutionCore(solPath), ct);
        public Task UnloadAsync() => Task.Run(() => UnloadCore());
        public Task<VisionResult> AnalyzeAsync(Bitmap img, CancellationToken ct = default) =>
            Task.Run(() => AnalyzeCore(img), ct);

        // ================================================================
        // 方案加载
        // ================================================================
        private bool LoadSolutionCore(string solPath)
        {
            UnloadCore();
            lock (_lock)
            {
                try
                {
                    if (!System.IO.File.Exists(solPath))
                    {
                        LogService.Error("VM方案不存在: {Path}", solPath);
                        return false;
                    }

                    var fileInfo = new System.IO.FileInfo(solPath);
                    LogService.Information("VM方案加载中: {Path} | 大小={Size}KB", solPath, fileInfo.Length / 1024);

                    // SDK加载：设置当前目录为exe目录，确保VM能找到native dll
                    var oldDir = Environment.CurrentDirectory;
                    Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    try
                    {
                        VmSolution.Load(solPath);
                    }
                    finally { Environment.CurrentDirectory = oldDir; }
                    Thread.Sleep(200);

                    _procedure = VmSolution.Instance["流程1"] as VmProcedure;
                    if (_procedure == null)
                    {
                        LogService.Error("VM未找到'流程1'，请检查方案内流程命名");
                        VmSolution.Instance?.Dispose();
                        return false;
                    }

                    // 查找图像源模块（VM内部相机触发时可能不需要）
                    try { _imageSource = VmSolution.Instance["0图像源1"] as ImageSourceModuleTool; }
                    catch { }
                    if (_imageSource == null)
                    {
                        foreach (var name in new[] { "图像源", "ImageSource", "0ImageSource", "1图像源" })
                        {
                            try { _imageSource = VmSolution.Instance[name] as ImageSourceModuleTool; if (_imageSource != null) break; }
                            catch { }
                        }
                    }

                    IsLoaded = true;
                    CurrentSolution = solPath;
                    LogService.Information("VM方案加载成功: {Path} | 流程模块数={Count}",
                        solPath, _procedure.Modules?.Count ?? 0);
                    return true;
                }
                catch (Exception ex)
                {
                    LogService.Error(ex, "VM方案加载异常");
                    IsLoaded = false;
                    return false;
                }
            }
        }

        private void UnloadCore()
        {
            lock (_lock)
            {
                try { VmSolution.Instance?.Dispose(); } catch { }
                _procedure = null;
                _imageSource = null;
                IsLoaded = false;
                CurrentSolution = null;
            }
        }

        // ================================================================
        // 检测执行 — SDK 三步：设置输入 → Run() → 读取输出
        // ================================================================
        private VisionResult AnalyzeCore(Bitmap image)
        {
            if (!IsLoaded || _procedure == null)
                return new VisionResult { Success = false, Passed = false, Reason = "VM未加载" };

            lock (_lock)
            {
                try
                {
                    // Step 1: 设置输入图像（如果有外部图像源模块）
                    if (image != null && _imageSource != null)
                    {
                        var gray = BitmapToGrayBytes(image);
                        if (gray != null)
                            _imageSource.SetImageData(new ImageBaseData(gray, (uint)gray.Length, image.Width, image.Height, 0));
                    }

                    // Step 2: 执行流程 — VM方案内部管理相机触发/算法执行
                    _procedure.Run();

                    // Step 3: 读取输出结果
                    // 优先从流程输出字符串读取（兼容现有方案）
                    var output = _procedure.Outputs["发送数据1_发送数据"];
                    if (output != null)
                    {
                        string r = output.ToString();
                        return new VisionResult
                        {
                            Success = true,
                            Passed = r.Contains("OK") || r.Contains("True"),
                            Reason = r.Contains("OK") || r.Contains("True") ? "" : r
                        };
                    }

                    // 流程中无输出字符串 → 默认OK
                    return new VisionResult { Success = true, Passed = true };
                }
                catch (Exception ex)
                {
                    LogService.Error(ex, "VM检测异常");
                    return new VisionResult { Success = false, Passed = false, Reason = ex.Message };
                }
            }
        }

        // ================================================================
        // 模块输出读取（按名称访问方案内任意模块的输出）
        // ================================================================

        /// <summary>获取指定模块的字符串输出</summary>
        public string GetModuleOutputString(string moduleName, string outputName = null)
        {
            if (!IsLoaded) return null;
            lock (_lock)
            {
                try
                {
                    var tool = VmSolution.Instance[moduleName];
                    if (tool == null) return null;
                    if (outputName != null)
                    {
                        var m = tool.GetType().GetProperty(outputName)?.GetValue(tool);
                        return m?.ToString();
                    }
                    return tool.ToString();
                }
                catch { return null; }
            }
        }

        /// <summary>获取指定模块的浮点输出（如定位坐标、角度）</summary>
        public float GetModuleOutputFloat(string moduleName, string outputName)
        {
            if (!IsLoaded) return 0f;
            lock (_lock)
            {
                try
                {
                    var tool = VmSolution.Instance[moduleName];
                    if (tool == null) return 0f;
                    var value = tool.GetType().GetProperty(outputName)?.GetValue(tool);
                    return value != null ? Convert.ToSingle(value) : 0f;
                }
                catch { return 0f; }
            }
        }

        /// <summary>获取指定模块的整数输出（如计数、代码）</summary>
        public int GetModuleOutputInt(string moduleName, string outputName)
        {
            if (!IsLoaded) return 0;
            lock (_lock)
            {
                try
                {
                    var tool = VmSolution.Instance[moduleName];
                    if (tool == null) return 0;
                    var value = tool.GetType().GetProperty(outputName)?.GetValue(tool);
                    return value != null ? Convert.ToInt32(value) : 0;
                }
                catch { return 0; }
            }
        }

        /// <summary>批量读取多个模块的输出键值对</summary>
        public Dictionary<string, string> GetOutputs(params string[] moduleNames)
        {
            var result = new Dictionary<string, string>();
            if (!IsLoaded) return result;
            lock (_lock)
            {
                foreach (var name in moduleNames)
                {
                    try
                    {
                        var tool = VmSolution.Instance[name];
                        if (tool != null) result[name] = tool.ToString();
                    }
                    catch { }
                }
            }
            return result;
        }

        // ================================================================
        // 图像格式转换
        // ================================================================
        private static byte[] BitmapToGrayBytes(Bitmap bmp)
        {
            if (bmp == null) return null;
            try
            {
                int w = bmp.Width, h = bmp.Height;
                var rect = new Rectangle(0, 0, w, h);

                // 8位灰度图直接拷贝
                if (bmp.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    var data = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
                    var bytes = new byte[data.Stride * h];
                    Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
                    bmp.UnlockBits(data);
                    if (data.Stride == w) return bytes;
                    var r = new byte[w * h];
                    for (int y = 0; y < h; y++)
                        Buffer.BlockCopy(bytes, y * data.Stride, r, y * w, w);
                    return r;
                }

                // RGB转换灰度
                var bd = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
                var sb = new byte[bd.Stride * h];
                Marshal.Copy(bd.Scan0, sb, 0, sb.Length);
                bmp.UnlockBits(bd);
                int bpp = bmp.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4;
                var gray = new byte[w * h];
                for (int y = 0; y < h; y++)
                    for (int x = 0; x < w; x++)
                    {
                        int si = y * bd.Stride + x * bpp;
                        gray[y * w + x] = (byte)((sb[si] + sb[si + 1] + sb[si + 2]) / 3);
                    }
                return gray;
            }
            catch { return null; }
        }

        // ================================================================
        // 生命周期
        // ================================================================
        public void Dispose()
        {
            if (!_disposed)
            {
                UnloadCore();
                _disposed = true;
            }
        }
    }
}
