
using System;

namespace CCDInspection.UI.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox8 = new Sunny.UI.UIGroupBox();
            this.lbl_TotalResult = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslb_img = new System.Windows.Forms.ToolStripLabel();
            this.tslb_status = new System.Windows.Forms.ToolStripLabel();
            this.tslb_actionInfo = new System.Windows.Forms.ToolStripLabel();
            this.tslbl_InfoShow = new System.Windows.Forms.ToolStripLabel();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.btn_StartAutoTest = new Sunny.UI.UIButton();
            this.btn_StopAutoTest = new Sunny.UI.UIButton();
            this.btn_Login = new Sunny.UI.UIButton();
            this.Product_Label = new Sunny.UI.UILabel();
            this.lbl_MachineStatus = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.txt_SoftOptStatus = new System.Windows.Forms.RichTextBox();
            this.timer_IO = new System.Windows.Forms.Timer(this.components);
            this.timer_Axis = new System.Windows.Forms.Timer(this.components);
            this.cms_PathPlan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip_MoveToPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSetCurrentPos = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_AssistPosition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_ClearInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ClearInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_Home = new System.Windows.Forms.Timer(this.components);
            this.groip = new Sunny.UI.UIGroupBox();
            this.txt_AlarmInfo = new System.Windows.Forms.RichTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.uiGroupBox17 = new Sunny.UI.UIGroupBox();
            this.gb_AxisSet = new Sunny.UI.UIGroupBox();
            this.cmb_HomeModel = new Sunny.UI.UIComboBox();
            this.btn_SaveAxisBasicCnf = new Sunny.UI.UIButton();
            this.uiLabel22 = new Sunny.UI.UILabel();
            this.txt_SlowSpeed = new Sunny.UI.UITextBox();
            this.txt_HomeSpeed = new Sunny.UI.UITextBox();
            this.uiLabel31 = new Sunny.UI.UILabel();
            this.uiLabel44 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel67 = new Sunny.UI.UILabel();
            this.uiLabel61 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel46 = new Sunny.UI.UILabel();
            this.uiLabel66 = new Sunny.UI.UILabel();
            this.uiLabel60 = new Sunny.UI.UILabel();
            this.uiLabel47 = new Sunny.UI.UILabel();
            this.txt_PulseEquivalent = new Sunny.UI.UITextBox();
            this.txt_NegtivePoint = new Sunny.UI.UITextBox();
            this.txt_AutoSpeed = new Sunny.UI.UITextBox();
            this.txt_OriginPoint = new Sunny.UI.UITextBox();
            this.txt_AlarmPoint = new Sunny.UI.UITextBox();
            this.txt_PositiveSoftLimit = new Sunny.UI.UITextBox();
            this.txt_PositivePoint = new Sunny.UI.UITextBox();
            this.txt_Acceleration = new Sunny.UI.UITextBox();
            this.txt_Deceleration = new Sunny.UI.UITextBox();
            this.txt_NegativeSoftLimit = new Sunny.UI.UITextBox();
            this.uiGroupBox20 = new Sunny.UI.UIGroupBox();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckb_AxisEnable = new Sunny.UI.UICheckBox();
            this.btn_GoHome = new Sunny.UI.UIButton();
            this.txt_ManualSpeed = new Sunny.UI.UITextBox();
            this.btn_ZHome = new Sunny.UI.UIButton();
            this.btn_ClearAlarm = new Sunny.UI.UIButton();
            this.btn_AllAxisStop = new Sunny.UI.UIButton();
            this.btn_ZUp = new Sunny.UI.UIButton();
            this.btn_ZDown = new Sunny.UI.UIButton();
            this.label65 = new System.Windows.Forms.Label();
            this.uiLabel68 = new Sunny.UI.UILabel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.uiGroupBox18 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox23 = new Sunny.UI.UIGroupBox();
            this.switch_Gama = new Sunny.UI.UISwitch();
            this.txt_Gama = new Sunny.UI.UITextBox();
            this.txt_Gain = new Sunny.UI.UITextBox();
            this.txt_CameraSN1 = new Sunny.UI.UITextBox();
            this.txt_Exposure = new Sunny.UI.UITextBox();
            this.uiLabel49 = new Sunny.UI.UILabel();
            this.uiLabel50 = new Sunny.UI.UILabel();
            this.uiLabel53 = new Sunny.UI.UILabel();
            this.uiLabel54 = new Sunny.UI.UILabel();
            this.uiLabel55 = new Sunny.UI.UILabel();
            this.uiLabel51 = new Sunny.UI.UILabel();
            this.btnSoftTriOnce = new Sunny.UI.UIButton();
            this.cmb_TriggerModel = new Sunny.UI.UIComboBox();
            this.cmb_CameraSet = new Sunny.UI.UIComboBox();
            this.uiLabel52 = new Sunny.UI.UILabel();
            this.uiGroupBox24 = new Sunny.UI.UIGroupBox();
            this.vmFrontendControl1 = new VMControls.Winform.Release.VmFrontendControl();
            this.hWindow_Camera = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.uiTabControl3 = new Sunny.UI.UITabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.uiGroupBox7 = new Sunny.UI.UIGroupBox();
            this.SaveData_Button = new System.Windows.Forms.Button();
            this.Btn_DelConfig = new System.Windows.Forms.Button();
            this.Begin_AddPoint_Btm = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.uiGroupBox16 = new Sunny.UI.UIGroupBox();
            this.btn_CancelModyPassWord = new Sunny.UI.UIButton();
            this.btn_ModifyPassWord = new Sunny.UI.UIButton();
            this.cmb_UserName = new Sunny.UI.UIComboBox();
            this.txt_NewPassword = new Sunny.UI.UITextBox();
            this.txt_OriginPassword = new Sunny.UI.UITextBox();
            this.uiLabel59 = new Sunny.UI.UILabel();
            this.uiLabel57 = new Sunny.UI.UILabel();
            this.uiLabel58 = new Sunny.UI.UILabel();
            this.gb_CheckItems = new Sunny.UI.UIGroupBox();
            this.btn_SaveCheckItem = new Sunny.UI.UIButton();
            this.btn_DeleteCheckItem = new Sunny.UI.UIButton();
            this.btn_AddCheckItem = new Sunny.UI.UIButton();
            this.cmb_ItemEnable = new Sunny.UI.UIComboBox();
            this.uiLabel71 = new Sunny.UI.UILabel();
            this.uiLabel72 = new Sunny.UI.UILabel();
            this.txt_ItemContent = new Sunny.UI.UITextBox();
            this.uiLabel70 = new Sunny.UI.UILabel();
            this.txt_ItemIndex = new Sunny.UI.UITextBox();
            this.dgv_CheckItem = new Sunny.UI.UIDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.btn_ClearCurrentCount = new Sunny.UI.UIButton();
            this.label37 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.txt_CurrentOKCount = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txt_CurrentNGYeild = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txt_CurrentNGCount = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txt_CurrentCount = new System.Windows.Forms.TextBox();
            this.txt_CurrentOKYeild = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TotalOKCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TotalNGYeild = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TotalNGCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_TotalCount = new System.Windows.Forms.TextBox();
            this.txt_TotalOKYeild = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_ClearTotalCount = new Sunny.UI.UIButton();
            this.uiGroupBox13 = new Sunny.UI.UIGroupBox();
            this.uiLabel37 = new Sunny.UI.UILabel();
            this.uiTextBox18 = new Sunny.UI.UITextBox();
            this.uiLabel36 = new Sunny.UI.UILabel();
            this.uiTextBox17 = new Sunny.UI.UITextBox();
            this.uiLabel35 = new Sunny.UI.UILabel();
            this.uiTextBox16 = new Sunny.UI.UITextBox();
            this.uiLabel25 = new Sunny.UI.UILabel();
            this.uiTextBox12 = new Sunny.UI.UITextBox();
            this.uiLabel30 = new Sunny.UI.UILabel();
            this.uiLabel32 = new Sunny.UI.UILabel();
            this.uiTextBox13 = new Sunny.UI.UITextBox();
            this.uiLabel43 = new Sunny.UI.UILabel();
            this.uiLabel42 = new Sunny.UI.UILabel();
            this.uiLabel41 = new Sunny.UI.UILabel();
            this.uiLabel40 = new Sunny.UI.UILabel();
            this.uiLabel39 = new Sunny.UI.UILabel();
            this.uiLabel38 = new Sunny.UI.UILabel();
            this.uiLabel34 = new Sunny.UI.UILabel();
            this.uiLabel33 = new Sunny.UI.UILabel();
            this.uiTextBox14 = new Sunny.UI.UITextBox();
            this.uiTextBox15 = new Sunny.UI.UITextBox();
            this.gb_Optional = new Sunny.UI.UIGroupBox();
            this.ckb_ShieldLightCurtain = new Sunny.UI.UICheckBox();
            this.ckb_CylinderShield = new Sunny.UI.UICheckBox();
            this.ckb_SaveNGSourceImage = new Sunny.UI.UICheckBox();
            this.ckb_SaveSourceImage = new Sunny.UI.UICheckBox();
            this.ckb_ShieldBuzzer = new Sunny.UI.UICheckBox();
            this.ckb_CameraShieldI = new Sunny.UI.UICheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiGroupBox10 = new Sunny.UI.UIGroupBox();
            this.iO_In11 = new Application_UI.IO_In();
            this.iO_In7 = new Application_UI.IO_In();
            this.iO_In15 = new Application_UI.IO_In();
            this.iO_In3 = new Application_UI.IO_In();
            this.iO_In10 = new Application_UI.IO_In();
            this.iO_In6 = new Application_UI.IO_In();
            this.iO_In14 = new Application_UI.IO_In();
            this.iO_In2 = new Application_UI.IO_In();
            this.iO_In9 = new Application_UI.IO_In();
            this.iO_In5 = new Application_UI.IO_In();
            this.iO_In13 = new Application_UI.IO_In();
            this.iO_In1 = new Application_UI.IO_In();
            this.iO_In8 = new Application_UI.IO_In();
            this.iO_In4 = new Application_UI.IO_In();
            this.iO_In12 = new Application_UI.IO_In();
            this.iO_In0 = new Application_UI.IO_In();
            this.uiGroupBox9 = new Sunny.UI.UIGroupBox();
            this.iO_Out8 = new Application_UI.IO_Out();
            this.iO_Out0 = new Application_UI.IO_Out();
            this.iO_Out5 = new Application_UI.IO_Out();
            this.iO_Out9 = new Application_UI.IO_Out();
            this.iO_Out2 = new Application_UI.IO_Out();
            this.iO_Out10 = new Application_UI.IO_Out();
            this.iO_Out6 = new Application_UI.IO_Out();
            this.iO_Out11 = new Application_UI.IO_Out();
            this.iO_Out12 = new Application_UI.IO_Out();
            this.iO_Out3 = new Application_UI.IO_Out();
            this.iO_Out1 = new Application_UI.IO_Out();
            this.iO_Out13 = new Application_UI.IO_Out();
            this.iO_Out14 = new Application_UI.IO_Out();
            this.iO_Out15 = new Application_UI.IO_Out();
            this.iO_Out7 = new Application_UI.IO_Out();
            this.iO_Out4 = new Application_UI.IO_Out();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbTestResult = new System.Windows.Forms.GroupBox();
            this.rtb_TestResult = new System.Windows.Forms.RichTextBox();
            this.uiGroupBox15 = new Sunny.UI.UIGroupBox();
            this.vmRenderControl1 = new VMControls.Winform.Release.VmRenderControl();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.uiGroupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.uiGroupBox4.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.cms_PathPlan.SuspendLayout();
            this.cms_AssistPosition.SuspendLayout();
            this.cms_ClearInfo.SuspendLayout();
            this.groip.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.uiGroupBox17.SuspendLayout();
            this.gb_AxisSet.SuspendLayout();
            this.uiGroupBox20.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.uiGroupBox18.SuspendLayout();
            this.uiGroupBox23.SuspendLayout();
            this.uiGroupBox24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hWindow_Camera)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.uiTabControl3.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.uiGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage10.SuspendLayout();
            this.uiGroupBox16.SuspendLayout();
            this.gb_CheckItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CheckItem)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.uiGroupBox13.SuspendLayout();
            this.gb_Optional.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.uiGroupBox10.SuspendLayout();
            this.uiGroupBox9.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbTestResult.SuspendLayout();
            this.uiGroupBox15.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.uiGroupBox8);
            this.uiGroupBox3.Controls.Add(this.lbl_TotalResult);
            this.uiGroupBox3.Controls.Add(this.uiLabel8);
            this.uiGroupBox3.Controls.Add(this.uiLabel6);
            this.uiGroupBox3.Controls.Add(this.uiLabel5);
            this.uiGroupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.Location = new System.Drawing.Point(8, 331);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(376, 376);
            this.uiGroupBox3.TabIndex = 270;
            this.uiGroupBox3.Text = "图像显示";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox8
            // 
            this.uiGroupBox8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox8.Location = new System.Drawing.Point(5, 25);
            this.uiGroupBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox8.Name = "uiGroupBox8";
            this.uiGroupBox8.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox8.Size = new System.Drawing.Size(256, 226);
            this.uiGroupBox8.TabIndex = 270;
            this.uiGroupBox8.Text = "显示";
            this.uiGroupBox8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalResult
            // 
            this.lbl_TotalResult.BackColor = System.Drawing.Color.LightGreen;
            this.lbl_TotalResult.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_TotalResult.Location = new System.Drawing.Point(277, 209);
            this.lbl_TotalResult.Name = "lbl_TotalResult";
            this.lbl_TotalResult.Size = new System.Drawing.Size(88, 70);
            this.lbl_TotalResult.TabIndex = 263;
            this.lbl_TotalResult.Text = "OK";
            this.lbl_TotalResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(268, 168);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(97, 23);
            this.uiLabel8.TabIndex = 262;
            this.uiLabel8.Text = "总结果：";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(0, 0);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(100, 23);
            this.uiLabel6.TabIndex = 271;
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(0, 0);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(100, 23);
            this.uiLabel5.TabIndex = 272;
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslb_img,
            this.tslb_status,
            this.tslb_actionInfo,
            this.tslbl_InfoShow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 767);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1326, 33);
            this.toolStrip1.TabIndex = 240;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslb_img
            // 
            this.tslb_img.AutoSize = false;
            this.tslb_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tslb_img.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tslb_img.Name = "tslb_img";
            this.tslb_img.Size = new System.Drawing.Size(30, 30);
            this.tslb_img.Text = "toolStripLabel1";
            // 
            // tslb_status
            // 
            this.tslb_status.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslb_status.Name = "tslb_status";
            this.tslb_status.Size = new System.Drawing.Size(42, 30);
            this.tslb_status.Text = "就绪";
            // 
            // tslb_actionInfo
            // 
            this.tslb_actionInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslb_actionInfo.Name = "tslb_actionInfo";
            this.tslb_actionInfo.Size = new System.Drawing.Size(74, 30);
            this.tslb_actionInfo.Text = "动作信息";
            // 
            // tslbl_InfoShow
            // 
            this.tslbl_InfoShow.Name = "tslbl_InfoShow";
            this.tslbl_InfoShow.Size = new System.Drawing.Size(131, 30);
            this.tslbl_InfoShow.Text = "2026/05/10/ 09:36:34";
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.comboBox1);
            this.uiGroupBox2.Controls.Add(this.uiGroupBox4);
            this.uiGroupBox2.Controls.Add(this.Product_Label);
            this.uiGroupBox2.Controls.Add(this.lbl_MachineStatus);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(1041, 38);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(262, 593);
            this.uiGroupBox2.TabIndex = 241;
            this.uiGroupBox2.Text = "系统操作";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.btn_StartAutoTest);
            this.uiGroupBox4.Controls.Add(this.btn_StopAutoTest);
            this.uiGroupBox4.Controls.Add(this.btn_Login);
            this.uiGroupBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox4.Location = new System.Drawing.Point(10, 331);
            this.uiGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox4.Size = new System.Drawing.Size(248, 203);
            this.uiGroupBox4.TabIndex = 269;
            this.uiGroupBox4.Text = "动作配置";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_StartAutoTest
            // 
            this.btn_StartAutoTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StartAutoTest.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StartAutoTest.Location = new System.Drawing.Point(29, 35);
            this.btn_StartAutoTest.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_StartAutoTest.Name = "btn_StartAutoTest";
            this.btn_StartAutoTest.Size = new System.Drawing.Size(194, 47);
            this.btn_StartAutoTest.TabIndex = 0;
            this.btn_StartAutoTest.Text = "开始测试";
            this.btn_StartAutoTest.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StartAutoTest.Click += new System.EventHandler(this.btn_StartAutoTest_Click);
            // 
            // btn_StopAutoTest
            // 
            this.btn_StopAutoTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StopAutoTest.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StopAutoTest.Location = new System.Drawing.Point(29, 88);
            this.btn_StopAutoTest.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_StopAutoTest.Name = "btn_StopAutoTest";
            this.btn_StopAutoTest.Size = new System.Drawing.Size(194, 47);
            this.btn_StopAutoTest.TabIndex = 0;
            this.btn_StopAutoTest.Text = "停止测试";
            this.btn_StopAutoTest.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StopAutoTest.Click += new System.EventHandler(this.btn_StopAutoTest_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(29, 141);
            this.btn_Login.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(194, 47);
            this.btn_Login.TabIndex = 0;
            this.btn_Login.Text = "权限登录";
            this.btn_Login.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // Product_Label
            // 
            this.Product_Label.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Product_Label.Location = new System.Drawing.Point(5, 76);
            this.Product_Label.Name = "Product_Label";
            this.Product_Label.Size = new System.Drawing.Size(82, 17);
            this.Product_Label.TabIndex = 266;
            this.Product_Label.Text = "当前方案:";
            this.Product_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_MachineStatus
            // 
            this.lbl_MachineStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_MachineStatus.Location = new System.Drawing.Point(4, 33);
            this.lbl_MachineStatus.Name = "lbl_MachineStatus";
            this.lbl_MachineStatus.Size = new System.Drawing.Size(254, 28);
            this.lbl_MachineStatus.TabIndex = 264;
            this.lbl_MachineStatus.Text = "机台状态";
            this.lbl_MachineStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txt_SoftOptStatus);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(7, 640);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(584, 122);
            this.uiGroupBox1.TabIndex = 275;
            this.uiGroupBox1.Text = "设备状态";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_SoftOptStatus
            // 
            this.txt_SoftOptStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_SoftOptStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_SoftOptStatus.Location = new System.Drawing.Point(0, 32);
            this.txt_SoftOptStatus.Name = "txt_SoftOptStatus";
            this.txt_SoftOptStatus.Size = new System.Drawing.Size(584, 90);
            this.txt_SoftOptStatus.TabIndex = 24;
            this.txt_SoftOptStatus.Text = "";
            this.txt_SoftOptStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_SoftOptStatus_MouseDown);
            // 
            // timer_IO
            // 
            this.timer_IO.Tick += new System.EventHandler(this.timer_IO_Tick);
            // 
            // timer_Axis
            // 
            this.timer_Axis.Tick += new System.EventHandler(this.timer_Axis_Tick);
            // 
            // cms_PathPlan
            // 
            this.cms_PathPlan.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_PathPlan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_MoveToPosition,
            this.toolStripSetCurrentPos});
            this.cms_PathPlan.Name = "contextMenuStrip1";
            this.cms_PathPlan.Size = new System.Drawing.Size(149, 48);
            // 
            // toolStrip_MoveToPosition
            // 
            this.toolStrip_MoveToPosition.Name = "toolStrip_MoveToPosition";
            this.toolStrip_MoveToPosition.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_MoveToPosition.Text = "运动到";
            // 
            // toolStripSetCurrentPos
            // 
            this.toolStripSetCurrentPos.Name = "toolStripSetCurrentPos";
            this.toolStripSetCurrentPos.Size = new System.Drawing.Size(148, 22);
            this.toolStripSetCurrentPos.Text = "设为当前位置";
            // 
            // cms_AssistPosition
            // 
            this.cms_AssistPosition.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_AssistPosition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.cms_AssistPosition.Name = "contextMenuStrip1";
            this.cms_AssistPosition.Size = new System.Drawing.Size(149, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "运动到";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "设为当前位置";
            // 
            // cms_ClearInfo
            // 
            this.cms_ClearInfo.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_ClearInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ClearInfo});
            this.cms_ClearInfo.Name = "textMenuStrip_ClearInfo";
            this.cms_ClearInfo.Size = new System.Drawing.Size(125, 26);
            // 
            // toolStripMenuItem_ClearInfo
            // 
            this.toolStripMenuItem_ClearInfo.Name = "toolStripMenuItem_ClearInfo";
            this.toolStripMenuItem_ClearInfo.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_ClearInfo.Text = "清空信息";
            this.toolStripMenuItem_ClearInfo.Click += new System.EventHandler(this.toolStripMenuItem_ClearInfo_Click);
            // 
            // timer_Home
            // 
            this.timer_Home.Interval = 300;
            this.timer_Home.Tick += new System.EventHandler(this.timer_Home_Tick);
            // 
            // groip
            // 
            this.groip.Controls.Add(this.txt_AlarmInfo);
            this.groip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groip.Location = new System.Drawing.Point(601, 639);
            this.groip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groip.MinimumSize = new System.Drawing.Size(1, 1);
            this.groip.Name = "groip";
            this.groip.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.groip.Size = new System.Drawing.Size(584, 122);
            this.groip.TabIndex = 276;
            this.groip.Text = "报警信息";
            this.groip.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_AlarmInfo
            // 
            this.txt_AlarmInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_AlarmInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_AlarmInfo.Location = new System.Drawing.Point(0, 32);
            this.txt_AlarmInfo.Name = "txt_AlarmInfo";
            this.txt_AlarmInfo.Size = new System.Drawing.Size(584, 90);
            this.txt_AlarmInfo.TabIndex = 24;
            this.txt_AlarmInfo.Text = "";
            this.txt_AlarmInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_AlarmInfo_MouseDown);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.uiGroupBox17);
            this.tabPage6.Location = new System.Drawing.Point(0, 40);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(200, 60);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "运动控制";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox17
            // 
            this.uiGroupBox17.Controls.Add(this.gb_AxisSet);
            this.uiGroupBox17.Controls.Add(this.uiGroupBox20);
            this.uiGroupBox17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox17.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox17.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox17.Name = "uiGroupBox17";
            this.uiGroupBox17.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox17.Size = new System.Drawing.Size(1278, 519);
            this.uiGroupBox17.TabIndex = 0;
            this.uiGroupBox17.Text = "轴控";
            this.uiGroupBox17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_AxisSet
            // 
            this.gb_AxisSet.Controls.Add(this.cmb_HomeModel);
            this.gb_AxisSet.Controls.Add(this.btn_SaveAxisBasicCnf);
            this.gb_AxisSet.Controls.Add(this.uiLabel22);
            this.gb_AxisSet.Controls.Add(this.txt_SlowSpeed);
            this.gb_AxisSet.Controls.Add(this.txt_HomeSpeed);
            this.gb_AxisSet.Controls.Add(this.uiLabel31);
            this.gb_AxisSet.Controls.Add(this.uiLabel44);
            this.gb_AxisSet.Controls.Add(this.uiLabel1);
            this.gb_AxisSet.Controls.Add(this.uiLabel2);
            this.gb_AxisSet.Controls.Add(this.uiLabel3);
            this.gb_AxisSet.Controls.Add(this.uiLabel67);
            this.gb_AxisSet.Controls.Add(this.uiLabel61);
            this.gb_AxisSet.Controls.Add(this.uiLabel4);
            this.gb_AxisSet.Controls.Add(this.uiLabel46);
            this.gb_AxisSet.Controls.Add(this.uiLabel66);
            this.gb_AxisSet.Controls.Add(this.uiLabel60);
            this.gb_AxisSet.Controls.Add(this.uiLabel47);
            this.gb_AxisSet.Controls.Add(this.txt_PulseEquivalent);
            this.gb_AxisSet.Controls.Add(this.txt_NegtivePoint);
            this.gb_AxisSet.Controls.Add(this.txt_AutoSpeed);
            this.gb_AxisSet.Controls.Add(this.txt_OriginPoint);
            this.gb_AxisSet.Controls.Add(this.txt_AlarmPoint);
            this.gb_AxisSet.Controls.Add(this.txt_PositiveSoftLimit);
            this.gb_AxisSet.Controls.Add(this.txt_PositivePoint);
            this.gb_AxisSet.Controls.Add(this.txt_Acceleration);
            this.gb_AxisSet.Controls.Add(this.txt_Deceleration);
            this.gb_AxisSet.Controls.Add(this.txt_NegativeSoftLimit);
            this.gb_AxisSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_AxisSet.Location = new System.Drawing.Point(460, 31);
            this.gb_AxisSet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_AxisSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.gb_AxisSet.Name = "gb_AxisSet";
            this.gb_AxisSet.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.gb_AxisSet.Size = new System.Drawing.Size(525, 248);
            this.gb_AxisSet.TabIndex = 80;
            this.gb_AxisSet.Text = "轴基本参数";
            this.gb_AxisSet.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_HomeModel
            // 
            this.cmb_HomeModel.DataSource = null;
            this.cmb_HomeModel.FillColor = System.Drawing.Color.White;
            this.cmb_HomeModel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_HomeModel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "16"});
            this.cmb_HomeModel.Location = new System.Drawing.Point(330, 97);
            this.cmb_HomeModel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_HomeModel.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_HomeModel.Name = "cmb_HomeModel";
            this.cmb_HomeModel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_HomeModel.Size = new System.Drawing.Size(63, 27);
            this.cmb_HomeModel.TabIndex = 268;
            this.cmb_HomeModel.Text = "4";
            this.cmb_HomeModel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_HomeModel.Watermark = "";
            this.cmb_HomeModel.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // btn_SaveAxisBasicCnf
            // 
            this.btn_SaveAxisBasicCnf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveAxisBasicCnf.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveAxisBasicCnf.Location = new System.Drawing.Point(421, 18);
            this.btn_SaveAxisBasicCnf.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_SaveAxisBasicCnf.Name = "btn_SaveAxisBasicCnf";
            this.btn_SaveAxisBasicCnf.Size = new System.Drawing.Size(100, 35);
            this.btn_SaveAxisBasicCnf.TabIndex = 380;
            this.btn_SaveAxisBasicCnf.Text = "保存配置";
            this.btn_SaveAxisBasicCnf.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveAxisBasicCnf.Click += new System.EventHandler(this.btn_SaveAxisBasicCnf_Click);
            // 
            // uiLabel22
            // 
            this.uiLabel22.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel22.Location = new System.Drawing.Point(211, 18);
            this.uiLabel22.Name = "uiLabel22";
            this.uiLabel22.Size = new System.Drawing.Size(80, 35);
            this.uiLabel22.TabIndex = 265;
            this.uiLabel22.Text = "爬行速度";
            this.uiLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_SlowSpeed
            // 
            this.txt_SlowSpeed.ButtonSymbol = 61761;
            this.txt_SlowSpeed.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_SlowSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_SlowSpeed.DoubleValue = 10D;
            this.txt_SlowSpeed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_SlowSpeed.IntValue = 10;
            this.txt_SlowSpeed.Location = new System.Drawing.Point(330, 26);
            this.txt_SlowSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SlowSpeed.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_SlowSpeed.Name = "txt_SlowSpeed";
            this.txt_SlowSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txt_SlowSpeed.ShowText = false;
            this.txt_SlowSpeed.Size = new System.Drawing.Size(63, 27);
            this.txt_SlowSpeed.TabIndex = 263;
            this.txt_SlowSpeed.Text = "10";
            this.txt_SlowSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_SlowSpeed.Watermark = "";
            this.txt_SlowSpeed.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_HomeSpeed
            // 
            this.txt_HomeSpeed.ButtonSymbol = 61761;
            this.txt_HomeSpeed.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_HomeSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_HomeSpeed.DoubleValue = 50D;
            this.txt_HomeSpeed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_HomeSpeed.IntValue = 50;
            this.txt_HomeSpeed.Location = new System.Drawing.Point(330, 138);
            this.txt_HomeSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_HomeSpeed.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_HomeSpeed.Name = "txt_HomeSpeed";
            this.txt_HomeSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txt_HomeSpeed.ShowText = false;
            this.txt_HomeSpeed.Size = new System.Drawing.Size(62, 29);
            this.txt_HomeSpeed.TabIndex = 264;
            this.txt_HomeSpeed.Text = "50";
            this.txt_HomeSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_HomeSpeed.Watermark = "";
            this.txt_HomeSpeed.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // uiLabel31
            // 
            this.uiLabel31.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel31.Location = new System.Drawing.Point(252, 139);
            this.uiLabel31.Name = "uiLabel31";
            this.uiLabel31.Size = new System.Drawing.Size(78, 29);
            this.uiLabel31.TabIndex = 266;
            this.uiLabel31.Text = "回零速度";
            this.uiLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel44
            // 
            this.uiLabel44.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel44.Location = new System.Drawing.Point(252, 95);
            this.uiLabel44.Name = "uiLabel44";
            this.uiLabel44.Size = new System.Drawing.Size(78, 29);
            this.uiLabel44.TabIndex = 267;
            this.uiLabel44.Text = "回零模式";
            this.uiLabel44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(1, 68);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(74, 23);
            this.uiLabel1.TabIndex = 45;
            this.uiLabel1.Text = "脉冲当量";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(1, 101);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(74, 23);
            this.uiLabel2.TabIndex = 44;
            this.uiLabel2.Text = "自动速度";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(1, 138);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(74, 23);
            this.uiLabel3.TabIndex = 45;
            this.uiLabel3.Text = "正软极限";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel67
            // 
            this.uiLabel67.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel67.Location = new System.Drawing.Point(396, 101);
            this.uiLabel67.Name = "uiLabel67";
            this.uiLabel67.Size = new System.Drawing.Size(60, 23);
            this.uiLabel67.TabIndex = 45;
            this.uiLabel67.Text = "负极限";
            this.uiLabel67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel61
            // 
            this.uiLabel61.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel61.Location = new System.Drawing.Point(136, 140);
            this.uiLabel61.Name = "uiLabel61";
            this.uiLabel61.Size = new System.Drawing.Size(60, 23);
            this.uiLabel61.TabIndex = 45;
            this.uiLabel61.Text = "原点";
            this.uiLabel61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(133, 66);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(60, 23);
            this.uiLabel4.TabIndex = 45;
            this.uiLabel4.Text = "加速度";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel46
            // 
            this.uiLabel46.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel46.Location = new System.Drawing.Point(252, 57);
            this.uiLabel46.Name = "uiLabel46";
            this.uiLabel46.Size = new System.Drawing.Size(74, 23);
            this.uiLabel46.TabIndex = 45;
            this.uiLabel46.Text = "负软极限";
            this.uiLabel46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel66
            // 
            this.uiLabel66.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel66.Location = new System.Drawing.Point(396, 142);
            this.uiLabel66.Name = "uiLabel66";
            this.uiLabel66.Size = new System.Drawing.Size(60, 23);
            this.uiLabel66.TabIndex = 44;
            this.uiLabel66.Text = "报警";
            this.uiLabel66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel60
            // 
            this.uiLabel60.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel60.Location = new System.Drawing.Point(396, 57);
            this.uiLabel60.Name = "uiLabel60";
            this.uiLabel60.Size = new System.Drawing.Size(60, 23);
            this.uiLabel60.TabIndex = 44;
            this.uiLabel60.Text = "正极限";
            this.uiLabel60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel47
            // 
            this.uiLabel47.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel47.Location = new System.Drawing.Point(133, 101);
            this.uiLabel47.Name = "uiLabel47";
            this.uiLabel47.Size = new System.Drawing.Size(60, 23);
            this.uiLabel47.TabIndex = 44;
            this.uiLabel47.Text = "减速度";
            this.uiLabel47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_PulseEquivalent
            // 
            this.txt_PulseEquivalent.ButtonSymbol = 61761;
            this.txt_PulseEquivalent.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_PulseEquivalent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PulseEquivalent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PulseEquivalent.Location = new System.Drawing.Point(75, 64);
            this.txt_PulseEquivalent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PulseEquivalent.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_PulseEquivalent.Name = "txt_PulseEquivalent";
            this.txt_PulseEquivalent.Padding = new System.Windows.Forms.Padding(5);
            this.txt_PulseEquivalent.ShowText = false;
            this.txt_PulseEquivalent.Size = new System.Drawing.Size(52, 29);
            this.txt_PulseEquivalent.TabIndex = 43;
            this.txt_PulseEquivalent.Text = "0";
            this.txt_PulseEquivalent.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_PulseEquivalent.Watermark = "";
            this.txt_PulseEquivalent.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_NegtivePoint
            // 
            this.txt_NegtivePoint.ButtonSymbol = 61761;
            this.txt_NegtivePoint.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_NegtivePoint.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_NegtivePoint.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_NegtivePoint.Location = new System.Drawing.Point(456, 97);
            this.txt_NegtivePoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_NegtivePoint.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_NegtivePoint.Name = "txt_NegtivePoint";
            this.txt_NegtivePoint.Padding = new System.Windows.Forms.Padding(5);
            this.txt_NegtivePoint.ShowText = false;
            this.txt_NegtivePoint.Size = new System.Drawing.Size(56, 29);
            this.txt_NegtivePoint.TabIndex = 43;
            this.txt_NegtivePoint.Text = "0";
            this.txt_NegtivePoint.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_NegtivePoint.Watermark = "";
            this.txt_NegtivePoint.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_AutoSpeed
            // 
            this.txt_AutoSpeed.ButtonSymbol = 61761;
            this.txt_AutoSpeed.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_AutoSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_AutoSpeed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_AutoSpeed.Location = new System.Drawing.Point(75, 99);
            this.txt_AutoSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_AutoSpeed.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_AutoSpeed.Name = "txt_AutoSpeed";
            this.txt_AutoSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txt_AutoSpeed.ShowText = false;
            this.txt_AutoSpeed.Size = new System.Drawing.Size(52, 29);
            this.txt_AutoSpeed.TabIndex = 43;
            this.txt_AutoSpeed.Text = "0";
            this.txt_AutoSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_AutoSpeed.Watermark = "";
            this.txt_AutoSpeed.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_OriginPoint
            // 
            this.txt_OriginPoint.ButtonSymbol = 61761;
            this.txt_OriginPoint.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_OriginPoint.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_OriginPoint.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_OriginPoint.Location = new System.Drawing.Point(196, 136);
            this.txt_OriginPoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_OriginPoint.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_OriginPoint.Name = "txt_OriginPoint";
            this.txt_OriginPoint.Padding = new System.Windows.Forms.Padding(5);
            this.txt_OriginPoint.ShowText = false;
            this.txt_OriginPoint.Size = new System.Drawing.Size(51, 29);
            this.txt_OriginPoint.TabIndex = 43;
            this.txt_OriginPoint.Text = "0";
            this.txt_OriginPoint.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_OriginPoint.Watermark = "";
            this.txt_OriginPoint.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_AlarmPoint
            // 
            this.txt_AlarmPoint.ButtonSymbol = 61761;
            this.txt_AlarmPoint.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_AlarmPoint.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_AlarmPoint.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_AlarmPoint.Location = new System.Drawing.Point(456, 141);
            this.txt_AlarmPoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_AlarmPoint.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_AlarmPoint.Name = "txt_AlarmPoint";
            this.txt_AlarmPoint.Padding = new System.Windows.Forms.Padding(5);
            this.txt_AlarmPoint.ShowText = false;
            this.txt_AlarmPoint.Size = new System.Drawing.Size(56, 29);
            this.txt_AlarmPoint.TabIndex = 43;
            this.txt_AlarmPoint.Text = "0";
            this.txt_AlarmPoint.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_AlarmPoint.Watermark = "";
            this.txt_AlarmPoint.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_PositiveSoftLimit
            // 
            this.txt_PositiveSoftLimit.ButtonSymbol = 61761;
            this.txt_PositiveSoftLimit.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_PositiveSoftLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PositiveSoftLimit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PositiveSoftLimit.Location = new System.Drawing.Point(75, 135);
            this.txt_PositiveSoftLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PositiveSoftLimit.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_PositiveSoftLimit.Name = "txt_PositiveSoftLimit";
            this.txt_PositiveSoftLimit.Padding = new System.Windows.Forms.Padding(5);
            this.txt_PositiveSoftLimit.ShowText = false;
            this.txt_PositiveSoftLimit.Size = new System.Drawing.Size(52, 29);
            this.txt_PositiveSoftLimit.TabIndex = 43;
            this.txt_PositiveSoftLimit.Text = "0";
            this.txt_PositiveSoftLimit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_PositiveSoftLimit.Watermark = "";
            this.txt_PositiveSoftLimit.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_PositivePoint
            // 
            this.txt_PositivePoint.ButtonSymbol = 61761;
            this.txt_PositivePoint.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_PositivePoint.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PositivePoint.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PositivePoint.Location = new System.Drawing.Point(456, 56);
            this.txt_PositivePoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PositivePoint.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_PositivePoint.Name = "txt_PositivePoint";
            this.txt_PositivePoint.Padding = new System.Windows.Forms.Padding(5);
            this.txt_PositivePoint.ShowText = false;
            this.txt_PositivePoint.Size = new System.Drawing.Size(56, 29);
            this.txt_PositivePoint.TabIndex = 43;
            this.txt_PositivePoint.Text = "0";
            this.txt_PositivePoint.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_PositivePoint.Watermark = "";
            this.txt_PositivePoint.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_Acceleration
            // 
            this.txt_Acceleration.ButtonSymbol = 61761;
            this.txt_Acceleration.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_Acceleration.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Acceleration.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Acceleration.Location = new System.Drawing.Point(196, 60);
            this.txt_Acceleration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Acceleration.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Acceleration.Name = "txt_Acceleration";
            this.txt_Acceleration.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Acceleration.ShowText = false;
            this.txt_Acceleration.Size = new System.Drawing.Size(51, 29);
            this.txt_Acceleration.TabIndex = 43;
            this.txt_Acceleration.Text = "0";
            this.txt_Acceleration.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Acceleration.Watermark = "";
            this.txt_Acceleration.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_Deceleration
            // 
            this.txt_Deceleration.ButtonSymbol = 61761;
            this.txt_Deceleration.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_Deceleration.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Deceleration.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Deceleration.Location = new System.Drawing.Point(196, 97);
            this.txt_Deceleration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Deceleration.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Deceleration.Name = "txt_Deceleration";
            this.txt_Deceleration.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Deceleration.ShowText = false;
            this.txt_Deceleration.Size = new System.Drawing.Size(51, 29);
            this.txt_Deceleration.TabIndex = 43;
            this.txt_Deceleration.Text = "0";
            this.txt_Deceleration.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Deceleration.Watermark = "";
            this.txt_Deceleration.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // txt_NegativeSoftLimit
            // 
            this.txt_NegativeSoftLimit.ButtonSymbol = 61761;
            this.txt_NegativeSoftLimit.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_NegativeSoftLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_NegativeSoftLimit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_NegativeSoftLimit.Location = new System.Drawing.Point(330, 54);
            this.txt_NegativeSoftLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_NegativeSoftLimit.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_NegativeSoftLimit.Name = "txt_NegativeSoftLimit";
            this.txt_NegativeSoftLimit.Padding = new System.Windows.Forms.Padding(5);
            this.txt_NegativeSoftLimit.ShowText = false;
            this.txt_NegativeSoftLimit.Size = new System.Drawing.Size(62, 29);
            this.txt_NegativeSoftLimit.TabIndex = 43;
            this.txt_NegativeSoftLimit.Text = "0";
            this.txt_NegativeSoftLimit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_NegativeSoftLimit.Watermark = "";
            this.txt_NegativeSoftLimit.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // uiGroupBox20
            // 
            this.uiGroupBox20.Controls.Add(this.uiTextBox1);
            this.uiGroupBox20.Controls.Add(this.label4);
            this.uiGroupBox20.Controls.Add(this.ckb_AxisEnable);
            this.uiGroupBox20.Controls.Add(this.btn_GoHome);
            this.uiGroupBox20.Controls.Add(this.txt_ManualSpeed);
            this.uiGroupBox20.Controls.Add(this.btn_ZHome);
            this.uiGroupBox20.Controls.Add(this.btn_ClearAlarm);
            this.uiGroupBox20.Controls.Add(this.btn_AllAxisStop);
            this.uiGroupBox20.Controls.Add(this.btn_ZUp);
            this.uiGroupBox20.Controls.Add(this.btn_ZDown);
            this.uiGroupBox20.Controls.Add(this.label65);
            this.uiGroupBox20.Controls.Add(this.uiLabel68);
            this.uiGroupBox20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox20.Location = new System.Drawing.Point(8, 31);
            this.uiGroupBox20.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox20.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox20.Name = "uiGroupBox20";
            this.uiGroupBox20.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox20.Size = new System.Drawing.Size(447, 248);
            this.uiGroupBox20.TabIndex = 3;
            this.uiGroupBox20.Text = "手动";
            this.uiGroupBox20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.ButtonSymbol = 61761;
            this.uiTextBox1.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox1.Location = new System.Drawing.Point(89, 157);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(88, 35);
            this.uiTextBox1.TabIndex = 384;
            this.uiTextBox1.Text = "0";
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 383;
            this.label4.Text = "Z轴高度：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckb_AxisEnable
            // 
            this.ckb_AxisEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_AxisEnable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_AxisEnable.Location = new System.Drawing.Point(93, 69);
            this.ckb_AxisEnable.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_AxisEnable.Name = "ckb_AxisEnable";
            this.ckb_AxisEnable.Size = new System.Drawing.Size(88, 35);
            this.ckb_AxisEnable.TabIndex = 269;
            this.ckb_AxisEnable.Text = "Enable";
            this.ckb_AxisEnable.CheckedChanged += new System.EventHandler(this.ckb_AxisEnable_CheckedChanged);
            // 
            // btn_GoHome
            // 
            this.btn_GoHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_GoHome.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GoHome.Location = new System.Drawing.Point(221, 141);
            this.btn_GoHome.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_GoHome.Name = "btn_GoHome";
            this.btn_GoHome.Size = new System.Drawing.Size(104, 45);
            this.btn_GoHome.TabIndex = 382;
            this.btn_GoHome.Text = "轴回原点";
            this.btn_GoHome.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GoHome.Click += new System.EventHandler(this.btn_AllHome_Click);
            // 
            // txt_ManualSpeed
            // 
            this.txt_ManualSpeed.ButtonSymbol = 61761;
            this.txt_ManualSpeed.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_ManualSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ManualSpeed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ManualSpeed.Location = new System.Drawing.Point(93, 26);
            this.txt_ManualSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ManualSpeed.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_ManualSpeed.Name = "txt_ManualSpeed";
            this.txt_ManualSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txt_ManualSpeed.ShowText = false;
            this.txt_ManualSpeed.Size = new System.Drawing.Size(88, 35);
            this.txt_ManualSpeed.TabIndex = 381;
            this.txt_ManualSpeed.Text = "0";
            this.txt_ManualSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_ManualSpeed.Watermark = "";
            // 
            // btn_ZHome
            // 
            this.btn_ZHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ZHome.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ZHome.Location = new System.Drawing.Point(336, 25);
            this.btn_ZHome.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ZHome.Name = "btn_ZHome";
            this.btn_ZHome.Size = new System.Drawing.Size(104, 50);
            this.btn_ZHome.TabIndex = 380;
            this.btn_ZHome.Tag = "";
            this.btn_ZHome.Text = "Z复位";
            this.btn_ZHome.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ZHome.Click += new System.EventHandler(this.btn_ZHome_Click);
            // 
            // btn_ClearAlarm
            // 
            this.btn_ClearAlarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearAlarm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearAlarm.Location = new System.Drawing.Point(336, 83);
            this.btn_ClearAlarm.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ClearAlarm.Name = "btn_ClearAlarm";
            this.btn_ClearAlarm.Size = new System.Drawing.Size(104, 45);
            this.btn_ClearAlarm.TabIndex = 380;
            this.btn_ClearAlarm.Text = "清除报警";
            this.btn_ClearAlarm.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearAlarm.Click += new System.EventHandler(this.btn_ClearAlarm_Click);
            // 
            // btn_AllAxisStop
            // 
            this.btn_AllAxisStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AllAxisStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AllAxisStop.Location = new System.Drawing.Point(336, 141);
            this.btn_AllAxisStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_AllAxisStop.Name = "btn_AllAxisStop";
            this.btn_AllAxisStop.Size = new System.Drawing.Size(104, 45);
            this.btn_AllAxisStop.TabIndex = 380;
            this.btn_AllAxisStop.Text = "全部轴停止";
            this.btn_AllAxisStop.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AllAxisStop.Click += new System.EventHandler(this.btn_AllAxisStop_Click);
            // 
            // btn_ZUp
            // 
            this.btn_ZUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ZUp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ZUp.Location = new System.Drawing.Point(221, 26);
            this.btn_ZUp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ZUp.Name = "btn_ZUp";
            this.btn_ZUp.Size = new System.Drawing.Size(96, 50);
            this.btn_ZUp.TabIndex = 380;
            this.btn_ZUp.Tag = "Z";
            this.btn_ZUp.Text = "上";
            this.btn_ZUp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ZUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_ZUp_MouseDown);
            this.btn_ZUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_ZUp_MouseUp);
            // 
            // btn_ZDown
            // 
            this.btn_ZDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ZDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ZDown.Location = new System.Drawing.Point(221, 86);
            this.btn_ZDown.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ZDown.Name = "btn_ZDown";
            this.btn_ZDown.Size = new System.Drawing.Size(94, 50);
            this.btn_ZDown.TabIndex = 380;
            this.btn_ZDown.Tag = "Z";
            this.btn_ZDown.Text = "下";
            this.btn_ZDown.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ZDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_ZDown_MouseDown);
            this.btn_ZDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_ZDown_MouseUp);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label65.Location = new System.Drawing.Point(7, 35);
            this.label65.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(68, 20);
            this.label65.TabIndex = 372;
            this.label65.Text = "点动速度:";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel68
            // 
            this.uiLabel68.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel68.Location = new System.Drawing.Point(15, 70);
            this.uiLabel68.Name = "uiLabel68";
            this.uiLabel68.Size = new System.Drawing.Size(59, 23);
            this.uiLabel68.TabIndex = 44;
            this.uiLabel68.Text = "使  能";
            this.uiLabel68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.uiGroupBox18);
            this.tabPage5.Location = new System.Drawing.Point(0, 40);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(200, 60);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "图像处理";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox18
            // 
            this.uiGroupBox18.Controls.Add(this.uiGroupBox23);
            this.uiGroupBox18.Controls.Add(this.uiGroupBox24);
            this.uiGroupBox18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox18.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox18.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox18.Name = "uiGroupBox18";
            this.uiGroupBox18.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox18.Size = new System.Drawing.Size(1284, 712);
            this.uiGroupBox18.TabIndex = 273;
            this.uiGroupBox18.Text = "相机";
            this.uiGroupBox18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox23
            // 
            this.uiGroupBox23.Controls.Add(this.switch_Gama);
            this.uiGroupBox23.Controls.Add(this.txt_Gama);
            this.uiGroupBox23.Controls.Add(this.txt_Gain);
            this.uiGroupBox23.Controls.Add(this.txt_CameraSN1);
            this.uiGroupBox23.Controls.Add(this.txt_Exposure);
            this.uiGroupBox23.Controls.Add(this.uiLabel49);
            this.uiGroupBox23.Controls.Add(this.uiLabel50);
            this.uiGroupBox23.Controls.Add(this.uiLabel53);
            this.uiGroupBox23.Controls.Add(this.uiLabel54);
            this.uiGroupBox23.Controls.Add(this.uiLabel55);
            this.uiGroupBox23.Controls.Add(this.uiLabel51);
            this.uiGroupBox23.Controls.Add(this.btnSoftTriOnce);
            this.uiGroupBox23.Controls.Add(this.cmb_TriggerModel);
            this.uiGroupBox23.Controls.Add(this.cmb_CameraSet);
            this.uiGroupBox23.Controls.Add(this.uiLabel52);
            this.uiGroupBox23.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox23.Location = new System.Drawing.Point(802, 27);
            this.uiGroupBox23.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox23.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox23.Name = "uiGroupBox23";
            this.uiGroupBox23.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox23.Size = new System.Drawing.Size(198, 476);
            this.uiGroupBox23.TabIndex = 377;
            this.uiGroupBox23.Text = "操作";
            this.uiGroupBox23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // switch_Gama
            // 
            this.switch_Gama.ActiveText = "Enable";
            this.switch_Gama.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.switch_Gama.InActiveText = "Disable";
            this.switch_Gama.Location = new System.Drawing.Point(86, 364);
            this.switch_Gama.MinimumSize = new System.Drawing.Size(1, 1);
            this.switch_Gama.Name = "switch_Gama";
            this.switch_Gama.Size = new System.Drawing.Size(90, 29);
            this.switch_Gama.TabIndex = 5;
            this.switch_Gama.Text = "uiSwitch1";
            // 
            // txt_Gama
            // 
            this.txt_Gama.ButtonSymbol = 61761;
            this.txt_Gama.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_Gama.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Gama.DoubleValue = 1D;
            this.txt_Gama.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Gama.IntValue = 1;
            this.txt_Gama.Location = new System.Drawing.Point(86, 410);
            this.txt_Gama.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Gama.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Gama.Name = "txt_Gama";
            this.txt_Gama.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Gama.ShowText = false;
            this.txt_Gama.Size = new System.Drawing.Size(64, 29);
            this.txt_Gama.TabIndex = 4;
            this.txt_Gama.Text = "1";
            this.txt_Gama.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Gama.Watermark = "";
            // 
            // txt_Gain
            // 
            this.txt_Gain.ButtonSymbol = 61761;
            this.txt_Gain.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_Gain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Gain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Gain.Location = new System.Drawing.Point(86, 324);
            this.txt_Gain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Gain.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Gain.Name = "txt_Gain";
            this.txt_Gain.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Gain.ShowText = false;
            this.txt_Gain.Size = new System.Drawing.Size(74, 29);
            this.txt_Gain.TabIndex = 4;
            this.txt_Gain.Text = "0";
            this.txt_Gain.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Gain.Watermark = "";
            // 
            // txt_CameraSN1
            // 
            this.txt_CameraSN1.ButtonSymbol = 61761;
            this.txt_CameraSN1.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_CameraSN1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_CameraSN1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_CameraSN1.Location = new System.Drawing.Point(86, 124);
            this.txt_CameraSN1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_CameraSN1.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_CameraSN1.Multiline = true;
            this.txt_CameraSN1.Name = "txt_CameraSN1";
            this.txt_CameraSN1.Padding = new System.Windows.Forms.Padding(5);
            this.txt_CameraSN1.ShowText = false;
            this.txt_CameraSN1.Size = new System.Drawing.Size(108, 38);
            this.txt_CameraSN1.TabIndex = 4;
            this.txt_CameraSN1.Text = "DA1359793";
            this.txt_CameraSN1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_CameraSN1.Watermark = "";
            // 
            // txt_Exposure
            // 
            this.txt_Exposure.ButtonSymbol = 61761;
            this.txt_Exposure.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_Exposure.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Exposure.DoubleValue = 1000D;
            this.txt_Exposure.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Exposure.IntValue = 1000;
            this.txt_Exposure.Location = new System.Drawing.Point(86, 281);
            this.txt_Exposure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Exposure.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Exposure.Name = "txt_Exposure";
            this.txt_Exposure.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Exposure.ShowText = false;
            this.txt_Exposure.Size = new System.Drawing.Size(74, 29);
            this.txt_Exposure.TabIndex = 4;
            this.txt_Exposure.Text = "1000";
            this.txt_Exposure.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Exposure.Watermark = "";
            // 
            // uiLabel49
            // 
            this.uiLabel49.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel49.Location = new System.Drawing.Point(19, 413);
            this.uiLabel49.Name = "uiLabel49";
            this.uiLabel49.Size = new System.Drawing.Size(62, 23);
            this.uiLabel49.TabIndex = 3;
            this.uiLabel49.Text = "Gama：";
            this.uiLabel49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel50
            // 
            this.uiLabel50.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel50.Location = new System.Drawing.Point(19, 370);
            this.uiLabel50.Name = "uiLabel50";
            this.uiLabel50.Size = new System.Drawing.Size(62, 23);
            this.uiLabel50.TabIndex = 3;
            this.uiLabel50.Text = "Gama：";
            this.uiLabel50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel53
            // 
            this.uiLabel53.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel53.Location = new System.Drawing.Point(19, 200);
            this.uiLabel53.Name = "uiLabel53";
            this.uiLabel53.Size = new System.Drawing.Size(62, 23);
            this.uiLabel53.TabIndex = 3;
            this.uiLabel53.Text = "模式：";
            this.uiLabel53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel54
            // 
            this.uiLabel54.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel54.Location = new System.Drawing.Point(19, 327);
            this.uiLabel54.Name = "uiLabel54";
            this.uiLabel54.Size = new System.Drawing.Size(62, 23);
            this.uiLabel54.TabIndex = 3;
            this.uiLabel54.Text = "增益：";
            this.uiLabel54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel55
            // 
            this.uiLabel55.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel55.Location = new System.Drawing.Point(19, 139);
            this.uiLabel55.Name = "uiLabel55";
            this.uiLabel55.Size = new System.Drawing.Size(62, 23);
            this.uiLabel55.TabIndex = 3;
            this.uiLabel55.Text = "序号：";
            this.uiLabel55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel51
            // 
            this.uiLabel51.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel51.Location = new System.Drawing.Point(19, 284);
            this.uiLabel51.Name = "uiLabel51";
            this.uiLabel51.Size = new System.Drawing.Size(62, 23);
            this.uiLabel51.TabIndex = 3;
            this.uiLabel51.Text = "曝光：";
            this.uiLabel51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSoftTriOnce
            // 
            this.btnSoftTriOnce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoftTriOnce.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSoftTriOnce.Location = new System.Drawing.Point(86, 242);
            this.btnSoftTriOnce.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSoftTriOnce.Name = "btnSoftTriOnce";
            this.btnSoftTriOnce.Size = new System.Drawing.Size(78, 29);
            this.btnSoftTriOnce.TabIndex = 2;
            this.btnSoftTriOnce.Text = "软触发一次";
            this.btnSoftTriOnce.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // cmb_TriggerModel
            // 
            this.cmb_TriggerModel.DataSource = null;
            this.cmb_TriggerModel.FillColor = System.Drawing.Color.White;
            this.cmb_TriggerModel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_TriggerModel.Items.AddRange(new object[] {
            "软触发",
            "硬触发",
            "连续触发"});
            this.cmb_TriggerModel.Location = new System.Drawing.Point(86, 194);
            this.cmb_TriggerModel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_TriggerModel.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_TriggerModel.Name = "cmb_TriggerModel";
            this.cmb_TriggerModel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_TriggerModel.Size = new System.Drawing.Size(108, 29);
            this.cmb_TriggerModel.TabIndex = 1;
            this.cmb_TriggerModel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_TriggerModel.Watermark = "";
            // 
            // cmb_CameraSet
            // 
            this.cmb_CameraSet.DataSource = null;
            this.cmb_CameraSet.FillColor = System.Drawing.Color.White;
            this.cmb_CameraSet.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_CameraSet.Items.AddRange(new object[] {
            "相机1"});
            this.cmb_CameraSet.Location = new System.Drawing.Point(86, 63);
            this.cmb_CameraSet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_CameraSet.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_CameraSet.Name = "cmb_CameraSet";
            this.cmb_CameraSet.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_CameraSet.Size = new System.Drawing.Size(108, 34);
            this.cmb_CameraSet.TabIndex = 1;
            this.cmb_CameraSet.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_CameraSet.Watermark = "";
            // 
            // uiLabel52
            // 
            this.uiLabel52.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel52.Location = new System.Drawing.Point(19, 74);
            this.uiLabel52.Name = "uiLabel52";
            this.uiLabel52.Size = new System.Drawing.Size(62, 23);
            this.uiLabel52.TabIndex = 0;
            this.uiLabel52.Text = "相机：";
            this.uiLabel52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox24
            // 
            this.uiGroupBox24.Controls.Add(this.vmFrontendControl1);
            this.uiGroupBox24.Controls.Add(this.hWindow_Camera);
            this.uiGroupBox24.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox24.Location = new System.Drawing.Point(6, 27);
            this.uiGroupBox24.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox24.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox24.Name = "uiGroupBox24";
            this.uiGroupBox24.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox24.Size = new System.Drawing.Size(792, 475);
            this.uiGroupBox24.TabIndex = 376;
            this.uiGroupBox24.Text = "显示区";
            this.uiGroupBox24.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vmFrontendControl1
            // 
            this.vmFrontendControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmFrontendControl1.Location = new System.Drawing.Point(0, 32);
            this.vmFrontendControl1.Margin = new System.Windows.Forms.Padding(430128, 536384, 430128, 536384);
            this.vmFrontendControl1.Name = "vmFrontendControl1";
            this.vmFrontendControl1.Size = new System.Drawing.Size(792, 443);
            this.vmFrontendControl1.TabIndex = 1;
            // 
            // hWindow_Camera
            // 
            this.hWindow_Camera.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Camera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hWindow_Camera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Camera.Location = new System.Drawing.Point(0, 32);
            this.hWindow_Camera.Margin = new System.Windows.Forms.Padding(0);
            this.hWindow_Camera.Name = "hWindow_Camera";
            this.hWindow_Camera.Size = new System.Drawing.Size(792, 443);
            this.hWindow_Camera.TabIndex = 0;
            this.hWindow_Camera.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.uiTabControl3);
            this.tabPage4.Location = new System.Drawing.Point(0, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1034, 560);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "参数设置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // uiTabControl3
            // 
            this.uiTabControl3.Controls.Add(this.tabPage9);
            this.uiTabControl3.Controls.Add(this.tabPage10);
            this.uiTabControl3.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl3.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl3.Location = new System.Drawing.Point(7, 3);
            this.uiTabControl3.MainPage = "";
            this.uiTabControl3.Name = "uiTabControl3";
            this.uiTabControl3.SelectedIndex = 0;
            this.uiTabControl3.Size = new System.Drawing.Size(1276, 706);
            this.uiTabControl3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl3.TabIndex = 264;
            this.uiTabControl3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.uiGroupBox7);
            this.tabPage9.Location = new System.Drawing.Point(0, 40);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1276, 666);
            this.tabPage9.TabIndex = 0;
            this.tabPage9.Text = "型号设定";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox7
            // 
            this.uiGroupBox7.Controls.Add(this.SaveData_Button);
            this.uiGroupBox7.Controls.Add(this.Btn_DelConfig);
            this.uiGroupBox7.Controls.Add(this.Begin_AddPoint_Btm);
            this.uiGroupBox7.Controls.Add(this.dataGridView3);
            this.uiGroupBox7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox7.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox7.Name = "uiGroupBox7";
            this.uiGroupBox7.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox7.Size = new System.Drawing.Size(1268, 360);
            this.uiGroupBox7.TabIndex = 1;
            this.uiGroupBox7.Text = "产品型号设定";
            this.uiGroupBox7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveData_Button
            // 
            this.SaveData_Button.Font = new System.Drawing.Font("楷体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveData_Button.Location = new System.Drawing.Point(839, 156);
            this.SaveData_Button.Margin = new System.Windows.Forms.Padding(2);
            this.SaveData_Button.Name = "SaveData_Button";
            this.SaveData_Button.Size = new System.Drawing.Size(161, 55);
            this.SaveData_Button.TabIndex = 60;
            this.SaveData_Button.Text = "保存配置";
            this.SaveData_Button.UseVisualStyleBackColor = true;
            this.SaveData_Button.Click += new System.EventHandler(this.Begin_AddPlcPoint_Btm_Click);
            // 
            // Btn_DelConfig
            // 
            this.Btn_DelConfig.Font = new System.Drawing.Font("楷体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_DelConfig.Location = new System.Drawing.Point(839, 94);
            this.Btn_DelConfig.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_DelConfig.Name = "Btn_DelConfig";
            this.Btn_DelConfig.Size = new System.Drawing.Size(161, 55);
            this.Btn_DelConfig.TabIndex = 59;
            this.Btn_DelConfig.Text = "删除配置";
            this.Btn_DelConfig.UseVisualStyleBackColor = true;
            this.Btn_DelConfig.Click += new System.EventHandler(this.Begin_AddPlcPoint_Btm_Click);
            // 
            // Begin_AddPoint_Btm
            // 
            this.Begin_AddPoint_Btm.Font = new System.Drawing.Font("楷体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Begin_AddPoint_Btm.Location = new System.Drawing.Point(839, 32);
            this.Begin_AddPoint_Btm.Margin = new System.Windows.Forms.Padding(2);
            this.Begin_AddPoint_Btm.Name = "Begin_AddPoint_Btm";
            this.Begin_AddPoint_Btm.Size = new System.Drawing.Size(161, 55);
            this.Begin_AddPoint_Btm.TabIndex = 53;
            this.Begin_AddPoint_Btm.Text = "开始配置";
            this.Begin_AddPoint_Btm.UseVisualStyleBackColor = true;
            this.Begin_AddPoint_Btm.Click += new System.EventHandler(this.Begin_AddPlcPoint_Btm_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.Column4});
            this.dataGridView3.Location = new System.Drawing.Point(2, 32);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 62;
            this.dataGridView3.RowTemplate.Height = 30;
            this.dataGridView3.Size = new System.Drawing.Size(833, 319);
            this.dataGridView3.TabIndex = 50;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "产品型号";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 138;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "产品端口";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "公端",
            "母端"});
            this.dataGridViewComboBoxColumn1.MinimumWidth = 8;
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Width = 178;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "产品颜色";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 178;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "产品编码";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 188;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Z轴高度";
            this.Column4.Name = "Column4";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.uiGroupBox16);
            this.tabPage10.Controls.Add(this.gb_CheckItems);
            this.tabPage10.Location = new System.Drawing.Point(0, 40);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(200, 60);
            this.tabPage10.TabIndex = 1;
            this.tabPage10.Text = "登录、MES设定";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox16
            // 
            this.uiGroupBox16.Controls.Add(this.btn_CancelModyPassWord);
            this.uiGroupBox16.Controls.Add(this.btn_ModifyPassWord);
            this.uiGroupBox16.Controls.Add(this.cmb_UserName);
            this.uiGroupBox16.Controls.Add(this.txt_NewPassword);
            this.uiGroupBox16.Controls.Add(this.txt_OriginPassword);
            this.uiGroupBox16.Controls.Add(this.uiLabel59);
            this.uiGroupBox16.Controls.Add(this.uiLabel57);
            this.uiGroupBox16.Controls.Add(this.uiLabel58);
            this.uiGroupBox16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox16.Location = new System.Drawing.Point(948, 5);
            this.uiGroupBox16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox16.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox16.Name = "uiGroupBox16";
            this.uiGroupBox16.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox16.Size = new System.Drawing.Size(324, 375);
            this.uiGroupBox16.TabIndex = 0;
            this.uiGroupBox16.Text = "用户设置";
            this.uiGroupBox16.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_CancelModyPassWord
            // 
            this.btn_CancelModyPassWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CancelModyPassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CancelModyPassWord.Location = new System.Drawing.Point(194, 253);
            this.btn_CancelModyPassWord.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CancelModyPassWord.Name = "btn_CancelModyPassWord";
            this.btn_CancelModyPassWord.Size = new System.Drawing.Size(86, 42);
            this.btn_CancelModyPassWord.TabIndex = 281;
            this.btn_CancelModyPassWord.Text = "取    消";
            this.btn_CancelModyPassWord.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btn_ModifyPassWord
            // 
            this.btn_ModifyPassWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ModifyPassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModifyPassWord.Location = new System.Drawing.Point(45, 253);
            this.btn_ModifyPassWord.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ModifyPassWord.Name = "btn_ModifyPassWord";
            this.btn_ModifyPassWord.Size = new System.Drawing.Size(86, 42);
            this.btn_ModifyPassWord.TabIndex = 282;
            this.btn_ModifyPassWord.Text = "修    改";
            this.btn_ModifyPassWord.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModifyPassWord.Click += new System.EventHandler(this.btn_ModifyPassWord_Click);
            // 
            // cmb_UserName
            // 
            this.cmb_UserName.DataSource = null;
            this.cmb_UserName.FillColor = System.Drawing.Color.White;
            this.cmb_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_UserName.Items.AddRange(new object[] {
            "管理员"});
            this.cmb_UserName.Location = new System.Drawing.Point(114, 51);
            this.cmb_UserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_UserName.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_UserName.Name = "cmb_UserName";
            this.cmb_UserName.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_UserName.Size = new System.Drawing.Size(178, 27);
            this.cmb_UserName.TabIndex = 280;
            this.cmb_UserName.Text = "管理员";
            this.cmb_UserName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_UserName.Watermark = "";
            // 
            // txt_NewPassword
            // 
            this.txt_NewPassword.ButtonSymbol = 61761;
            this.txt_NewPassword.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_NewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_NewPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_NewPassword.Location = new System.Drawing.Point(114, 169);
            this.txt_NewPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_NewPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_NewPassword.Name = "txt_NewPassword";
            this.txt_NewPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txt_NewPassword.PasswordChar = '*';
            this.txt_NewPassword.ShowText = false;
            this.txt_NewPassword.Size = new System.Drawing.Size(178, 29);
            this.txt_NewPassword.TabIndex = 277;
            this.txt_NewPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_NewPassword.Watermark = "";
            // 
            // txt_OriginPassword
            // 
            this.txt_OriginPassword.ButtonSymbol = 61761;
            this.txt_OriginPassword.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_OriginPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_OriginPassword.DoubleValue = 123D;
            this.txt_OriginPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_OriginPassword.IntValue = 123;
            this.txt_OriginPassword.Location = new System.Drawing.Point(114, 106);
            this.txt_OriginPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_OriginPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_OriginPassword.Name = "txt_OriginPassword";
            this.txt_OriginPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txt_OriginPassword.ShowText = false;
            this.txt_OriginPassword.Size = new System.Drawing.Size(178, 29);
            this.txt_OriginPassword.TabIndex = 277;
            this.txt_OriginPassword.Text = "123";
            this.txt_OriginPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_OriginPassword.Watermark = "";
            // 
            // uiLabel59
            // 
            this.uiLabel59.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel59.Location = new System.Drawing.Point(16, 172);
            this.uiLabel59.Name = "uiLabel59";
            this.uiLabel59.Size = new System.Drawing.Size(91, 23);
            this.uiLabel59.TabIndex = 278;
            this.uiLabel59.Text = "新密码：";
            this.uiLabel59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel57
            // 
            this.uiLabel57.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel57.Location = new System.Drawing.Point(16, 109);
            this.uiLabel57.Name = "uiLabel57";
            this.uiLabel57.Size = new System.Drawing.Size(91, 23);
            this.uiLabel57.TabIndex = 278;
            this.uiLabel57.Text = "原密码：";
            this.uiLabel57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel58
            // 
            this.uiLabel58.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel58.Location = new System.Drawing.Point(16, 53);
            this.uiLabel58.Name = "uiLabel58";
            this.uiLabel58.Size = new System.Drawing.Size(91, 23);
            this.uiLabel58.TabIndex = 279;
            this.uiLabel58.Text = "权限：";
            this.uiLabel58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gb_CheckItems
            // 
            this.gb_CheckItems.Controls.Add(this.btn_SaveCheckItem);
            this.gb_CheckItems.Controls.Add(this.btn_DeleteCheckItem);
            this.gb_CheckItems.Controls.Add(this.btn_AddCheckItem);
            this.gb_CheckItems.Controls.Add(this.cmb_ItemEnable);
            this.gb_CheckItems.Controls.Add(this.uiLabel71);
            this.gb_CheckItems.Controls.Add(this.uiLabel72);
            this.gb_CheckItems.Controls.Add(this.txt_ItemContent);
            this.gb_CheckItems.Controls.Add(this.uiLabel70);
            this.gb_CheckItems.Controls.Add(this.txt_ItemIndex);
            this.gb_CheckItems.Controls.Add(this.dgv_CheckItem);
            this.gb_CheckItems.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_CheckItems.Location = new System.Drawing.Point(4, 5);
            this.gb_CheckItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_CheckItems.MinimumSize = new System.Drawing.Size(1, 1);
            this.gb_CheckItems.Name = "gb_CheckItems";
            this.gb_CheckItems.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.gb_CheckItems.Size = new System.Drawing.Size(936, 375);
            this.gb_CheckItems.TabIndex = 262;
            this.gb_CheckItems.Text = "检查项目";
            this.gb_CheckItems.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SaveCheckItem
            // 
            this.btn_SaveCheckItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveCheckItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveCheckItem.Location = new System.Drawing.Point(825, 283);
            this.btn_SaveCheckItem.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_SaveCheckItem.Name = "btn_SaveCheckItem";
            this.btn_SaveCheckItem.Size = new System.Drawing.Size(86, 42);
            this.btn_SaveCheckItem.TabIndex = 263;
            this.btn_SaveCheckItem.Text = "保    存";
            this.btn_SaveCheckItem.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveCheckItem.Click += new System.EventHandler(this.btn_SaveCheckItem_Click);
            // 
            // btn_DeleteCheckItem
            // 
            this.btn_DeleteCheckItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteCheckItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeleteCheckItem.Location = new System.Drawing.Point(825, 188);
            this.btn_DeleteCheckItem.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_DeleteCheckItem.Name = "btn_DeleteCheckItem";
            this.btn_DeleteCheckItem.Size = new System.Drawing.Size(86, 42);
            this.btn_DeleteCheckItem.TabIndex = 265;
            this.btn_DeleteCheckItem.Text = "删    除";
            this.btn_DeleteCheckItem.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeleteCheckItem.Click += new System.EventHandler(this.btn_DeleteCheckItem_Click);
            // 
            // btn_AddCheckItem
            // 
            this.btn_AddCheckItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddCheckItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddCheckItem.Location = new System.Drawing.Point(597, 188);
            this.btn_AddCheckItem.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_AddCheckItem.Name = "btn_AddCheckItem";
            this.btn_AddCheckItem.Size = new System.Drawing.Size(86, 42);
            this.btn_AddCheckItem.TabIndex = 266;
            this.btn_AddCheckItem.Text = "添    加";
            this.btn_AddCheckItem.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddCheckItem.Click += new System.EventHandler(this.btn_AddCheckItem_Click);
            // 
            // cmb_ItemEnable
            // 
            this.cmb_ItemEnable.DataSource = null;
            this.cmb_ItemEnable.FillColor = System.Drawing.Color.White;
            this.cmb_ItemEnable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_ItemEnable.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmb_ItemEnable.Location = new System.Drawing.Point(645, 38);
            this.cmb_ItemEnable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_ItemEnable.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_ItemEnable.Name = "cmb_ItemEnable";
            this.cmb_ItemEnable.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_ItemEnable.Size = new System.Drawing.Size(80, 29);
            this.cmb_ItemEnable.TabIndex = 262;
            this.cmb_ItemEnable.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_ItemEnable.Watermark = "";
            // 
            // uiLabel71
            // 
            this.uiLabel71.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel71.Location = new System.Drawing.Point(593, 41);
            this.uiLabel71.Name = "uiLabel71";
            this.uiLabel71.Size = new System.Drawing.Size(45, 23);
            this.uiLabel71.TabIndex = 261;
            this.uiLabel71.Text = "启用";
            this.uiLabel71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel72
            // 
            this.uiLabel72.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel72.Location = new System.Drawing.Point(593, 135);
            this.uiLabel72.Name = "uiLabel72";
            this.uiLabel72.Size = new System.Drawing.Size(45, 23);
            this.uiLabel72.TabIndex = 261;
            this.uiLabel72.Text = "内容";
            this.uiLabel72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_ItemContent
            // 
            this.txt_ItemContent.ButtonSymbol = 61761;
            this.txt_ItemContent.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_ItemContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ItemContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ItemContent.Location = new System.Drawing.Point(645, 133);
            this.txt_ItemContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ItemContent.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_ItemContent.Name = "txt_ItemContent";
            this.txt_ItemContent.Padding = new System.Windows.Forms.Padding(5);
            this.txt_ItemContent.ShowText = false;
            this.txt_ItemContent.Size = new System.Drawing.Size(266, 27);
            this.txt_ItemContent.TabIndex = 260;
            this.txt_ItemContent.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_ItemContent.Watermark = "";
            // 
            // uiLabel70
            // 
            this.uiLabel70.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel70.Location = new System.Drawing.Point(593, 88);
            this.uiLabel70.Name = "uiLabel70";
            this.uiLabel70.Size = new System.Drawing.Size(45, 23);
            this.uiLabel70.TabIndex = 261;
            this.uiLabel70.Text = "序号";
            this.uiLabel70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_ItemIndex
            // 
            this.txt_ItemIndex.ButtonSymbol = 61761;
            this.txt_ItemIndex.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_ItemIndex.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ItemIndex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ItemIndex.Location = new System.Drawing.Point(645, 86);
            this.txt_ItemIndex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ItemIndex.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_ItemIndex.Name = "txt_ItemIndex";
            this.txt_ItemIndex.Padding = new System.Windows.Forms.Padding(5);
            this.txt_ItemIndex.ShowText = false;
            this.txt_ItemIndex.Size = new System.Drawing.Size(77, 27);
            this.txt_ItemIndex.TabIndex = 260;
            this.txt_ItemIndex.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_ItemIndex.Watermark = "";
            // 
            // dgv_CheckItem
            // 
            this.dgv_CheckItem.AllowUserToAddRows = false;
            this.dgv_CheckItem.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_CheckItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_CheckItem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_CheckItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CheckItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_CheckItem.ColumnHeadersHeight = 32;
            this.dgv_CheckItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_CheckItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_CheckItem.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_CheckItem.EnableHeadersVisualStyles = false;
            this.dgv_CheckItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_CheckItem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgv_CheckItem.Location = new System.Drawing.Point(3, 29);
            this.dgv_CheckItem.Name = "dgv_CheckItem";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CheckItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_CheckItem.RowHeadersWidth = 62;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_CheckItem.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_CheckItem.RowTemplate.Height = 23;
            this.dgv_CheckItem.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgv_CheckItem.SelectedIndex = -1;
            this.dgv_CheckItem.Size = new System.Drawing.Size(517, 331);
            this.dgv_CheckItem.TabIndex = 38;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "启用";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "序号";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "内容";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 400;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Controls.Add(this.uiGroupBox13);
            this.tabPage3.Controls.Add(this.gb_Optional);
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1034, 560);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "功能与屏蔽";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Controls.Add(this.tabPage15);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(762, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(236, 375);
            this.tabControl1.TabIndex = 264;
            this.tabControl1.Visible = false;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.btn_ClearCurrentCount);
            this.tabPage14.Controls.Add(this.label37);
            this.tabPage14.Controls.Add(this.label48);
            this.tabPage14.Controls.Add(this.txt_CurrentOKCount);
            this.tabPage14.Controls.Add(this.label38);
            this.tabPage14.Controls.Add(this.txt_CurrentNGYeild);
            this.tabPage14.Controls.Add(this.label46);
            this.tabPage14.Controls.Add(this.txt_CurrentNGCount);
            this.tabPage14.Controls.Add(this.label44);
            this.tabPage14.Controls.Add(this.txt_CurrentCount);
            this.tabPage14.Controls.Add(this.txt_CurrentOKYeild);
            this.tabPage14.Controls.Add(this.label42);
            this.tabPage14.Controls.Add(this.label40);
            this.tabPage14.Location = new System.Drawing.Point(4, 26);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(228, 345);
            this.tabPage14.TabIndex = 0;
            this.tabPage14.Text = "当天产量";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // btn_ClearCurrentCount
            // 
            this.btn_ClearCurrentCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearCurrentCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearCurrentCount.Location = new System.Drawing.Point(24, 282);
            this.btn_ClearCurrentCount.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ClearCurrentCount.Name = "btn_ClearCurrentCount";
            this.btn_ClearCurrentCount.Size = new System.Drawing.Size(113, 27);
            this.btn_ClearCurrentCount.TabIndex = 262;
            this.btn_ClearCurrentCount.Text = "清除当天计数";
            this.btn_ClearCurrentCount.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(143, 256);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(14, 14);
            this.label37.TabIndex = 260;
            this.label37.Text = "%";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(24, 12);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(86, 17);
            this.label48.TabIndex = 254;
            this.label48.Text = "当天OK产品：";
            // 
            // txt_CurrentOKCount
            // 
            this.txt_CurrentOKCount.Location = new System.Drawing.Point(64, 36);
            this.txt_CurrentOKCount.Name = "txt_CurrentOKCount";
            this.txt_CurrentOKCount.Size = new System.Drawing.Size(93, 23);
            this.txt_CurrentOKCount.TabIndex = 259;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(143, 202);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(14, 14);
            this.label38.TabIndex = 261;
            this.label38.Text = "%";
            // 
            // txt_CurrentNGYeild
            // 
            this.txt_CurrentNGYeild.Location = new System.Drawing.Point(69, 252);
            this.txt_CurrentNGYeild.Name = "txt_CurrentNGYeild";
            this.txt_CurrentNGYeild.Size = new System.Drawing.Size(68, 23);
            this.txt_CurrentNGYeild.TabIndex = 255;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(24, 66);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(87, 17);
            this.label46.TabIndex = 253;
            this.label46.Text = "当天NG产品：";
            // 
            // txt_CurrentNGCount
            // 
            this.txt_CurrentNGCount.Location = new System.Drawing.Point(64, 90);
            this.txt_CurrentNGCount.Name = "txt_CurrentNGCount";
            this.txt_CurrentNGCount.Size = new System.Drawing.Size(93, 23);
            this.txt_CurrentNGCount.TabIndex = 258;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(24, 120);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(92, 17);
            this.label44.TabIndex = 252;
            this.label44.Text = "当天生产产品：";
            // 
            // txt_CurrentCount
            // 
            this.txt_CurrentCount.Location = new System.Drawing.Point(64, 144);
            this.txt_CurrentCount.Name = "txt_CurrentCount";
            this.txt_CurrentCount.Size = new System.Drawing.Size(93, 23);
            this.txt_CurrentCount.TabIndex = 257;
            // 
            // txt_CurrentOKYeild
            // 
            this.txt_CurrentOKYeild.Location = new System.Drawing.Point(69, 198);
            this.txt_CurrentOKYeild.Name = "txt_CurrentOKYeild";
            this.txt_CurrentOKYeild.Size = new System.Drawing.Size(68, 23);
            this.txt_CurrentOKYeild.TabIndex = 256;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(24, 174);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(68, 17);
            this.label42.TabIndex = 251;
            this.label42.Text = "当天良率：";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(24, 228);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(75, 17);
            this.label40.TabIndex = 250;
            this.label40.Text = "当天NG率：";
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.label1);
            this.tabPage15.Controls.Add(this.label2);
            this.tabPage15.Controls.Add(this.txt_TotalOKCount);
            this.tabPage15.Controls.Add(this.label3);
            this.tabPage15.Controls.Add(this.txt_TotalNGYeild);
            this.tabPage15.Controls.Add(this.label5);
            this.tabPage15.Controls.Add(this.txt_TotalNGCount);
            this.tabPage15.Controls.Add(this.label9);
            this.tabPage15.Controls.Add(this.txt_TotalCount);
            this.tabPage15.Controls.Add(this.txt_TotalOKYeild);
            this.tabPage15.Controls.Add(this.label10);
            this.tabPage15.Controls.Add(this.label11);
            this.tabPage15.Controls.Add(this.btn_ClearTotalCount);
            this.tabPage15.Location = new System.Drawing.Point(4, 26);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(228, 345);
            this.tabPage15.TabIndex = 1;
            this.tabPage15.Text = "总产量";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(136, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 291;
            this.label1.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 285;
            this.label2.Text = "总OK产品：";
            // 
            // txt_TotalOKCount
            // 
            this.txt_TotalOKCount.Location = new System.Drawing.Point(57, 39);
            this.txt_TotalOKCount.Name = "txt_TotalOKCount";
            this.txt_TotalOKCount.Size = new System.Drawing.Size(93, 23);
            this.txt_TotalOKCount.TabIndex = 290;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(136, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 292;
            this.label3.Text = "%";
            // 
            // txt_TotalNGYeild
            // 
            this.txt_TotalNGYeild.Location = new System.Drawing.Point(62, 255);
            this.txt_TotalNGYeild.Name = "txt_TotalNGYeild";
            this.txt_TotalNGYeild.Size = new System.Drawing.Size(68, 23);
            this.txt_TotalNGYeild.TabIndex = 286;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 284;
            this.label5.Text = "总NG产品：";
            // 
            // txt_TotalNGCount
            // 
            this.txt_TotalNGCount.Location = new System.Drawing.Point(57, 93);
            this.txt_TotalNGCount.Name = "txt_TotalNGCount";
            this.txt_TotalNGCount.Size = new System.Drawing.Size(93, 23);
            this.txt_TotalNGCount.TabIndex = 289;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 283;
            this.label9.Text = "总生产产品：";
            // 
            // txt_TotalCount
            // 
            this.txt_TotalCount.Location = new System.Drawing.Point(57, 147);
            this.txt_TotalCount.Name = "txt_TotalCount";
            this.txt_TotalCount.Size = new System.Drawing.Size(93, 23);
            this.txt_TotalCount.TabIndex = 288;
            // 
            // txt_TotalOKYeild
            // 
            this.txt_TotalOKYeild.Location = new System.Drawing.Point(62, 201);
            this.txt_TotalOKYeild.Name = "txt_TotalOKYeild";
            this.txt_TotalOKYeild.Size = new System.Drawing.Size(68, 23);
            this.txt_TotalOKYeild.TabIndex = 287;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 282;
            this.label10.Text = "总良率：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 17);
            this.label11.TabIndex = 281;
            this.label11.Text = "总NG率：";
            // 
            // btn_ClearTotalCount
            // 
            this.btn_ClearTotalCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearTotalCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearTotalCount.Location = new System.Drawing.Point(24, 292);
            this.btn_ClearTotalCount.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ClearTotalCount.Name = "btn_ClearTotalCount";
            this.btn_ClearTotalCount.Size = new System.Drawing.Size(113, 27);
            this.btn_ClearTotalCount.TabIndex = 280;
            this.btn_ClearTotalCount.Text = "清除总计数";
            this.btn_ClearTotalCount.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiGroupBox13
            // 
            this.uiGroupBox13.Controls.Add(this.uiLabel37);
            this.uiGroupBox13.Controls.Add(this.uiTextBox18);
            this.uiGroupBox13.Controls.Add(this.uiLabel36);
            this.uiGroupBox13.Controls.Add(this.uiTextBox17);
            this.uiGroupBox13.Controls.Add(this.uiLabel35);
            this.uiGroupBox13.Controls.Add(this.uiTextBox16);
            this.uiGroupBox13.Controls.Add(this.uiLabel25);
            this.uiGroupBox13.Controls.Add(this.uiTextBox12);
            this.uiGroupBox13.Controls.Add(this.uiLabel30);
            this.uiGroupBox13.Controls.Add(this.uiLabel32);
            this.uiGroupBox13.Controls.Add(this.uiTextBox13);
            this.uiGroupBox13.Controls.Add(this.uiLabel43);
            this.uiGroupBox13.Controls.Add(this.uiLabel42);
            this.uiGroupBox13.Controls.Add(this.uiLabel41);
            this.uiGroupBox13.Controls.Add(this.uiLabel40);
            this.uiGroupBox13.Controls.Add(this.uiLabel39);
            this.uiGroupBox13.Controls.Add(this.uiLabel38);
            this.uiGroupBox13.Controls.Add(this.uiLabel34);
            this.uiGroupBox13.Controls.Add(this.uiLabel33);
            this.uiGroupBox13.Controls.Add(this.uiTextBox14);
            this.uiGroupBox13.Controls.Add(this.uiTextBox15);
            this.uiGroupBox13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox13.Location = new System.Drawing.Point(351, 4);
            this.uiGroupBox13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox13.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox13.Name = "uiGroupBox13";
            this.uiGroupBox13.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox13.Size = new System.Drawing.Size(404, 376);
            this.uiGroupBox13.TabIndex = 260;
            this.uiGroupBox13.Text = "延迟设置";
            this.uiGroupBox13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox13.Visible = false;
            // 
            // uiLabel37
            // 
            this.uiLabel37.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel37.Location = new System.Drawing.Point(57, 234);
            this.uiLabel37.Name = "uiLabel37";
            this.uiLabel37.Size = new System.Drawing.Size(107, 23);
            this.uiLabel37.TabIndex = 264;
            this.uiLabel37.Text = "重置回原点计次";
            this.uiLabel37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox18
            // 
            this.uiTextBox18.ButtonSymbol = 61761;
            this.uiTextBox18.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.uiTextBox18.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox18.Location = new System.Drawing.Point(171, 231);
            this.uiTextBox18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox18.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox18.Name = "uiTextBox18";
            this.uiTextBox18.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox18.ShowText = false;
            this.uiTextBox18.Size = new System.Drawing.Size(92, 29);
            this.uiTextBox18.TabIndex = 260;
            this.uiTextBox18.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox18.Watermark = "";
            // 
            // uiLabel36
            // 
            this.uiLabel36.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel36.Location = new System.Drawing.Point(58, 198);
            this.uiLabel36.Name = "uiLabel36";
            this.uiLabel36.Size = new System.Drawing.Size(107, 23);
            this.uiLabel36.TabIndex = 264;
            this.uiLabel36.Text = "扫码超时时间";
            this.uiLabel36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox17
            // 
            this.uiTextBox17.ButtonSymbol = 61761;
            this.uiTextBox17.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.uiTextBox17.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox17.Location = new System.Drawing.Point(172, 195);
            this.uiTextBox17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox17.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox17.Name = "uiTextBox17";
            this.uiTextBox17.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox17.ShowText = false;
            this.uiTextBox17.Size = new System.Drawing.Size(92, 29);
            this.uiTextBox17.TabIndex = 260;
            this.uiTextBox17.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox17.Watermark = "";
            // 
            // uiLabel35
            // 
            this.uiLabel35.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel35.Location = new System.Drawing.Point(57, 164);
            this.uiLabel35.Name = "uiLabel35";
            this.uiLabel35.Size = new System.Drawing.Size(107, 23);
            this.uiLabel35.TabIndex = 264;
            this.uiLabel35.Text = "扫码触发时间";
            this.uiLabel35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox16
            // 
            this.uiTextBox16.ButtonSymbol = 61761;
            this.uiTextBox16.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.uiTextBox16.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox16.Location = new System.Drawing.Point(171, 160);
            this.uiTextBox16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox16.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox16.Name = "uiTextBox16";
            this.uiTextBox16.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox16.ShowText = false;
            this.uiTextBox16.Size = new System.Drawing.Size(92, 29);
            this.uiTextBox16.TabIndex = 260;
            this.uiTextBox16.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox16.Watermark = "";
            // 
            // uiLabel25
            // 
            this.uiLabel25.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel25.Location = new System.Drawing.Point(58, 130);
            this.uiLabel25.Name = "uiLabel25";
            this.uiLabel25.Size = new System.Drawing.Size(107, 23);
            this.uiLabel25.TabIndex = 264;
            this.uiLabel25.Text = "出板超时检测";
            this.uiLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox12
            // 
            this.uiTextBox12.ButtonSymbol = 61761;
            this.uiTextBox12.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.uiTextBox12.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox12.Location = new System.Drawing.Point(172, 127);
            this.uiTextBox12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox12.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox12.Name = "uiTextBox12";
            this.uiTextBox12.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox12.ShowText = false;
            this.uiTextBox12.Size = new System.Drawing.Size(92, 29);
            this.uiTextBox12.TabIndex = 260;
            this.uiTextBox12.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox12.Watermark = "";
            // 
            // uiLabel30
            // 
            this.uiLabel30.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel30.Location = new System.Drawing.Point(58, 100);
            this.uiLabel30.Name = "uiLabel30";
            this.uiLabel30.Size = new System.Drawing.Size(107, 23);
            this.uiLabel30.TabIndex = 265;
            this.uiLabel30.Text = "进板检测延时";
            this.uiLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel32
            // 
            this.uiLabel32.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel32.Location = new System.Drawing.Point(89, 66);
            this.uiLabel32.Name = "uiLabel32";
            this.uiLabel32.Size = new System.Drawing.Size(75, 23);
            this.uiLabel32.TabIndex = 266;
            this.uiLabel32.Text = "出板延时";
            this.uiLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox13
            // 
            this.uiTextBox13.ButtonSymbol = 61761;
            this.uiTextBox13.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.uiTextBox13.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox13.Location = new System.Drawing.Point(172, 93);
            this.uiTextBox13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox13.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox13.Name = "uiTextBox13";
            this.uiTextBox13.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox13.ShowText = false;
            this.uiTextBox13.Size = new System.Drawing.Size(92, 29);
            this.uiTextBox13.TabIndex = 261;
            this.uiTextBox13.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox13.Watermark = "";
            // 
            // uiLabel43
            // 
            this.uiLabel43.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel43.Location = new System.Drawing.Point(270, 234);
            this.uiLabel43.Name = "uiLabel43";
            this.uiLabel43.Size = new System.Drawing.Size(27, 23);
            this.uiLabel43.TabIndex = 267;
            this.uiLabel43.Text = "次";
            this.uiLabel43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel42
            // 
            this.uiLabel42.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel42.Location = new System.Drawing.Point(271, 198);
            this.uiLabel42.Name = "uiLabel42";
            this.uiLabel42.Size = new System.Drawing.Size(27, 23);
            this.uiLabel42.TabIndex = 267;
            this.uiLabel42.Text = "秒";
            this.uiLabel42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel41
            // 
            this.uiLabel41.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel41.Location = new System.Drawing.Point(270, 163);
            this.uiLabel41.Name = "uiLabel41";
            this.uiLabel41.Size = new System.Drawing.Size(27, 23);
            this.uiLabel41.TabIndex = 267;
            this.uiLabel41.Text = "秒";
            this.uiLabel41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel40
            // 
            this.uiLabel40.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel40.Location = new System.Drawing.Point(271, 130);
            this.uiLabel40.Name = "uiLabel40";
            this.uiLabel40.Size = new System.Drawing.Size(27, 23);
            this.uiLabel40.TabIndex = 267;
            this.uiLabel40.Text = "秒";
            this.uiLabel40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel39
            // 
            this.uiLabel39.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel39.Location = new System.Drawing.Point(271, 96);
            this.uiLabel39.Name = "uiLabel39";
            this.uiLabel39.Size = new System.Drawing.Size(27, 23);
            this.uiLabel39.TabIndex = 267;
            this.uiLabel39.Text = "秒";
            this.uiLabel39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel38
            // 
            this.uiLabel38.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel38.Location = new System.Drawing.Point(270, 64);
            this.uiLabel38.Name = "uiLabel38";
            this.uiLabel38.Size = new System.Drawing.Size(27, 23);
            this.uiLabel38.TabIndex = 267;
            this.uiLabel38.Text = "秒";
            this.uiLabel38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel34
            // 
            this.uiLabel34.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel34.Location = new System.Drawing.Point(271, 32);
            this.uiLabel34.Name = "uiLabel34";
            this.uiLabel34.Size = new System.Drawing.Size(27, 23);
            this.uiLabel34.TabIndex = 267;
            this.uiLabel34.Text = "秒";
            this.uiLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel33
            // 
            this.uiLabel33.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel33.Location = new System.Drawing.Point(89, 32);
            this.uiLabel33.Name = "uiLabel33";
            this.uiLabel33.Size = new System.Drawing.Size(76, 23);
            this.uiLabel33.TabIndex = 267;
            this.uiLabel33.Text = "停板延时";
            this.uiLabel33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox14
            // 
            this.uiTextBox14.ButtonSymbol = 61761;
            this.uiTextBox14.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.uiTextBox14.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox14.Location = new System.Drawing.Point(172, 61);
            this.uiTextBox14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox14.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox14.Name = "uiTextBox14";
            this.uiTextBox14.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox14.ShowText = false;
            this.uiTextBox14.Size = new System.Drawing.Size(92, 29);
            this.uiTextBox14.TabIndex = 262;
            this.uiTextBox14.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox14.Watermark = "";
            // 
            // uiTextBox15
            // 
            this.uiTextBox15.ButtonSymbol = 61761;
            this.uiTextBox15.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.uiTextBox15.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox15.Location = new System.Drawing.Point(172, 29);
            this.uiTextBox15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox15.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox15.Name = "uiTextBox15";
            this.uiTextBox15.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox15.ShowText = false;
            this.uiTextBox15.Size = new System.Drawing.Size(92, 29);
            this.uiTextBox15.TabIndex = 263;
            this.uiTextBox15.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox15.Watermark = "";
            // 
            // gb_Optional
            // 
            this.gb_Optional.Controls.Add(this.ckb_ShieldLightCurtain);
            this.gb_Optional.Controls.Add(this.ckb_CylinderShield);
            this.gb_Optional.Controls.Add(this.ckb_SaveNGSourceImage);
            this.gb_Optional.Controls.Add(this.ckb_SaveSourceImage);
            this.gb_Optional.Controls.Add(this.ckb_ShieldBuzzer);
            this.gb_Optional.Controls.Add(this.ckb_CameraShieldI);
            this.gb_Optional.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_Optional.Location = new System.Drawing.Point(3, 6);
            this.gb_Optional.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_Optional.MinimumSize = new System.Drawing.Size(1, 1);
            this.gb_Optional.Name = "gb_Optional";
            this.gb_Optional.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.gb_Optional.Size = new System.Drawing.Size(338, 374);
            this.gb_Optional.TabIndex = 261;
            this.gb_Optional.Text = "功能选择";
            this.gb_Optional.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckb_ShieldLightCurtain
            // 
            this.ckb_ShieldLightCurtain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_ShieldLightCurtain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_ShieldLightCurtain.Location = new System.Drawing.Point(13, 102);
            this.ckb_ShieldLightCurtain.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_ShieldLightCurtain.Name = "ckb_ShieldLightCurtain";
            this.ckb_ShieldLightCurtain.Size = new System.Drawing.Size(95, 29);
            this.ckb_ShieldLightCurtain.TabIndex = 2;
            this.ckb_ShieldLightCurtain.Text = "屏蔽光栅";
            this.ckb_ShieldLightCurtain.CheckedChanged += new System.EventHandler(this.ckb_ShieldLightCurtain_CheckedChanged);
            // 
            // ckb_CylinderShield
            // 
            this.ckb_CylinderShield.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_CylinderShield.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_CylinderShield.Location = new System.Drawing.Point(13, 141);
            this.ckb_CylinderShield.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_CylinderShield.Name = "ckb_CylinderShield";
            this.ckb_CylinderShield.Size = new System.Drawing.Size(95, 29);
            this.ckb_CylinderShield.TabIndex = 1;
            this.ckb_CylinderShield.Text = "气缸屏蔽";
            this.ckb_CylinderShield.CheckedChanged += new System.EventHandler(this.ckb_CylinderShield_CheckedChanged);
            // 
            // ckb_SaveNGSourceImage
            // 
            this.ckb_SaveNGSourceImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_SaveNGSourceImage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_SaveNGSourceImage.Location = new System.Drawing.Point(165, 59);
            this.ckb_SaveNGSourceImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_SaveNGSourceImage.Name = "ckb_SaveNGSourceImage";
            this.ckb_SaveNGSourceImage.Size = new System.Drawing.Size(127, 29);
            this.ckb_SaveNGSourceImage.TabIndex = 0;
            this.ckb_SaveNGSourceImage.Text = "保存NG原图";
            this.ckb_SaveNGSourceImage.CheckedChanged += new System.EventHandler(this.ckb_SaveNGSourceImage_CheckedChanged);
            // 
            // ckb_SaveSourceImage
            // 
            this.ckb_SaveSourceImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_SaveSourceImage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_SaveSourceImage.Location = new System.Drawing.Point(165, 24);
            this.ckb_SaveSourceImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_SaveSourceImage.Name = "ckb_SaveSourceImage";
            this.ckb_SaveSourceImage.Size = new System.Drawing.Size(95, 29);
            this.ckb_SaveSourceImage.TabIndex = 0;
            this.ckb_SaveSourceImage.Text = "保存原图";
            this.ckb_SaveSourceImage.CheckedChanged += new System.EventHandler(this.ckb_SaveSourceImage_CheckedChanged);
            // 
            // ckb_ShieldBuzzer
            // 
            this.ckb_ShieldBuzzer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_ShieldBuzzer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_ShieldBuzzer.Location = new System.Drawing.Point(13, 64);
            this.ckb_ShieldBuzzer.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_ShieldBuzzer.Name = "ckb_ShieldBuzzer";
            this.ckb_ShieldBuzzer.Size = new System.Drawing.Size(117, 29);
            this.ckb_ShieldBuzzer.TabIndex = 0;
            this.ckb_ShieldBuzzer.Text = "屏蔽蜂鸣器";
            this.ckb_ShieldBuzzer.CheckedChanged += new System.EventHandler(this.ckb_ShieldBuzzer_CheckedChanged);
            // 
            // ckb_CameraShieldI
            // 
            this.ckb_CameraShieldI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_CameraShieldI.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_CameraShieldI.Location = new System.Drawing.Point(13, 24);
            this.ckb_CameraShieldI.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_CameraShieldI.Name = "ckb_CameraShieldI";
            this.ckb_CameraShieldI.Size = new System.Drawing.Size(127, 29);
            this.ckb_CameraShieldI.TabIndex = 0;
            this.ckb_CameraShieldI.Text = "屏蔽相机";
            this.ckb_CameraShieldI.CheckedChanged += new System.EventHandler(this.ckb_CameraShieldI_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uiGroupBox10);
            this.tabPage2.Controls.Add(this.uiGroupBox9);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 60);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "IO界面";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox10
            // 
            this.uiGroupBox10.Controls.Add(this.iO_In11);
            this.uiGroupBox10.Controls.Add(this.iO_In7);
            this.uiGroupBox10.Controls.Add(this.iO_In15);
            this.uiGroupBox10.Controls.Add(this.iO_In3);
            this.uiGroupBox10.Controls.Add(this.iO_In10);
            this.uiGroupBox10.Controls.Add(this.iO_In6);
            this.uiGroupBox10.Controls.Add(this.iO_In14);
            this.uiGroupBox10.Controls.Add(this.iO_In2);
            this.uiGroupBox10.Controls.Add(this.iO_In9);
            this.uiGroupBox10.Controls.Add(this.iO_In5);
            this.uiGroupBox10.Controls.Add(this.iO_In13);
            this.uiGroupBox10.Controls.Add(this.iO_In1);
            this.uiGroupBox10.Controls.Add(this.iO_In8);
            this.uiGroupBox10.Controls.Add(this.iO_In4);
            this.uiGroupBox10.Controls.Add(this.iO_In12);
            this.uiGroupBox10.Controls.Add(this.iO_In0);
            this.uiGroupBox10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox10.Location = new System.Drawing.Point(4, 7);
            this.uiGroupBox10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox10.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox10.Name = "uiGroupBox10";
            this.uiGroupBox10.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox10.Size = new System.Drawing.Size(455, 486);
            this.uiGroupBox10.TabIndex = 91;
            this.uiGroupBox10.Text = "输入";
            this.uiGroupBox10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iO_In11
            // 
            this.iO_In11.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In11.IOIndex = 11;
            this.iO_In11.IOName = "输入1";
            this.iO_In11.Location = new System.Drawing.Point(3, 441);
            this.iO_In11.Name = "iO_In11";
            this.iO_In11.Size = new System.Drawing.Size(200, 32);
            this.iO_In11.TabIndex = 57;
            this.iO_In11.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In7
            // 
            this.iO_In7.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In7.IOIndex = 7;
            this.iO_In7.IOName = "输入1";
            this.iO_In7.Location = new System.Drawing.Point(3, 293);
            this.iO_In7.Name = "iO_In7";
            this.iO_In7.Size = new System.Drawing.Size(200, 32);
            this.iO_In7.TabIndex = 57;
            this.iO_In7.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In15
            // 
            this.iO_In15.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In15.IOIndex = 15;
            this.iO_In15.IOName = "输入1";
            this.iO_In15.Location = new System.Drawing.Point(243, 144);
            this.iO_In15.Name = "iO_In15";
            this.iO_In15.Size = new System.Drawing.Size(200, 32);
            this.iO_In15.TabIndex = 57;
            this.iO_In15.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In3
            // 
            this.iO_In3.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In3.IOIndex = 3;
            this.iO_In3.IOName = "输入1";
            this.iO_In3.Location = new System.Drawing.Point(3, 144);
            this.iO_In3.Name = "iO_In3";
            this.iO_In3.Size = new System.Drawing.Size(200, 32);
            this.iO_In3.TabIndex = 57;
            this.iO_In3.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In10
            // 
            this.iO_In10.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In10.IOIndex = 10;
            this.iO_In10.IOName = "输入1";
            this.iO_In10.Location = new System.Drawing.Point(3, 404);
            this.iO_In10.Name = "iO_In10";
            this.iO_In10.Size = new System.Drawing.Size(200, 32);
            this.iO_In10.TabIndex = 57;
            this.iO_In10.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In6
            // 
            this.iO_In6.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In6.IOIndex = 6;
            this.iO_In6.IOName = "输入1";
            this.iO_In6.Location = new System.Drawing.Point(3, 256);
            this.iO_In6.Name = "iO_In6";
            this.iO_In6.Size = new System.Drawing.Size(200, 32);
            this.iO_In6.TabIndex = 57;
            this.iO_In6.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In14
            // 
            this.iO_In14.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In14.IOIndex = 14;
            this.iO_In14.IOName = "输入1";
            this.iO_In14.Location = new System.Drawing.Point(243, 107);
            this.iO_In14.Name = "iO_In14";
            this.iO_In14.Size = new System.Drawing.Size(200, 32);
            this.iO_In14.TabIndex = 57;
            this.iO_In14.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In2
            // 
            this.iO_In2.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In2.IOIndex = 2;
            this.iO_In2.IOName = "输入1";
            this.iO_In2.Location = new System.Drawing.Point(3, 107);
            this.iO_In2.Name = "iO_In2";
            this.iO_In2.Size = new System.Drawing.Size(200, 32);
            this.iO_In2.TabIndex = 57;
            this.iO_In2.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In9
            // 
            this.iO_In9.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In9.IOIndex = 9;
            this.iO_In9.IOName = "输入1";
            this.iO_In9.Location = new System.Drawing.Point(3, 367);
            this.iO_In9.Name = "iO_In9";
            this.iO_In9.Size = new System.Drawing.Size(200, 32);
            this.iO_In9.TabIndex = 57;
            this.iO_In9.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In5
            // 
            this.iO_In5.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In5.IOIndex = 5;
            this.iO_In5.IOName = "输入1";
            this.iO_In5.Location = new System.Drawing.Point(3, 218);
            this.iO_In5.Name = "iO_In5";
            this.iO_In5.Size = new System.Drawing.Size(200, 32);
            this.iO_In5.TabIndex = 57;
            this.iO_In5.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In13
            // 
            this.iO_In13.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In13.IOIndex = 13;
            this.iO_In13.IOName = "输入1";
            this.iO_In13.Location = new System.Drawing.Point(243, 70);
            this.iO_In13.Name = "iO_In13";
            this.iO_In13.Size = new System.Drawing.Size(200, 32);
            this.iO_In13.TabIndex = 57;
            this.iO_In13.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In1
            // 
            this.iO_In1.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In1.IOIndex = 1;
            this.iO_In1.IOName = "输入1";
            this.iO_In1.Location = new System.Drawing.Point(3, 70);
            this.iO_In1.Name = "iO_In1";
            this.iO_In1.Size = new System.Drawing.Size(200, 32);
            this.iO_In1.TabIndex = 57;
            this.iO_In1.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In8
            // 
            this.iO_In8.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In8.IOIndex = 8;
            this.iO_In8.IOName = "输入1";
            this.iO_In8.Location = new System.Drawing.Point(3, 330);
            this.iO_In8.Name = "iO_In8";
            this.iO_In8.Size = new System.Drawing.Size(200, 32);
            this.iO_In8.TabIndex = 57;
            this.iO_In8.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In4
            // 
            this.iO_In4.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In4.IOIndex = 4;
            this.iO_In4.IOName = "输入1";
            this.iO_In4.Location = new System.Drawing.Point(3, 181);
            this.iO_In4.Name = "iO_In4";
            this.iO_In4.Size = new System.Drawing.Size(200, 32);
            this.iO_In4.TabIndex = 57;
            this.iO_In4.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In12
            // 
            this.iO_In12.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In12.IOIndex = 12;
            this.iO_In12.IOName = "输入1";
            this.iO_In12.Location = new System.Drawing.Point(243, 33);
            this.iO_In12.Name = "iO_In12";
            this.iO_In12.Size = new System.Drawing.Size(200, 32);
            this.iO_In12.TabIndex = 57;
            this.iO_In12.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // iO_In0
            // 
            this.iO_In0.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In0.IOIndex = 0;
            this.iO_In0.IOName = "输入1";
            this.iO_In0.Location = new System.Drawing.Point(3, 33);
            this.iO_In0.Name = "iO_In0";
            this.iO_In0.Size = new System.Drawing.Size(200, 32);
            this.iO_In0.TabIndex = 57;
            this.iO_In0.StatusChanged += new Application_UI.StatusChangedEventHandler(this.iO_In0_StatusChanged);
            // 
            // uiGroupBox9
            // 
            this.uiGroupBox9.Controls.Add(this.iO_Out8);
            this.uiGroupBox9.Controls.Add(this.iO_Out0);
            this.uiGroupBox9.Controls.Add(this.iO_Out5);
            this.uiGroupBox9.Controls.Add(this.iO_Out9);
            this.uiGroupBox9.Controls.Add(this.iO_Out2);
            this.uiGroupBox9.Controls.Add(this.iO_Out10);
            this.uiGroupBox9.Controls.Add(this.iO_Out6);
            this.uiGroupBox9.Controls.Add(this.iO_Out11);
            this.uiGroupBox9.Controls.Add(this.iO_Out12);
            this.uiGroupBox9.Controls.Add(this.iO_Out3);
            this.uiGroupBox9.Controls.Add(this.iO_Out1);
            this.uiGroupBox9.Controls.Add(this.iO_Out13);
            this.uiGroupBox9.Controls.Add(this.iO_Out14);
            this.uiGroupBox9.Controls.Add(this.iO_Out15);
            this.uiGroupBox9.Controls.Add(this.iO_Out7);
            this.uiGroupBox9.Controls.Add(this.iO_Out4);
            this.uiGroupBox9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox9.Location = new System.Drawing.Point(476, 7);
            this.uiGroupBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox9.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox9.Name = "uiGroupBox9";
            this.uiGroupBox9.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox9.Size = new System.Drawing.Size(519, 486);
            this.uiGroupBox9.TabIndex = 90;
            this.uiGroupBox9.Text = "输出";
            this.uiGroupBox9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iO_Out8
            // 
            this.iO_Out8.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out8.IOIndex = 8;
            this.iO_Out8.IOName = "输出1";
            this.iO_Out8.Location = new System.Drawing.Point(10, 329);
            this.iO_Out8.Name = "iO_Out8";
            this.iO_Out8.Size = new System.Drawing.Size(220, 32);
            this.iO_Out8.TabIndex = 220;
            this.iO_Out8.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out0
            // 
            this.iO_Out0.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out0.IOIndex = 0;
            this.iO_Out0.IOName = "输出1";
            this.iO_Out0.Location = new System.Drawing.Point(10, 33);
            this.iO_Out0.Name = "iO_Out0";
            this.iO_Out0.Size = new System.Drawing.Size(220, 32);
            this.iO_Out0.TabIndex = 31;
            this.iO_Out0.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out5
            // 
            this.iO_Out5.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out5.IOIndex = 5;
            this.iO_Out5.IOName = "输出1";
            this.iO_Out5.Location = new System.Drawing.Point(10, 218);
            this.iO_Out5.Name = "iO_Out5";
            this.iO_Out5.Size = new System.Drawing.Size(220, 32);
            this.iO_Out5.TabIndex = 38;
            this.iO_Out5.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out9
            // 
            this.iO_Out9.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out9.IOIndex = 9;
            this.iO_Out9.IOName = "输出1";
            this.iO_Out9.Location = new System.Drawing.Point(10, 366);
            this.iO_Out9.Name = "iO_Out9";
            this.iO_Out9.Size = new System.Drawing.Size(220, 32);
            this.iO_Out9.TabIndex = 218;
            this.iO_Out9.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out2
            // 
            this.iO_Out2.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out2.IOIndex = 2;
            this.iO_Out2.IOName = "输出1";
            this.iO_Out2.Location = new System.Drawing.Point(10, 107);
            this.iO_Out2.Name = "iO_Out2";
            this.iO_Out2.Size = new System.Drawing.Size(220, 32);
            this.iO_Out2.TabIndex = 37;
            this.iO_Out2.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out10
            // 
            this.iO_Out10.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out10.IOIndex = 10;
            this.iO_Out10.IOName = "输出1";
            this.iO_Out10.Location = new System.Drawing.Point(10, 403);
            this.iO_Out10.Name = "iO_Out10";
            this.iO_Out10.Size = new System.Drawing.Size(220, 32);
            this.iO_Out10.TabIndex = 216;
            this.iO_Out10.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out6
            // 
            this.iO_Out6.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out6.IOIndex = 6;
            this.iO_Out6.IOName = "输出1";
            this.iO_Out6.Location = new System.Drawing.Point(10, 255);
            this.iO_Out6.Name = "iO_Out6";
            this.iO_Out6.Size = new System.Drawing.Size(220, 32);
            this.iO_Out6.TabIndex = 32;
            this.iO_Out6.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out11
            // 
            this.iO_Out11.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out11.IOIndex = 11;
            this.iO_Out11.IOName = "输出1";
            this.iO_Out11.Location = new System.Drawing.Point(10, 440);
            this.iO_Out11.Name = "iO_Out11";
            this.iO_Out11.Size = new System.Drawing.Size(220, 32);
            this.iO_Out11.TabIndex = 222;
            this.iO_Out11.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out12
            // 
            this.iO_Out12.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out12.IOIndex = 12;
            this.iO_Out12.IOName = "输出1";
            this.iO_Out12.Location = new System.Drawing.Point(257, 33);
            this.iO_Out12.Name = "iO_Out12";
            this.iO_Out12.Size = new System.Drawing.Size(220, 32);
            this.iO_Out12.TabIndex = 214;
            this.iO_Out12.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out3
            // 
            this.iO_Out3.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out3.IOIndex = 3;
            this.iO_Out3.IOName = "输出1";
            this.iO_Out3.Location = new System.Drawing.Point(10, 144);
            this.iO_Out3.Name = "iO_Out3";
            this.iO_Out3.Size = new System.Drawing.Size(220, 32);
            this.iO_Out3.TabIndex = 36;
            this.iO_Out3.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out1
            // 
            this.iO_Out1.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out1.IOIndex = 1;
            this.iO_Out1.IOName = "输出1";
            this.iO_Out1.Location = new System.Drawing.Point(10, 70);
            this.iO_Out1.Name = "iO_Out1";
            this.iO_Out1.Size = new System.Drawing.Size(220, 32);
            this.iO_Out1.TabIndex = 33;
            this.iO_Out1.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out13
            // 
            this.iO_Out13.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out13.IOIndex = 13;
            this.iO_Out13.IOName = "输出1";
            this.iO_Out13.Location = new System.Drawing.Point(257, 70);
            this.iO_Out13.Name = "iO_Out13";
            this.iO_Out13.Size = new System.Drawing.Size(220, 32);
            this.iO_Out13.TabIndex = 224;
            this.iO_Out13.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out14
            // 
            this.iO_Out14.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out14.IOIndex = 14;
            this.iO_Out14.IOName = "输出1";
            this.iO_Out14.Location = new System.Drawing.Point(257, 107);
            this.iO_Out14.Name = "iO_Out14";
            this.iO_Out14.Size = new System.Drawing.Size(220, 32);
            this.iO_Out14.TabIndex = 226;
            this.iO_Out14.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out15
            // 
            this.iO_Out15.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out15.IOIndex = 15;
            this.iO_Out15.IOName = "输出1";
            this.iO_Out15.Location = new System.Drawing.Point(257, 144);
            this.iO_Out15.Name = "iO_Out15";
            this.iO_Out15.Size = new System.Drawing.Size(220, 32);
            this.iO_Out15.TabIndex = 212;
            this.iO_Out15.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out7
            // 
            this.iO_Out7.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out7.IOIndex = 7;
            this.iO_Out7.IOName = "输出1";
            this.iO_Out7.Location = new System.Drawing.Point(10, 292);
            this.iO_Out7.Name = "iO_Out7";
            this.iO_Out7.Size = new System.Drawing.Size(220, 32);
            this.iO_Out7.TabIndex = 34;
            this.iO_Out7.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // iO_Out4
            // 
            this.iO_Out4.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out4.IOIndex = 4;
            this.iO_Out4.IOName = "输出1";
            this.iO_Out4.Location = new System.Drawing.Point(10, 181);
            this.iO_Out4.Name = "iO_Out4";
            this.iO_Out4.Size = new System.Drawing.Size(220, 32);
            this.iO_Out4.TabIndex = 35;
            this.iO_Out4.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbTestResult);
            this.tabPage1.Controls.Add(this.uiGroupBox15);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1034, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbTestResult
            // 
            this.gbTestResult.Controls.Add(this.rtb_TestResult);
            this.gbTestResult.Location = new System.Drawing.Point(859, 11);
            this.gbTestResult.Name = "gbTestResult";
            this.gbTestResult.Size = new System.Drawing.Size(172, 539);
            this.gbTestResult.TabIndex = 5;
            this.gbTestResult.TabStop = false;
            this.gbTestResult.Text = "检测结果";
            // 
            // rtb_TestResult
            // 
            this.rtb_TestResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_TestResult.Location = new System.Drawing.Point(3, 25);
            this.rtb_TestResult.Name = "rtb_TestResult";
            this.rtb_TestResult.Size = new System.Drawing.Size(166, 511);
            this.rtb_TestResult.TabIndex = 0;
            this.rtb_TestResult.Text = "";
            // 
            // uiGroupBox15
            // 
            this.uiGroupBox15.Controls.Add(this.vmRenderControl1);
            this.uiGroupBox15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox15.Location = new System.Drawing.Point(4, -6);
            this.uiGroupBox15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox15.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox15.Name = "uiGroupBox15";
            this.uiGroupBox15.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox15.Size = new System.Drawing.Size(851, 559);
            this.uiGroupBox15.TabIndex = 1;
            this.uiGroupBox15.Text = "原图显示";
            this.uiGroupBox15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vmRenderControl1
            // 
            this.vmRenderControl1.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl1.CoordinateInfoVisible = true;
            this.vmRenderControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControl1.ImageSource = null;
            this.vmRenderControl1.IsShowCustomROIMenu = false;
            this.vmRenderControl1.Location = new System.Drawing.Point(0, 32);
            this.vmRenderControl1.Margin = new System.Windows.Forms.Padding(6117, 6436, 6117, 6436);
            this.vmRenderControl1.ModuleSource = null;
            this.vmRenderControl1.Name = "vmRenderControl1";
            this.vmRenderControl1.Size = new System.Drawing.Size(851, 527);
            this.vmRenderControl1.TabIndex = 0;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Controls.Add(this.tabPage3);
            this.uiTabControl1.Controls.Add(this.tabPage4);
            this.uiTabControl1.Controls.Add(this.tabPage6);
            this.uiTabControl1.Controls.Add(this.tabPage5);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(3, 38);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(1034, 600);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.SelectedIndexChanged += new System.EventHandler(this.uiTabControl1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 29);
            this.comboBox1.TabIndex = 270;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1326, 800);
            this.Controls.Add(this.groip);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.uiTabControl1);
            this.Name = "FrmMain";
            this.Text = "CCD外形检测";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1336, 1000);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmMain_ResizeEnd);
            this.uiGroupBox3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox4.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.cms_PathPlan.ResumeLayout(false);
            this.cms_AssistPosition.ResumeLayout(false);
            this.cms_ClearInfo.ResumeLayout(false);
            this.groip.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.uiGroupBox17.ResumeLayout(false);
            this.gb_AxisSet.ResumeLayout(false);
            this.uiGroupBox20.ResumeLayout(false);
            this.uiGroupBox20.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.uiGroupBox18.ResumeLayout(false);
            this.uiGroupBox23.ResumeLayout(false);
            this.uiGroupBox24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hWindow_Camera)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.uiTabControl3.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.uiGroupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.uiGroupBox16.ResumeLayout(false);
            this.gb_CheckItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CheckItem)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            this.uiGroupBox13.ResumeLayout(false);
            this.gb_Optional.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.uiGroupBox10.ResumeLayout(false);
            this.uiGroupBox9.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbTestResult.ResumeLayout(false);
            this.uiGroupBox15.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

  

        #endregion



        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UIGroupBox uiGroupBox8;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslb_img;
        private System.Windows.Forms.ToolStripLabel tslb_status;
        private System.Windows.Forms.ToolStripLabel tslb_actionInfo;
        private System.Windows.Forms.ToolStripLabel tslbl_InfoShow;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIButton btn_StopAutoTest;
        private Sunny.UI.UIButton btn_StartAutoTest;
        private Sunny.UI.UIButton btn_Login;


        private Sunny.UI.UILabel lbl;
        private Sunny.UI.UILabel uiLabel21;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.RichTextBox txt_SoftOptStatus;
        private System.Windows.Forms.Timer timer_IO;
        private System.Windows.Forms.Timer timer_Axis;
        private System.Windows.Forms.ContextMenuStrip cms_PathPlan;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_MoveToPosition;
        private System.Windows.Forms.ToolStripMenuItem toolStripSetCurrentPos;

        private System.Windows.Forms.ContextMenuStrip cms_AssistPosition;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip cms_ClearInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ClearInfo;
        private System.Windows.Forms.Timer timer_Home;
        private Sunny.UI.UILabel lbl_TotalResult;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UIGroupBox groip;
        private System.Windows.Forms.RichTextBox txt_AlarmInfo;


        private Sunny.UI.UILabel lbl_MachineStatus;
        private Sunny.UI.UILabel Product_Label;
        private Sunny.UI.UIGroupBox uiGroupBox4;
        private System.Windows.Forms.TabPage tabPage6;
        private Sunny.UI.UIGroupBox uiGroupBox17;
        private Sunny.UI.UIGroupBox gb_AxisSet;
        private Sunny.UI.UICheckBox ckb_AxisEnable;
        private Sunny.UI.UIComboBox cmb_HomeModel;
        private Sunny.UI.UIButton btn_SaveAxisBasicCnf;
        private Sunny.UI.UILabel uiLabel22;
        private Sunny.UI.UITextBox txt_SlowSpeed;
        private Sunny.UI.UITextBox txt_HomeSpeed;
        private Sunny.UI.UILabel uiLabel31;
        private Sunny.UI.UILabel uiLabel44;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel67;
        private Sunny.UI.UILabel uiLabel61;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel46;
        private Sunny.UI.UILabel uiLabel68;
        private Sunny.UI.UILabel uiLabel66;
        private Sunny.UI.UILabel uiLabel60;
        private Sunny.UI.UILabel uiLabel47;
        private Sunny.UI.UITextBox txt_PulseEquivalent;
        private Sunny.UI.UITextBox txt_NegtivePoint;
        private Sunny.UI.UITextBox txt_AutoSpeed;
        private Sunny.UI.UITextBox txt_OriginPoint;
        private Sunny.UI.UITextBox txt_AlarmPoint;
        private Sunny.UI.UITextBox txt_PositiveSoftLimit;
        private Sunny.UI.UITextBox txt_PositivePoint;
        private Sunny.UI.UITextBox txt_Acceleration;
        private Sunny.UI.UITextBox txt_Deceleration;
        private Sunny.UI.UITextBox txt_NegativeSoftLimit;
        private Sunny.UI.UIGroupBox uiGroupBox20;
        private Sunny.UI.UIButton btn_GoHome;
        private Sunny.UI.UITextBox txt_ManualSpeed;
        private Sunny.UI.UIButton btn_ZHome;
        private Sunny.UI.UIButton btn_ClearAlarm;
        private Sunny.UI.UIButton btn_AllAxisStop;
        private Sunny.UI.UIButton btn_ZUp;
        private Sunny.UI.UIButton btn_ZDown;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TabPage tabPage5;
        private Sunny.UI.UIGroupBox uiGroupBox18;
        private Sunny.UI.UIGroupBox uiGroupBox23;
        private Sunny.UI.UISwitch switch_Gama;
        private Sunny.UI.UITextBox txt_Gama;
        private Sunny.UI.UITextBox txt_Gain;
        private Sunny.UI.UITextBox txt_CameraSN1;
        private Sunny.UI.UITextBox txt_Exposure;
        private Sunny.UI.UILabel uiLabel49;
        private Sunny.UI.UILabel uiLabel50;
        private Sunny.UI.UILabel uiLabel53;
        private Sunny.UI.UILabel uiLabel54;
        private Sunny.UI.UILabel uiLabel55;
        private Sunny.UI.UILabel uiLabel51;
        private Sunny.UI.UIButton btnSoftTriOnce;
        private Sunny.UI.UIComboBox cmb_TriggerModel;
        private Sunny.UI.UIComboBox cmb_CameraSet;
        private Sunny.UI.UILabel uiLabel52;
        private Sunny.UI.UIGroupBox uiGroupBox24;
        private System.Windows.Forms.PictureBox hWindow_Camera;
        private System.Windows.Forms.TabPage tabPage4;
        private Sunny.UI.UITabControl uiTabControl3;
        private System.Windows.Forms.TabPage tabPage9;
        private Sunny.UI.UIGroupBox uiGroupBox7;
        private System.Windows.Forms.Button SaveData_Button;
        private System.Windows.Forms.Button Btn_DelConfig;
        private System.Windows.Forms.Button Begin_AddPoint_Btm;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage tabPage10;
        private Sunny.UI.UIGroupBox uiGroupBox16;
        private Sunny.UI.UIButton btn_CancelModyPassWord;
        private Sunny.UI.UIButton btn_ModifyPassWord;
        private Sunny.UI.UIComboBox cmb_UserName;
        private Sunny.UI.UITextBox txt_NewPassword;
        private Sunny.UI.UITextBox txt_OriginPassword;
        private Sunny.UI.UILabel uiLabel59;
        private Sunny.UI.UILabel uiLabel57;
        private Sunny.UI.UILabel uiLabel58;
        private Sunny.UI.UIGroupBox gb_CheckItems;
        private Sunny.UI.UIButton btn_SaveCheckItem;
        private Sunny.UI.UIButton btn_DeleteCheckItem;
        private Sunny.UI.UIButton btn_AddCheckItem;
        private Sunny.UI.UIComboBox cmb_ItemEnable;
        private Sunny.UI.UILabel uiLabel71;
        private Sunny.UI.UILabel uiLabel72;
        private Sunny.UI.UITextBox txt_ItemContent;
        private Sunny.UI.UILabel uiLabel70;
        private Sunny.UI.UITextBox txt_ItemIndex;
        private Sunny.UI.UIDataGridView dgv_CheckItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage14;
        private Sunny.UI.UIButton btn_ClearCurrentCount;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txt_CurrentOKCount;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txt_CurrentNGYeild;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txt_CurrentNGCount;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txt_CurrentCount;
        private System.Windows.Forms.TextBox txt_CurrentOKYeild;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TotalOKCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TotalNGYeild;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TotalNGCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_TotalCount;
        private System.Windows.Forms.TextBox txt_TotalOKYeild;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Sunny.UI.UIButton btn_ClearTotalCount;
        private Sunny.UI.UIGroupBox uiGroupBox13;
        private Sunny.UI.UILabel uiLabel37;
        private Sunny.UI.UITextBox uiTextBox18;
        private Sunny.UI.UILabel uiLabel36;
        private Sunny.UI.UITextBox uiTextBox17;
        private Sunny.UI.UILabel uiLabel35;
        private Sunny.UI.UITextBox uiTextBox16;
        private Sunny.UI.UILabel uiLabel25;
        private Sunny.UI.UITextBox uiTextBox12;
        private Sunny.UI.UILabel uiLabel30;
        private Sunny.UI.UILabel uiLabel32;
        private Sunny.UI.UITextBox uiTextBox13;
        private Sunny.UI.UILabel uiLabel43;
        private Sunny.UI.UILabel uiLabel42;
        private Sunny.UI.UILabel uiLabel41;
        private Sunny.UI.UILabel uiLabel40;
        private Sunny.UI.UILabel uiLabel39;
        private Sunny.UI.UILabel uiLabel38;
        private Sunny.UI.UILabel uiLabel34;
        private Sunny.UI.UILabel uiLabel33;
        private Sunny.UI.UITextBox uiTextBox14;
        private Sunny.UI.UITextBox uiTextBox15;
        private Sunny.UI.UIGroupBox gb_Optional;
        private Sunny.UI.UICheckBox ckb_ShieldLightCurtain;
        private Sunny.UI.UICheckBox ckb_CylinderShield;
        private Sunny.UI.UICheckBox ckb_SaveNGSourceImage;
        private Sunny.UI.UICheckBox ckb_SaveSourceImage;
        private Sunny.UI.UICheckBox ckb_ShieldBuzzer;
        private Sunny.UI.UICheckBox ckb_CameraShieldI;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UIGroupBox uiGroupBox10;
        private Application_UI.IO_In iO_In11;
        private Application_UI.IO_In iO_In7;
        private Application_UI.IO_In iO_In15;
        private Application_UI.IO_In iO_In3;
        private Application_UI.IO_In iO_In10;
        private Application_UI.IO_In iO_In6;
        private Application_UI.IO_In iO_In14;
        private Application_UI.IO_In iO_In2;
        private Application_UI.IO_In iO_In9;
        private Application_UI.IO_In iO_In5;
        private Application_UI.IO_In iO_In13;
        private Application_UI.IO_In iO_In1;
        private Application_UI.IO_In iO_In8;
        private Application_UI.IO_In iO_In4;
        private Application_UI.IO_In iO_In12;
        private Application_UI.IO_In iO_In0;
        private Sunny.UI.UIGroupBox uiGroupBox9;
        private Application_UI.IO_Out iO_Out8;
        private Application_UI.IO_Out iO_Out0;
        private Application_UI.IO_Out iO_Out5;
        private Application_UI.IO_Out iO_Out9;
        private Application_UI.IO_Out iO_Out2;
        private Application_UI.IO_Out iO_Out10;
        private Application_UI.IO_Out iO_Out6;
        private Application_UI.IO_Out iO_Out11;
        private Application_UI.IO_Out iO_Out12;
        private Application_UI.IO_Out iO_Out3;
        private Application_UI.IO_Out iO_Out1;
        private Application_UI.IO_Out iO_Out13;
        private Application_UI.IO_Out iO_Out14;
        private Application_UI.IO_Out iO_Out15;
        private Application_UI.IO_Out iO_Out7;
        private Application_UI.IO_Out iO_Out4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbTestResult;
        private System.Windows.Forms.RichTextBox rtb_TestResult;
        private Sunny.UI.UIGroupBox uiGroupBox15;
        private VMControls.Winform.Release.VmRenderControl vmRenderControl1;
        private Sunny.UI.UITabControl uiTabControl1;
        private VMControls.Winform.Release.VmFrontendControl vmFrontendControl1;
        private Sunny.UI.UITextBox uiTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

