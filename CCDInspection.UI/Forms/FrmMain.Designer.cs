
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lbl_about = new System.Windows.Forms.Label();
            this.lbl_result = new System.Windows.Forms.Label();
            this.cob_ProductType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.com_productcode = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbl_currentCode = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.uiTabControl3 = new Sunny.UI.UITabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.uiGroupBox7 = new Sunny.UI.UIGroupBox();
            this.SaveData_Button = new System.Windows.Forms.Button();
            this.Btn_DelConfig = new System.Windows.Forms.Button();
            this.Begin_AddPoint_Btm = new System.Windows.Forms.Button();
            this.btn_addvm = new System.Windows.Forms.Button();
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
            this.gb_Optional = new Sunny.UI.UIGroupBox();
            this.ckb_ShieldLightCurtain = new Sunny.UI.UICheckBox();
            this.ckb_CylinderShield = new Sunny.UI.UICheckBox();
            this.ckb_SaveNGSourceImage = new Sunny.UI.UICheckBox();
            this.ckb_SaveSourceImage = new Sunny.UI.UICheckBox();
            this.ckb_ShieldBuzzer = new Sunny.UI.UICheckBox();
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
            this.uiGroupBox15 = new Sunny.UI.UIGroupBox();
            this.vmRenderControl1 = new VMControls.Winform.Release.VmRenderControl();
            this.gbTestResult = new System.Windows.Forms.GroupBox();
            this.rtb_TestResult = new System.Windows.Forms.RichTextBox();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_open = new Sunny.UI.UIButton();
            this.btn_print = new Sunny.UI.UIButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckb_enableendtime = new System.Windows.Forms.CheckBox();
            this.ckb_enableProt = new System.Windows.Forms.CheckBox();
            this.ckb_enbalestartTime = new System.Windows.Forms.CheckBox();
            this.ckb_enbalecode = new System.Windows.Forms.CheckBox();
            this.ckb_enableType = new System.Windows.Forms.CheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.com_product_code = new System.Windows.Forms.ComboBox();
            this.sql_select = new Sunny.UI.UIButton();
            this.cob_sqlProduct_model = new System.Windows.Forms.ComboBox();
            this.com_sqllPort = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.uiGroupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.cms_PathPlan.SuspendLayout();
            this.cms_AssistPosition.SuspendLayout();
            this.cms_ClearInfo.SuspendLayout();
            this.groip.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.uiGroupBox17.SuspendLayout();
            this.gb_AxisSet.SuspendLayout();
            this.uiGroupBox20.SuspendLayout();
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
            this.gb_Optional.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.uiGroupBox10.SuspendLayout();
            this.uiGroupBox9.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.uiGroupBox15.SuspendLayout();
            this.gbTestResult.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 999);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1920, 33);
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
            this.uiGroupBox2.Controls.Add(this.lbl_about);
            this.uiGroupBox2.Controls.Add(this.lbl_result);
            this.uiGroupBox2.Controls.Add(this.cob_ProductType);
            this.uiGroupBox2.Controls.Add(this.label6);
            this.uiGroupBox2.Controls.Add(this.com_productcode);
            this.uiGroupBox2.Controls.Add(this.comboBox1);
            this.uiGroupBox2.Controls.Add(this.lbl_currentCode);
            this.uiGroupBox2.Controls.Add(this.uiLabel9);
            this.uiGroupBox2.Controls.Add(this.uiLabel7);
            this.uiGroupBox2.Controls.Add(this.Product_Label);
            this.uiGroupBox2.Controls.Add(this.lbl_MachineStatus);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(1654, 40);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(262, 748);
            this.uiGroupBox2.TabIndex = 241;
            this.uiGroupBox2.Text = "系统操作";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox2.Click += new System.EventHandler(this.uiGroupBox2_Click);
            // 
            // lbl_about
            // 
            this.lbl_about.AutoSize = true;
            this.lbl_about.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl_about.Location = new System.Drawing.Point(10, 528);
            this.lbl_about.Name = "lbl_about";
            this.lbl_about.Size = new System.Drawing.Size(56, 17);
            this.lbl_about.TabIndex = 274;
            this.lbl_about.Text = "操作提示";
            // 
            // lbl_result
            // 
            this.lbl_result.Enabled = false;
            this.lbl_result.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_result.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_result.Location = new System.Drawing.Point(32, 156);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(215, 43);
            this.lbl_result.TabIndex = 273;
            this.lbl_result.Text = "label17";
            this.lbl_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cob_ProductType
            // 
            this.cob_ProductType.FormattingEnabled = true;
            this.cob_ProductType.Location = new System.Drawing.Point(92, 343);
            this.cob_ProductType.Name = "cob_ProductType";
            this.cob_ProductType.Size = new System.Drawing.Size(141, 29);
            this.cob_ProductType.TabIndex = 272;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 271;
            this.label6.Text = "类型选择";
            // 
            // com_productcode
            // 
            this.com_productcode.FormattingEnabled = true;
            this.com_productcode.Location = new System.Drawing.Point(92, 420);
            this.com_productcode.Name = "com_productcode";
            this.com_productcode.Size = new System.Drawing.Size(155, 29);
            this.com_productcode.TabIndex = 275;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(92, 380);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 29);
            this.comboBox1.TabIndex = 270;
            // 
            // lbl_currentCode
            // 
            this.lbl_currentCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_currentCode.Location = new System.Drawing.Point(92, 454);
            this.lbl_currentCode.Name = "lbl_currentCode";
            this.lbl_currentCode.Size = new System.Drawing.Size(155, 23);
            this.lbl_currentCode.TabIndex = 276;
            this.lbl_currentCode.Text = "当前编码";
            this.lbl_currentCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(6, 458);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(82, 17);
            this.uiLabel9.TabIndex = 277;
            this.uiLabel9.Text = "编码:";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(6, 423);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(82, 17);
            this.uiLabel7.TabIndex = 278;
            this.uiLabel7.Text = "产品编码:";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Product_Label
            // 
            this.Product_Label.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Product_Label.Location = new System.Drawing.Point(4, 387);
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
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 822);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1204, 173);
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
            this.txt_SoftOptStatus.Size = new System.Drawing.Size(1204, 141);
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
            this.groip.Location = new System.Drawing.Point(1216, 822);
            this.groip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groip.MinimumSize = new System.Drawing.Size(1, 1);
            this.groip.Name = "groip";
            this.groip.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.groip.Size = new System.Drawing.Size(721, 173);
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
            this.txt_AlarmInfo.Size = new System.Drawing.Size(721, 141);
            this.txt_AlarmInfo.TabIndex = 24;
            this.txt_AlarmInfo.Text = "";
            this.txt_AlarmInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_AlarmInfo_MouseDown);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.uiGroupBox17);
            this.tabPage6.Location = new System.Drawing.Point(0, 40);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1144, 736);
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
            this.uiGroupBox17.Size = new System.Drawing.Size(1142, 731);
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
            this.gb_AxisSet.Size = new System.Drawing.Size(691, 696);
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
            this.cmb_HomeModel.Location = new System.Drawing.Point(388, 259);
            this.cmb_HomeModel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_HomeModel.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_HomeModel.Name = "cmb_HomeModel";
            this.cmb_HomeModel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_HomeModel.Size = new System.Drawing.Size(81, 27);
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
            this.btn_SaveAxisBasicCnf.Location = new System.Drawing.Point(476, 459);
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
            this.uiLabel22.Location = new System.Drawing.Point(16, 179);
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
            this.txt_SlowSpeed.Location = new System.Drawing.Point(116, 181);
            this.txt_SlowSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SlowSpeed.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_SlowSpeed.Name = "txt_SlowSpeed";
            this.txt_SlowSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txt_SlowSpeed.ShowText = false;
            this.txt_SlowSpeed.Size = new System.Drawing.Size(96, 35);
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
            this.txt_HomeSpeed.Location = new System.Drawing.Point(388, 305);
            this.txt_HomeSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_HomeSpeed.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_HomeSpeed.Name = "txt_HomeSpeed";
            this.txt_HomeSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txt_HomeSpeed.ShowText = false;
            this.txt_HomeSpeed.Size = new System.Drawing.Size(80, 29);
            this.txt_HomeSpeed.TabIndex = 264;
            this.txt_HomeSpeed.Text = "50";
            this.txt_HomeSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_HomeSpeed.Watermark = "";
            this.txt_HomeSpeed.TextChanged += new System.EventHandler(this.txt_AxisBasicCnf_TextChanged);
            // 
            // uiLabel31
            // 
            this.uiLabel31.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel31.Location = new System.Drawing.Point(256, 304);
            this.uiLabel31.Name = "uiLabel31";
            this.uiLabel31.Size = new System.Drawing.Size(78, 29);
            this.uiLabel31.TabIndex = 266;
            this.uiLabel31.Text = "回零速度";
            this.uiLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel44
            // 
            this.uiLabel44.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel44.Location = new System.Drawing.Point(256, 252);
            this.uiLabel44.Name = "uiLabel44";
            this.uiLabel44.Size = new System.Drawing.Size(78, 29);
            this.uiLabel44.TabIndex = 267;
            this.uiLabel44.Text = "回零模式";
            this.uiLabel44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(16, 68);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(74, 23);
            this.uiLabel1.TabIndex = 45;
            this.uiLabel1.Text = "脉冲当量";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(16, 105);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(74, 23);
            this.uiLabel2.TabIndex = 44;
            this.uiLabel2.Text = "自动速度";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(16, 142);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(74, 23);
            this.uiLabel3.TabIndex = 45;
            this.uiLabel3.Text = "正软极限";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel67
            // 
            this.uiLabel67.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel67.Location = new System.Drawing.Point(256, 114);
            this.uiLabel67.Name = "uiLabel67";
            this.uiLabel67.Size = new System.Drawing.Size(60, 23);
            this.uiLabel67.TabIndex = 45;
            this.uiLabel67.Text = "负极限";
            this.uiLabel67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel61
            // 
            this.uiLabel61.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel61.Location = new System.Drawing.Point(16, 302);
            this.uiLabel61.Name = "uiLabel61";
            this.uiLabel61.Size = new System.Drawing.Size(60, 23);
            this.uiLabel61.TabIndex = 45;
            this.uiLabel61.Text = "原点";
            this.uiLabel61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(16, 228);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(60, 23);
            this.uiLabel4.TabIndex = 45;
            this.uiLabel4.Text = "加速度";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel46
            // 
            this.uiLabel46.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel46.Location = new System.Drawing.Point(256, 206);
            this.uiLabel46.Name = "uiLabel46";
            this.uiLabel46.Size = new System.Drawing.Size(74, 23);
            this.uiLabel46.TabIndex = 45;
            this.uiLabel46.Text = "负软极限";
            this.uiLabel46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel66
            // 
            this.uiLabel66.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel66.Location = new System.Drawing.Point(256, 160);
            this.uiLabel66.Name = "uiLabel66";
            this.uiLabel66.Size = new System.Drawing.Size(60, 23);
            this.uiLabel66.TabIndex = 44;
            this.uiLabel66.Text = "报警";
            this.uiLabel66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel60
            // 
            this.uiLabel60.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel60.Location = new System.Drawing.Point(256, 68);
            this.uiLabel60.Name = "uiLabel60";
            this.uiLabel60.Size = new System.Drawing.Size(60, 23);
            this.uiLabel60.TabIndex = 44;
            this.uiLabel60.Text = "正极限";
            this.uiLabel60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel47
            // 
            this.uiLabel47.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel47.Location = new System.Drawing.Point(16, 265);
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
            this.txt_PulseEquivalent.Location = new System.Drawing.Point(116, 64);
            this.txt_PulseEquivalent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PulseEquivalent.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_PulseEquivalent.Name = "txt_PulseEquivalent";
            this.txt_PulseEquivalent.Padding = new System.Windows.Forms.Padding(5);
            this.txt_PulseEquivalent.ShowText = false;
            this.txt_PulseEquivalent.Size = new System.Drawing.Size(96, 35);
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
            this.txt_NegtivePoint.Location = new System.Drawing.Point(388, 115);
            this.txt_NegtivePoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_NegtivePoint.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_NegtivePoint.Name = "txt_NegtivePoint";
            this.txt_NegtivePoint.Padding = new System.Windows.Forms.Padding(5);
            this.txt_NegtivePoint.ShowText = false;
            this.txt_NegtivePoint.Size = new System.Drawing.Size(74, 29);
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
            this.txt_AutoSpeed.Location = new System.Drawing.Point(116, 103);
            this.txt_AutoSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_AutoSpeed.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_AutoSpeed.Name = "txt_AutoSpeed";
            this.txt_AutoSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txt_AutoSpeed.ShowText = false;
            this.txt_AutoSpeed.Size = new System.Drawing.Size(96, 35);
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
            this.txt_OriginPoint.Location = new System.Drawing.Point(116, 298);
            this.txt_OriginPoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_OriginPoint.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_OriginPoint.Name = "txt_OriginPoint";
            this.txt_OriginPoint.Padding = new System.Windows.Forms.Padding(5);
            this.txt_OriginPoint.ShowText = false;
            this.txt_OriginPoint.Size = new System.Drawing.Size(96, 35);
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
            this.txt_AlarmPoint.Location = new System.Drawing.Point(388, 163);
            this.txt_AlarmPoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_AlarmPoint.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_AlarmPoint.Name = "txt_AlarmPoint";
            this.txt_AlarmPoint.Padding = new System.Windows.Forms.Padding(5);
            this.txt_AlarmPoint.ShowText = false;
            this.txt_AlarmPoint.Size = new System.Drawing.Size(74, 29);
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
            this.txt_PositiveSoftLimit.Location = new System.Drawing.Point(116, 142);
            this.txt_PositiveSoftLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PositiveSoftLimit.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_PositiveSoftLimit.Name = "txt_PositiveSoftLimit";
            this.txt_PositiveSoftLimit.Padding = new System.Windows.Forms.Padding(5);
            this.txt_PositiveSoftLimit.ShowText = false;
            this.txt_PositiveSoftLimit.Size = new System.Drawing.Size(96, 35);
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
            this.txt_PositivePoint.Location = new System.Drawing.Point(388, 67);
            this.txt_PositivePoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PositivePoint.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_PositivePoint.Name = "txt_PositivePoint";
            this.txt_PositivePoint.Padding = new System.Windows.Forms.Padding(5);
            this.txt_PositivePoint.ShowText = false;
            this.txt_PositivePoint.Size = new System.Drawing.Size(74, 29);
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
            this.txt_Acceleration.Location = new System.Drawing.Point(116, 220);
            this.txt_Acceleration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Acceleration.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Acceleration.Name = "txt_Acceleration";
            this.txt_Acceleration.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Acceleration.ShowText = false;
            this.txt_Acceleration.Size = new System.Drawing.Size(96, 35);
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
            this.txt_Deceleration.Location = new System.Drawing.Point(116, 259);
            this.txt_Deceleration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Deceleration.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Deceleration.Name = "txt_Deceleration";
            this.txt_Deceleration.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Deceleration.ShowText = false;
            this.txt_Deceleration.Size = new System.Drawing.Size(96, 35);
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
            this.txt_NegativeSoftLimit.Location = new System.Drawing.Point(388, 211);
            this.txt_NegativeSoftLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_NegativeSoftLimit.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_NegativeSoftLimit.Name = "txt_NegativeSoftLimit";
            this.txt_NegativeSoftLimit.Padding = new System.Windows.Forms.Padding(5);
            this.txt_NegativeSoftLimit.ShowText = false;
            this.txt_NegativeSoftLimit.Size = new System.Drawing.Size(80, 29);
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
            this.uiGroupBox20.Size = new System.Drawing.Size(447, 711);
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
            this.btn_GoHome.Location = new System.Drawing.Point(283, 277);
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
            this.btn_ZHome.Location = new System.Drawing.Point(283, 398);
            this.btn_ZHome.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ZHome.Name = "btn_ZHome";
            this.btn_ZHome.Size = new System.Drawing.Size(104, 45);
            this.btn_ZHome.TabIndex = 380;
            this.btn_ZHome.Tag = "";
            this.btn_ZHome.Click += new System.EventHandler(this.btn_AllHome_Click);
            this.btn_ZHome.Text = "Z复位";
            this.btn_ZHome.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ZHome.Click += new System.EventHandler(this.btn_AllHome_Click);
            // 
            // btn_ClearAlarm
            // 
            this.btn_ClearAlarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearAlarm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearAlarm.Location = new System.Drawing.Point(283, 519);
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
            this.btn_AllAxisStop.Location = new System.Drawing.Point(283, 640);
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
            this.btn_ZUp.Location = new System.Drawing.Point(283, 35);
            this.btn_ZUp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ZUp.Name = "btn_ZUp";
            this.btn_ZUp.Size = new System.Drawing.Size(104, 45);
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
            this.btn_ZDown.Location = new System.Drawing.Point(283, 156);
            this.btn_ZDown.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ZDown.Name = "btn_ZDown";
            this.btn_ZDown.Size = new System.Drawing.Size(104, 45);
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
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.uiTabControl3);
            this.tabPage4.Location = new System.Drawing.Point(0, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1144, 736);
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
            this.uiGroupBox7.Controls.Add(this.btn_addvm);
            this.uiGroupBox7.Controls.Add(this.dataGridView3);
            this.uiGroupBox7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox7.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox7.Name = "uiGroupBox7";
            this.uiGroupBox7.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox7.Size = new System.Drawing.Size(1135, 686);
            this.uiGroupBox7.TabIndex = 1;
            this.uiGroupBox7.Text = "产品型号设定";
            this.uiGroupBox7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveData_Button
            // 
            this.SaveData_Button.Font = new System.Drawing.Font("楷体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveData_Button.Location = new System.Drawing.Point(942, 296);
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
            this.Btn_DelConfig.Location = new System.Drawing.Point(942, 165);
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
            this.Begin_AddPoint_Btm.Location = new System.Drawing.Point(942, 34);
            this.Begin_AddPoint_Btm.Margin = new System.Windows.Forms.Padding(2);
            this.Begin_AddPoint_Btm.Name = "Begin_AddPoint_Btm";
            this.Begin_AddPoint_Btm.Size = new System.Drawing.Size(161, 55);
            this.Begin_AddPoint_Btm.TabIndex = 53;
            this.Begin_AddPoint_Btm.Text = "开始配置";
            this.Begin_AddPoint_Btm.UseVisualStyleBackColor = true;
            this.Begin_AddPoint_Btm.Click += new System.EventHandler(this.Begin_AddPlcPoint_Btm_Click);
            // 
            // btn_addvm
            // 
            this.btn_addvm.Font = new System.Drawing.Font("楷体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addvm.Location = new System.Drawing.Point(942, 412);
            this.btn_addvm.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addvm.Name = "btn_addvm";
            this.btn_addvm.Size = new System.Drawing.Size(161, 49);
            this.btn_addvm.TabIndex = 60;
            this.btn_addvm.Text = "添加视觉方案";
            this.btn_addvm.UseVisualStyleBackColor = true;
            this.btn_addvm.Click += new System.EventHandler(this.btn_addvm_Click);
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
            this.dataGridView3.Size = new System.Drawing.Size(925, 623);
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
            this.Column4.Width = 180;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.uiGroupBox16);
            this.tabPage10.Controls.Add(this.gb_CheckItems);
            this.tabPage10.Location = new System.Drawing.Point(0, 40);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1276, 666);
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
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_CheckItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_CheckItem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_CheckItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CheckItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_CheckItem.ColumnHeadersHeight = 32;
            this.dgv_CheckItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_CheckItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_CheckItem.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_CheckItem.EnableHeadersVisualStyles = false;
            this.dgv_CheckItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_CheckItem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgv_CheckItem.Location = new System.Drawing.Point(3, 29);
            this.dgv_CheckItem.Name = "dgv_CheckItem";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CheckItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_CheckItem.RowHeadersWidth = 62;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_CheckItem.RowsDefaultCellStyle = dataGridViewCellStyle10;
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
            this.tabPage3.Controls.Add(this.gb_Optional);
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1144, 736);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "功能与屏蔽";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gb_Optional
            // 
            this.gb_Optional.Controls.Add(this.ckb_ShieldLightCurtain);
            this.gb_Optional.Controls.Add(this.ckb_CylinderShield);
            this.gb_Optional.Controls.Add(this.ckb_SaveNGSourceImage);
            this.gb_Optional.Controls.Add(this.ckb_SaveSourceImage);
            this.gb_Optional.Controls.Add(this.ckb_ShieldBuzzer);
            this.gb_Optional.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_Optional.Location = new System.Drawing.Point(3, 6);
            this.gb_Optional.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_Optional.MinimumSize = new System.Drawing.Size(1, 1);
            this.gb_Optional.Name = "gb_Optional";
            this.gb_Optional.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.gb_Optional.Size = new System.Drawing.Size(1143, 728);
            this.gb_Optional.TabIndex = 261;
            this.gb_Optional.Text = "功能选择";
            this.gb_Optional.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckb_ShieldLightCurtain
            // 
            this.ckb_ShieldLightCurtain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_ShieldLightCurtain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_ShieldLightCurtain.Location = new System.Drawing.Point(96, 120);
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
            this.ckb_CylinderShield.Location = new System.Drawing.Point(96, 205);
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
            this.ckb_SaveNGSourceImage.Location = new System.Drawing.Point(96, 375);
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
            this.ckb_SaveSourceImage.Location = new System.Drawing.Point(96, 290);
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
            this.ckb_ShieldBuzzer.Location = new System.Drawing.Point(96, 35);
            this.ckb_ShieldBuzzer.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_ShieldBuzzer.Name = "ckb_ShieldBuzzer";
            this.ckb_ShieldBuzzer.Size = new System.Drawing.Size(117, 29);
            this.ckb_ShieldBuzzer.TabIndex = 0;
            this.ckb_ShieldBuzzer.Text = "启用蜂鸣器";
            this.ckb_ShieldBuzzer.CheckedChanged += new System.EventHandler(this.ckb_ShieldBuzzer_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Controls.Add(this.tabPage15);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabControl1.Location = new System.Drawing.Point(1411, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(236, 765);
            this.tabControl1.TabIndex = 264;
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
            this.tabPage14.Location = new System.Drawing.Point(4, 30);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(228, 731);
            this.tabPage14.TabIndex = 0;
            this.tabPage14.Text = "当天产量";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // btn_ClearCurrentCount
            // 
            this.btn_ClearCurrentCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearCurrentCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearCurrentCount.Location = new System.Drawing.Point(46, 345);
            this.btn_ClearCurrentCount.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ClearCurrentCount.Name = "btn_ClearCurrentCount";
            this.btn_ClearCurrentCount.Size = new System.Drawing.Size(113, 49);
            this.btn_ClearCurrentCount.TabIndex = 262;
            this.btn_ClearCurrentCount.Text = "清除当天计数";
            this.btn_ClearCurrentCount.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearCurrentCount.Click += new System.EventHandler(this.btn_ClearCurrentCount_Click);
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
            this.label48.Size = new System.Drawing.Size(113, 21);
            this.label48.TabIndex = 254;
            this.label48.Text = "当天OK产品：";
            // 
            // txt_CurrentOKCount
            // 
            this.txt_CurrentOKCount.Location = new System.Drawing.Point(64, 36);
            this.txt_CurrentOKCount.Name = "txt_CurrentOKCount";
            this.txt_CurrentOKCount.Size = new System.Drawing.Size(93, 29);
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
            this.txt_CurrentNGYeild.Size = new System.Drawing.Size(68, 29);
            this.txt_CurrentNGYeild.TabIndex = 255;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(24, 66);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(115, 21);
            this.label46.TabIndex = 253;
            this.label46.Text = "当天NG产品：";
            // 
            // txt_CurrentNGCount
            // 
            this.txt_CurrentNGCount.Location = new System.Drawing.Point(64, 90);
            this.txt_CurrentNGCount.Name = "txt_CurrentNGCount";
            this.txt_CurrentNGCount.Size = new System.Drawing.Size(93, 29);
            this.txt_CurrentNGCount.TabIndex = 258;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(24, 120);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(122, 21);
            this.label44.TabIndex = 252;
            this.label44.Text = "当天生产产品：";
            // 
            // txt_CurrentCount
            // 
            this.txt_CurrentCount.Location = new System.Drawing.Point(64, 144);
            this.txt_CurrentCount.Name = "txt_CurrentCount";
            this.txt_CurrentCount.Size = new System.Drawing.Size(93, 29);
            this.txt_CurrentCount.TabIndex = 257;
            // 
            // txt_CurrentOKYeild
            // 
            this.txt_CurrentOKYeild.Location = new System.Drawing.Point(69, 198);
            this.txt_CurrentOKYeild.Name = "txt_CurrentOKYeild";
            this.txt_CurrentOKYeild.Size = new System.Drawing.Size(68, 29);
            this.txt_CurrentOKYeild.TabIndex = 256;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(24, 174);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(90, 21);
            this.label42.TabIndex = 251;
            this.label42.Text = "当天良率：";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(24, 228);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(99, 21);
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
            this.tabPage15.Location = new System.Drawing.Point(4, 30);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(228, 731);
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
            this.label2.Size = new System.Drawing.Size(97, 21);
            this.label2.TabIndex = 285;
            this.label2.Text = "总OK产品：";
            // 
            // txt_TotalOKCount
            // 
            this.txt_TotalOKCount.Location = new System.Drawing.Point(57, 39);
            this.txt_TotalOKCount.Name = "txt_TotalOKCount";
            this.txt_TotalOKCount.Size = new System.Drawing.Size(93, 29);
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
            this.txt_TotalNGYeild.Size = new System.Drawing.Size(68, 29);
            this.txt_TotalNGYeild.TabIndex = 286;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 21);
            this.label5.TabIndex = 284;
            this.label5.Text = "总NG产品：";
            // 
            // txt_TotalNGCount
            // 
            this.txt_TotalNGCount.Location = new System.Drawing.Point(57, 93);
            this.txt_TotalNGCount.Name = "txt_TotalNGCount";
            this.txt_TotalNGCount.Size = new System.Drawing.Size(93, 29);
            this.txt_TotalNGCount.TabIndex = 289;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 21);
            this.label9.TabIndex = 283;
            this.label9.Text = "总生产产品：";
            // 
            // txt_TotalCount
            // 
            this.txt_TotalCount.Location = new System.Drawing.Point(57, 147);
            this.txt_TotalCount.Name = "txt_TotalCount";
            this.txt_TotalCount.Size = new System.Drawing.Size(93, 29);
            this.txt_TotalCount.TabIndex = 288;
            // 
            // txt_TotalOKYeild
            // 
            this.txt_TotalOKYeild.Location = new System.Drawing.Point(62, 201);
            this.txt_TotalOKYeild.Name = "txt_TotalOKYeild";
            this.txt_TotalOKYeild.Size = new System.Drawing.Size(68, 29);
            this.txt_TotalOKYeild.TabIndex = 287;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 282;
            this.label10.Text = "总良率：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 21);
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
            this.btn_ClearTotalCount.Click += new System.EventHandler(this.btn_ClearTotalCount_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uiGroupBox10);
            this.tabPage2.Controls.Add(this.uiGroupBox9);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1144, 736);
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
            this.uiGroupBox10.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox10.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox10.Name = "uiGroupBox10";
            this.uiGroupBox10.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox10.Size = new System.Drawing.Size(575, 731);
            this.uiGroupBox10.TabIndex = 91;
            this.uiGroupBox10.Text = "输入";
            this.uiGroupBox10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iO_In11
            // 
            this.iO_In11.BackColor = System.Drawing.SystemColors.Control;
            this.iO_In11.IOIndex = 11;
            this.iO_In11.IOName = "输入1";
            this.iO_In11.Location = new System.Drawing.Point(3, 682);
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
            this.iO_In7.Location = new System.Drawing.Point(3, 446);
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
            this.iO_In15.Location = new System.Drawing.Point(245, 210);
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
            this.iO_In3.Location = new System.Drawing.Point(3, 210);
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
            this.iO_In10.Location = new System.Drawing.Point(3, 623);
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
            this.iO_In6.Location = new System.Drawing.Point(3, 387);
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
            this.iO_In14.Location = new System.Drawing.Point(245, 151);
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
            this.iO_In2.Location = new System.Drawing.Point(3, 151);
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
            this.iO_In9.Location = new System.Drawing.Point(3, 564);
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
            this.iO_In5.Location = new System.Drawing.Point(3, 328);
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
            this.iO_In13.Location = new System.Drawing.Point(245, 92);
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
            this.iO_In1.Location = new System.Drawing.Point(3, 92);
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
            this.iO_In8.Location = new System.Drawing.Point(3, 505);
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
            this.iO_In4.Location = new System.Drawing.Point(3, 269);
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
            this.uiGroupBox9.Location = new System.Drawing.Point(587, 5);
            this.uiGroupBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox9.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox9.Name = "uiGroupBox9";
            this.uiGroupBox9.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox9.Size = new System.Drawing.Size(553, 731);
            this.uiGroupBox9.TabIndex = 90;
            this.uiGroupBox9.Text = "输出";
            this.uiGroupBox9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iO_Out8
            // 
            this.iO_Out8.BackColor = System.Drawing.SystemColors.Control;
            this.iO_Out8.IOIndex = 8;
            this.iO_Out8.IOName = "输出1";
            this.iO_Out8.Location = new System.Drawing.Point(10, 505);
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
            this.iO_Out5.Location = new System.Drawing.Point(10, 328);
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
            this.iO_Out9.Location = new System.Drawing.Point(10, 564);
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
            this.iO_Out2.Location = new System.Drawing.Point(10, 151);
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
            this.iO_Out10.Location = new System.Drawing.Point(10, 623);
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
            this.iO_Out6.Location = new System.Drawing.Point(10, 387);
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
            this.iO_Out11.Location = new System.Drawing.Point(10, 682);
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
            this.iO_Out3.Location = new System.Drawing.Point(10, 210);
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
            this.iO_Out1.Location = new System.Drawing.Point(10, 92);
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
            this.iO_Out13.Location = new System.Drawing.Point(257, 92);
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
            this.iO_Out14.Location = new System.Drawing.Point(257, 151);
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
            this.iO_Out15.Location = new System.Drawing.Point(257, 210);
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
            this.iO_Out7.Location = new System.Drawing.Point(10, 446);
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
            this.iO_Out4.Location = new System.Drawing.Point(10, 269);
            this.iO_Out4.Name = "iO_Out4";
            this.iO_Out4.Size = new System.Drawing.Size(220, 32);
            this.iO_Out4.TabIndex = 35;
            this.iO_Out4.CheckedChanged += new Application_UI.CheckedChangedEventHandler(this.iO_Out0_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uiGroupBox15);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1144, 736);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox15
            // 
            this.uiGroupBox15.Controls.Add(this.vmRenderControl1);
            this.uiGroupBox15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox15.Location = new System.Drawing.Point(-3, 0);
            this.uiGroupBox15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox15.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox15.Name = "uiGroupBox15";
            this.uiGroupBox15.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox15.Size = new System.Drawing.Size(1143, 732);
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
            this.vmRenderControl1.Margin = new System.Windows.Forms.Padding(813755, 856151, 813755, 856151);
            this.vmRenderControl1.ModuleSource = null;
            this.vmRenderControl1.Name = "vmRenderControl1";
            this.vmRenderControl1.Size = new System.Drawing.Size(1143, 700);
            this.vmRenderControl1.TabIndex = 0;
            // 
            // gbTestResult
            // 
            this.gbTestResult.Controls.Add(this.rtb_TestResult);
            this.gbTestResult.Location = new System.Drawing.Point(1153, 49);
            this.gbTestResult.Name = "gbTestResult";
            this.gbTestResult.Size = new System.Drawing.Size(256, 765);
            this.gbTestResult.TabIndex = 5;
            this.gbTestResult.TabStop = false;
            this.gbTestResult.Text = "检测记录";
            // 
            // rtb_TestResult
            // 
            this.rtb_TestResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_TestResult.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rtb_TestResult.Location = new System.Drawing.Point(3, 22);
            this.rtb_TestResult.Name = "rtb_TestResult";
            this.rtb_TestResult.Size = new System.Drawing.Size(250, 740);
            this.rtb_TestResult.TabIndex = 0;
            this.rtb_TestResult.Text = "";
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
            this.uiTabControl1.Size = new System.Drawing.Size(1144, 776);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.SelectedIndexChanged += new System.EventHandler(this.uiTabControl1_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btn_open);
            this.tabPage5.Controls.Add(this.btn_print);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Controls.Add(this.dataGridView1);
            this.tabPage5.Location = new System.Drawing.Point(0, 40);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1144, 736);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "数据查询";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_open
            // 
            this.btn_open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_open.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_open.Location = new System.Drawing.Point(932, 228);
            this.btn_open.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(191, 34);
            this.btn_open.TabIndex = 9;
            this.btn_open.Text = "打开文件夹";
            this.btn_open.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btn_print
            // 
            this.btn_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_print.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_print.Location = new System.Drawing.Point(932, 182);
            this.btn_print.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(191, 34);
            this.btn_print.TabIndex = 9;
            this.btn_print.Text = "打印";
            this.btn_print.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckb_enableendtime);
            this.groupBox2.Controls.Add(this.ckb_enableProt);
            this.groupBox2.Controls.Add(this.ckb_enbalestartTime);
            this.groupBox2.Controls.Add(this.ckb_enbalecode);
            this.groupBox2.Controls.Add(this.ckb_enableType);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.com_product_code);
            this.groupBox2.Controls.Add(this.sql_select);
            this.groupBox2.Controls.Add(this.cob_sqlProduct_model);
            this.groupBox2.Controls.Add(this.com_sqllPort);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(0, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1123, 142);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "筛选条件";
            // 
            // ckb_enableendtime
            // 
            this.ckb_enableendtime.AutoSize = true;
            this.ckb_enableendtime.Location = new System.Drawing.Point(385, 106);
            this.ckb_enableendtime.Name = "ckb_enableendtime";
            this.ckb_enableendtime.Size = new System.Drawing.Size(15, 14);
            this.ckb_enableendtime.TabIndex = 9;
            this.ckb_enableendtime.UseVisualStyleBackColor = true;
            // 
            // ckb_enableProt
            // 
            this.ckb_enableProt.AutoSize = true;
            this.ckb_enableProt.Location = new System.Drawing.Point(24, 44);
            this.ckb_enableProt.Name = "ckb_enableProt";
            this.ckb_enableProt.Size = new System.Drawing.Size(15, 14);
            this.ckb_enableProt.TabIndex = 9;
            this.ckb_enableProt.UseVisualStyleBackColor = true;
            // 
            // ckb_enbalestartTime
            // 
            this.ckb_enbalestartTime.AutoSize = true;
            this.ckb_enbalestartTime.Location = new System.Drawing.Point(23, 101);
            this.ckb_enbalestartTime.Name = "ckb_enbalestartTime";
            this.ckb_enbalestartTime.Size = new System.Drawing.Size(15, 14);
            this.ckb_enbalestartTime.TabIndex = 9;
            this.ckb_enbalestartTime.UseVisualStyleBackColor = true;
            // 
            // ckb_enbalecode
            // 
            this.ckb_enbalecode.AutoSize = true;
            this.ckb_enbalecode.Location = new System.Drawing.Point(790, 46);
            this.ckb_enbalecode.Name = "ckb_enbalecode";
            this.ckb_enbalecode.Size = new System.Drawing.Size(15, 14);
            this.ckb_enbalecode.TabIndex = 9;
            this.ckb_enbalecode.UseVisualStyleBackColor = true;
            // 
            // ckb_enableType
            // 
            this.ckb_enableType.AutoSize = true;
            this.ckb_enableType.Location = new System.Drawing.Point(385, 46);
            this.ckb_enableType.Name = "ckb_enableType";
            this.ckb_enableType.Size = new System.Drawing.Size(15, 14);
            this.ckb_enableType.TabIndex = 9;
            this.ckb_enableType.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss”";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(514, 91);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(209, 29);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(811, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 21);
            this.label15.TabIndex = 7;
            this.label15.Text = "产品编码";
            // 
            // com_product_code
            // 
            this.com_product_code.FormattingEnabled = true;
            this.com_product_code.Location = new System.Drawing.Point(904, 39);
            this.com_product_code.Name = "com_product_code";
            this.com_product_code.Size = new System.Drawing.Size(121, 29);
            this.com_product_code.TabIndex = 6;
            // 
            // sql_select
            // 
            this.sql_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sql_select.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sql_select.Location = new System.Drawing.Point(790, 91);
            this.sql_select.MinimumSize = new System.Drawing.Size(1, 1);
            this.sql_select.Name = "sql_select";
            this.sql_select.Size = new System.Drawing.Size(245, 34);
            this.sql_select.TabIndex = 5;
            this.sql_select.Text = "查询";
            this.sql_select.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sql_select.Click += new System.EventHandler(this.sql_select_Click_1);
            // 
            // cob_sqlProduct_model
            // 
            this.cob_sqlProduct_model.FormattingEnabled = true;
            this.cob_sqlProduct_model.Location = new System.Drawing.Point(514, 36);
            this.cob_sqlProduct_model.Name = "cob_sqlProduct_model";
            this.cob_sqlProduct_model.Size = new System.Drawing.Size(203, 29);
            this.cob_sqlProduct_model.TabIndex = 3;
            // 
            // com_sqllPort
            // 
            this.com_sqllPort.FormattingEnabled = true;
            this.com_sqllPort.Location = new System.Drawing.Point(129, 39);
            this.com_sqllPort.Name = "com_sqllPort";
            this.com_sqllPort.Size = new System.Drawing.Size(183, 29);
            this.com_sqllPort.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss”";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(129, 91);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(183, 29);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "端口选择";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(406, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 21);
            this.label16.TabIndex = 0;
            this.label16.Text = "结束时间";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 21);
            this.label13.TabIndex = 0;
            this.label13.Text = "起始时间";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(406, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 21);
            this.label12.TabIndex = 0;
            this.label12.Text = "产品类型";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 21);
            this.label8.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(23, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(810, 539);
            this.dataGridView1.TabIndex = 0;
            // 
            // time
            // 
            this.time.HeaderText = "时间";
            this.time.Name = "time";
            this.time.Width = 180;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "检测产品类型";
            this.Column6.Name = "Column6";
            this.Column6.Width = 135;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "检测产品端口";
            this.Column7.Name = "Column7";
            this.Column7.Width = 135;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "检测颜色";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "产品编码";
            this.Column9.Name = "Column9";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "结果";
            this.Column5.Name = "Column5";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1032);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gbTestResult);
            this.Controls.Add(this.groip);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.uiTabControl1);
            this.MaximizeBox = false;
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
            this.uiGroupBox2.PerformLayout();
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
            this.gb_Optional.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.uiGroupBox10.ResumeLayout(false);
            this.uiGroupBox9.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.uiGroupBox15.ResumeLayout(false);
            this.gbTestResult.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage4;
        private Sunny.UI.UITabControl uiTabControl3;
        private System.Windows.Forms.TabPage tabPage9;
        private Sunny.UI.UIGroupBox uiGroupBox7;
        private System.Windows.Forms.Button SaveData_Button;
        private System.Windows.Forms.Button Btn_DelConfig;
        private System.Windows.Forms.Button Begin_AddPoint_Btm;
        private System.Windows.Forms.Button btn_addvm;
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
        private Sunny.UI.UIGroupBox gb_Optional;
        private Sunny.UI.UICheckBox ckb_ShieldLightCurtain;
        private Sunny.UI.UICheckBox ckb_CylinderShield;
        private Sunny.UI.UICheckBox ckb_SaveNGSourceImage;
        private Sunny.UI.UICheckBox ckb_SaveSourceImage;
        private Sunny.UI.UICheckBox ckb_ShieldBuzzer;
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
        private Sunny.UI.UITextBox uiTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cob_ProductType;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cob_sqlProduct_model;
        private System.Windows.Forms.ComboBox com_sqllPort;
        private Sunny.UI.UIButton sql_select;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox com_product_code;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Sunny.UI.UIButton btn_print;
        private Sunny.UI.UIButton btn_open;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.CheckBox ckb_enableType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ckb_enableendtime;
        private System.Windows.Forms.CheckBox ckb_enbalestartTime;
        private System.Windows.Forms.CheckBox ckb_enbalecode;
        private System.Windows.Forms.CheckBox ckb_enableProt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Label lbl_about;
        private System.Windows.Forms.ComboBox com_productcode;
        private Sunny.UI.UILabel lbl_currentCode;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel7;
    }
}

