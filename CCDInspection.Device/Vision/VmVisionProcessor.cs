using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core.Models;
using CCDInspection.Core;
using VM.Core;

namespace CCDInspection.Device.Vision
{
    /// <summary>VM视觉处理器 — 薄包装，实际VM调用已迁移到FrmMain</summary>
    public class VmVisionProcessor : IVisionAnalyzer
    {
        private VmProcedure _procedure;
        public bool IsLoaded { get; private set; }
        public VmProcedure Procedure => _procedure;

        /// <summary>直接设置Procedure（由FrmMain加载方案后调用，避免重复Load）</summary>
        public void SetProcedure(VmProcedure proc)
        {
            _procedure = proc;
            IsLoaded = proc != null;
            LogService.Information("[VM] SetProcedure | IsLoaded={L}", IsLoaded);
        }

        public bool LoadSolution(string solPath) => Task.Run(() => LoadSolutionAsync(solPath)).GetAwaiter().GetResult();
        public void Unload() { _procedure = null; IsLoaded = false; }
        public bool Run(Bitmap img, out bool passed, out string reason)
        {
            passed = false; reason = "";
            if (!IsLoaded || _procedure == null) { reason = "VM未加载"; return false; }
            try
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                _procedure.Run();
                sw.Stop();

                int resInt = 0;
                try
                {
                    resInt = _procedure.ModuResult.GetOutputInt("out").pIntVal[0];
                    if (resInt == 1)
                    {
                        reason = _procedure.ModuResult.GetOutputString("out0").astStringVal[0].strValue;
                    }
                    else { reason = "检测结果:NG\r\n产品编码:999\r\n产品颜色:999"; }
                }
                catch
                {
                    //reason = "获取结果失败";
                    reason = "检查结果：NG\n产品编码：999\n产品颜色：999";
                }
                passed = resInt == 1;
                if (string.IsNullOrEmpty(reason) && !passed)
                    reason = "检查结果：NG\n产品编码：999\n产品颜色：999";

                LogService.Information("[VM] Run完成 | passed={P} 耗时={T}ms reason={R}",
                    passed, sw.ElapsedMilliseconds, reason ?? "");
                return true;
            }
            catch (Exception ex)
            {
                passed = false;
                reason = ex.Message;
                LogService.Error(ex, "[VM] Run异常");
                return false;
            }
        }
        public void FeedRawImage(IntPtr pData, int w, int h, int fmt) { }

        public Task<bool> LoadSolutionAsync(string solPath, CancellationToken ct = default) => Task.Run(() =>
        {
            try
            {
                if (!System.IO.File.Exists(solPath)) { LogService.Error("VM方案不存在"); return false; }
                var old = Environment.CurrentDirectory;
                Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                VmSolution.Load(solPath);
                Environment.CurrentDirectory = old;
                _procedure = VmSolution.Instance["流程1"] as VmProcedure;
                IsLoaded = _procedure != null;
                return IsLoaded;
            }
            catch (Exception ex) { LogService.Error(ex, "VM加载异常"); return false; }
        }, ct);

        public Task UnloadAsync() => Task.Run(() => { _procedure = null; IsLoaded = false; });
        public Task<VisionResult> AnalyzeAsync(Bitmap img, CancellationToken ct = default) =>
            Task.Run(() => { bool p; string r; Run(img, out p, out r); return new VisionResult { Success = true, Passed = p, Reason = r }; }, ct);

        public void Dispose() { _procedure = null; }
    }
}
