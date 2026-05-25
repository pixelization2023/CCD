using System;
using System.IO;
using System.Windows.Forms;
using Autofac;
using CCDInspection.Core;
using CCDInspection.UI.Forms;

namespace CCDInspection.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var logDir = Path.Combine(Application.StartupPath, "Logs");
            LogService.Init(logDir);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                var container = CompositionRoot.BuildContainer();
                var loginForm = container.Resolve<FrmLogin>();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                LogService.Fatal(ex, "启动失败");
                MessageBox.Show($"启动失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LogService.Shutdown();
            }
        }
    }
}
