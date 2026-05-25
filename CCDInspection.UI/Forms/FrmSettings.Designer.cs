namespace CCDInspection.UI.Forms
{
    partial class FrmSettings
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txt_IpAddress;
        private System.Windows.Forms.TextBox txt_AutoSpeed;
        private System.Windows.Forms.TextBox txt_Acceleration;
        private System.Windows.Forms.TextBox txt_Deceleration;
        private System.Windows.Forms.TextBox txt_ManualSpeed;
        private System.Windows.Forms.TextBox txt_HomeSpeed;
        private System.Windows.Forms.NumericUpDown num_HomeModel;
        private System.Windows.Forms.NumericUpDown num_PosLimit;
        private System.Windows.Forms.NumericUpDown num_NegLimit;
        private System.Windows.Forms.TextBox txt_CameraSN;
        private System.Windows.Forms.NumericUpDown num_Exposure;
        private System.Windows.Forms.NumericUpDown num_Gain;
        private System.Windows.Forms.ComboBox cmb_TriggerMode;
        private System.Windows.Forms.TextBox txt_SolDir;
        private System.Windows.Forms.TextBox txt_ImagePath;
        private System.Windows.Forms.CheckBox chk_SaveOK;
        private System.Windows.Forms.CheckBox chk_SaveNG;
        private System.Windows.Forms.NumericUpDown num_LightDelay;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Text = "参数设置";
            this.Size = new System.Drawing.Size(550, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var tabControl = new System.Windows.Forms.TabControl();
            tabControl.Location = new System.Drawing.Point(10, 10);
            tabControl.Size = new System.Drawing.Size(515, 550);

            // === 轴配置页 ===
            var tabAxis = new System.Windows.Forms.TabPage("轴配置");
            int y = 15;

            txt_IpAddress = AddCtrl(tabAxis, "IP地址:", ref y, "192.168.0.11");
            txt_AutoSpeed = AddCtrl(tabAxis, "自动速度:", ref y, "50");
            txt_Acceleration = AddCtrl(tabAxis, "加速度:", ref y, "200");
            txt_Deceleration = AddCtrl(tabAxis, "减速度:", ref y, "200");
            txt_ManualSpeed = AddCtrl(tabAxis, "手动速度:", ref y, "30");
            txt_HomeSpeed = AddCtrl(tabAxis, "回零速度:", ref y, "50");

            num_HomeModel = AddNumeric(tabAxis, "回零模式:", ref y, 0, 50, 0);
            num_PosLimit = AddNumeric(tabAxis, "正软极限:", ref y, 0, 1000, 0);
            num_NegLimit = AddNumeric(tabAxis, "负软极限:", ref y, -1000, 0, 0);

            tabControl.TabPages.Add(tabAxis);

            // === 相机配置页 ===
            var tabCamera = new System.Windows.Forms.TabPage("相机配置");
            y = 15;

            txt_CameraSN = AddCtrl(tabCamera, "序列号:", ref y, "");
            num_Exposure = AddNumeric(tabCamera, "曝光(μs):", ref y, 1, 1000000, 1);
            num_Gain = AddNumeric(tabCamera, "增益:", ref y, 0, 100, 1);

            var lblTrigger = new System.Windows.Forms.Label();
            lblTrigger.Text = "触发模式:";
            lblTrigger.Location = new System.Drawing.Point(20, y);
            lblTrigger.Size = new System.Drawing.Size(80, 25);
            cmb_TriggerMode = new System.Windows.Forms.ComboBox();
            cmb_TriggerMode.Location = new System.Drawing.Point(110, y);
            cmb_TriggerMode.Size = new System.Drawing.Size(150, 25);
            cmb_TriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_TriggerMode.Items.AddRange(new object[] { "软触发", "硬触发", "连续采集" });
            cmb_TriggerMode.SelectedIndex = 0;
            tabCamera.Controls.Add(lblTrigger);
            tabCamera.Controls.Add(cmb_TriggerMode);
            y += 35;

            tabControl.TabPages.Add(tabCamera);

            // === 检测配置页 ===
            var tabInspection = new System.Windows.Forms.TabPage("检测配置");
            y = 15;

            txt_SolDir = AddCtrl(tabInspection, "方案目录:", ref y, "VisionSol");
            txt_ImagePath = AddCtrl(tabInspection, "图片保存路径:", ref y, @"D:\Images");

            chk_SaveOK = new System.Windows.Forms.CheckBox();
            chk_SaveOK.Text = "保存OK图片";
            chk_SaveOK.Location = new System.Drawing.Point(20, y);
            chk_SaveOK.Size = new System.Drawing.Size(120, 25);
            tabInspection.Controls.Add(chk_SaveOK);
            y += 30;

            chk_SaveNG = new System.Windows.Forms.CheckBox();
            chk_SaveNG.Text = "保存NG图片";
            chk_SaveNG.Checked = true;
            chk_SaveNG.Location = new System.Drawing.Point(20, y);
            chk_SaveNG.Size = new System.Drawing.Size(120, 25);
            tabInspection.Controls.Add(chk_SaveNG);
            y += 30;

            num_LightDelay = AddNumeric(tabInspection, "光源延时(ms):", ref y, 0, 5000, 1);

            tabControl.TabPages.Add(tabInspection);

            this.Controls.Add(tabControl);

            // 按钮
            btn_Save = new System.Windows.Forms.Button();
            btn_Save.Text = "保存";
            btn_Save.Location = new System.Drawing.Point(350, 570);
            btn_Save.Size = new System.Drawing.Size(80, 35);
            btn_Save.Click += new System.EventHandler(this.btn_Save_Click);

            btn_Cancel = new System.Windows.Forms.Button();
            btn_Cancel.Text = "取消";
            btn_Cancel.Location = new System.Drawing.Point(440, 570);
            btn_Cancel.Size = new System.Drawing.Size(80, 35);
            btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);

            this.Controls.Add(btn_Save);
            this.Controls.Add(btn_Cancel);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox AddCtrl(System.Windows.Forms.TabPage page, string label, ref int y, string defaultText)
        {
            var lbl = new System.Windows.Forms.Label();
            lbl.Text = label;
            lbl.Location = new System.Drawing.Point(20, y);
            lbl.Size = new System.Drawing.Size(80, 25);
            page.Controls.Add(lbl);

            var tb = new System.Windows.Forms.TextBox();
            tb.Location = new System.Drawing.Point(110, y);
            tb.Size = new System.Drawing.Size(150, 25);
            tb.Text = defaultText;
            page.Controls.Add(tb);

            y += 35;
            return tb;
        }

        private System.Windows.Forms.NumericUpDown AddNumeric(System.Windows.Forms.TabPage page, string label, ref int y, decimal min, decimal max, int decimals)
        {
            var lbl = new System.Windows.Forms.Label();
            lbl.Text = label;
            lbl.Location = new System.Drawing.Point(20, y);
            lbl.Size = new System.Drawing.Size(80, 25);
            page.Controls.Add(lbl);

            var num = new System.Windows.Forms.NumericUpDown();
            num.Location = new System.Drawing.Point(110, y);
            num.Size = new System.Drawing.Size(100, 25);
            num.Minimum = min;
            num.Maximum = max;
            num.DecimalPlaces = decimals;
            page.Controls.Add(num);

            y += 35;
            return num;
        }
    }
}
