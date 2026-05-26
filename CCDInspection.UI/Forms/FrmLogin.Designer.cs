
namespace CCDInspection.UI.Forms
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); 
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_ProductType = new Sunny.UI.UIComboBox();
            this.cmb_UserName = new Sunny.UI.UIComboBox();
            this.txt_Password = new Sunny.UI.UITextBox();
            this.txt_Account = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btn_Login = new Sunny.UI.UIButton();
            this.btn_Cancel = new Sunny.UI.UIButton();
            this.uiComboBox_Productmodel = new Sunny.UI.UIComboBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // cmb_ProductType
            // 
            this.cmb_ProductType.DataSource = null;
            this.cmb_ProductType.FillColor = System.Drawing.Color.White;
            this.cmb_ProductType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_ProductType.Location = new System.Drawing.Point(356, 129);
            this.cmb_ProductType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_ProductType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_ProductType.Name = "cmb_ProductType";
            this.cmb_ProductType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_ProductType.Size = new System.Drawing.Size(178, 27);
            this.cmb_ProductType.TabIndex = 1;
            this.cmb_ProductType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_ProductType.Watermark = "";
            this.cmb_ProductType.SelectedIndexChanged += new System.EventHandler(this.cmb_ProductType_SelectedIndexChanged);
            // 
            // cmb_UserName
            // 
            this.cmb_UserName.DataSource = null;
            this.cmb_UserName.FillColor = System.Drawing.Color.White;
            this.cmb_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_UserName.Items.AddRange(new object[] {
            "管理员"});
            this.cmb_UserName.Location = new System.Drawing.Point(356, 45);
            this.cmb_UserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_UserName.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_UserName.Name = "cmb_UserName";
            this.cmb_UserName.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_UserName.Size = new System.Drawing.Size(178, 27);
            this.cmb_UserName.TabIndex = 276;
            this.cmb_UserName.Text = "管理员";
            this.cmb_UserName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_UserName.Watermark = "";
            // 
            // txt_Password
            // 
            this.txt_Password.ButtonSymbol = 61761;
            this.txt_Password.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Password.DoubleValue = 123456D;
            this.txt_Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Password.IntValue = 123456;
            this.txt_Password.Location = new System.Drawing.Point(356, 86);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Password.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.ShowText = false;
            this.txt_Password.Size = new System.Drawing.Size(178, 29);
            this.txt_Password.TabIndex = 0;
            this.txt_Password.Text = "123456";
            this.txt_Password.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Password.Watermark = "";
            // 
            // txt_Account
            // 
            this.txt_Account.ButtonSymbol = 61761;
            this.txt_Account.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_Account.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Account.DoubleValue = 1D;
            this.txt_Account.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Account.IntValue = 1;
            this.txt_Account.Location = new System.Drawing.Point(356, 211);
            this.txt_Account.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Account.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Account.Name = "txt_Account";
            this.txt_Account.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Account.ShowText = false;
            this.txt_Account.Size = new System.Drawing.Size(178, 29);
            this.txt_Account.TabIndex = 2;
            this.txt_Account.Text = "1";
            this.txt_Account.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Account.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(283, 91);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(66, 23);
            this.uiLabel1.TabIndex = 271;
            this.uiLabel1.Text = "密码：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(259, 133);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(90, 23);
            this.uiLabel4.TabIndex = 272;
            this.uiLabel4.Text = "产品端口：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(283, 49);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(66, 23);
            this.uiLabel3.TabIndex = 273;
            this.uiLabel3.Text = "权限：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(251, 216);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 274;
            this.uiLabel2.Text = "管理员ID：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Login
            // 
            this.btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(299, 270);
            this.btn_Login.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(86, 42);
            this.btn_Login.TabIndex = 277;
            this.btn_Login.Text = "登    录";
            this.btn_Login.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Location = new System.Drawing.Point(448, 270);
            this.btn_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(86, 42);
            this.btn_Cancel.TabIndex = 277;
            this.btn_Cancel.Text = "取    消";
            this.btn_Cancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // uiComboBox_Productmodel
            // 
            this.uiComboBox_Productmodel.DataSource = null;
            this.uiComboBox_Productmodel.FillColor = System.Drawing.Color.White;
            this.uiComboBox_Productmodel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox_Productmodel.Location = new System.Drawing.Point(356, 170);
            this.uiComboBox_Productmodel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_Productmodel.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_Productmodel.Name = "uiComboBox_Productmodel";
            this.uiComboBox_Productmodel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_Productmodel.Size = new System.Drawing.Size(178, 27);
            this.uiComboBox_Productmodel.TabIndex = 278;
            this.uiComboBox_Productmodel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_Productmodel.Watermark = "";
            this.uiComboBox_Productmodel.SelectedIndexChanged += new System.EventHandler(this.uiComboBox_Productmodel_SelectedIndexChanged);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(259, 175);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(90, 23);
            this.uiLabel5.TabIndex = 279;
            this.uiLabel5.Text = "产品型号：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(551, 330);
            this.Controls.Add(this.uiComboBox_Productmodel);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.cmb_ProductType);
            this.Controls.Add(this.cmb_UserName);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Account);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 558, 383);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIComboBox cmb_ProductType;
        private Sunny.UI.UIComboBox cmb_UserName;
        private Sunny.UI.UITextBox txt_Password;
        private Sunny.UI.UITextBox txt_Account;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton btn_Login;
        private Sunny.UI.UIButton btn_Cancel;
        private Sunny.UI.UIComboBox uiComboBox_Productmodel;
        private Sunny.UI.UILabel uiLabel5;
    }
}