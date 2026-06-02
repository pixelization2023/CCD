using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Services;
using VM.Core;

namespace CCDInspection.UI.Forms
{
    public partial class FrmVM : Form
    {
        public DeviceManager DeviceManager { get; set; }

        public FrmVM()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // MouseDown 开始点动，MouseUp 停止
            btn_up.MouseDown += (s, ev) => Jog(-1);
            btn_up.MouseUp += (s, ev) => StopAxis();
            btn_down.MouseDown += (s, ev) => Jog(1);
            btn_down.MouseUp += (s, ev) => StopAxis();
            // 启动位置刷新
            timer_Pos.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer_Pos.Stop();
            base.OnFormClosing(e);
        }

        // ===== 点动 =====
        private void Jog(int direction)
        {
            if (DeviceManager?.Motion?.IsConnected != true) return;
            try
            {
                DeviceManager.Motion.ZAxis?.Jog(direction, 20f);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[FrmVM] Jog异常: {ex.Message}");
            }
        }

        private void StopAxis()
        {
            try
            {
                DeviceManager?.Motion?.ZAxis?.Stop();
            }
            catch { }
        }

        // ===== 位置刷新 =====
        private void timer_Pos_Tick(object sender, EventArgs e)
        {
            if (DeviceManager?.Motion?.IsConnected != true) return;
            try
            {
                float pos = DeviceManager.Motion.ZAxis?.CurrentPosition ?? 0;
                label2.Text = $"Z: {pos:F2}";
            }
            catch
            {
                label2.Text = "Z: --";
            }
        }

        // ===== 另存方案 =====
        private void btn_save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "另存视觉方案";
                dlg.Filter = "VM方案文件 (*.sol)|*.sol";
                dlg.DefaultExt = "sol";
                string solDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VmSol");
                if (Directory.Exists(solDir))
                    dlg.InitialDirectory = solDir;

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    VmSolution.SaveAs(dlg.FileName);
                    MessageBox.Show("方案保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"方案保存失败: {ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ===== 添加视觉方案 =====
        private void btn_addvm_Click(object sender, EventArgs e)
        {
            // 解除当前视觉方案占用
            try { vmMainViewConfigControl1.UnlockWorkArea(); } catch { }

            // 打开窗口选择方案
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "选择视觉方案文件";
                dlg.Filter = "VM方案文件 (*.sol)|*.sol";
                string solDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VmSol");
                if (Directory.Exists(solDir))
                    dlg.InitialDirectory = solDir;

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                // 加载视觉方案
                try
                {
                    VmSolution.Load(dlg.FileName);
                    vmMainViewConfigControl1.BindSingleProcedure("流程1");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"方案加载失败: {ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
