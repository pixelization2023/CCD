
namespace CCDInspection.UI.Forms
{
    partial class FrmPermissionLogin
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
            this.cmb_UserName = new Sunny.UI.UIComboBox();
            this.txt_Password = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.btn_Cancel = new Sunny.UI.UIButton();
            this.btn_Login = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // cmb_UserName
            // 
            this.cmb_UserName.DataSource = null;
            this.cmb_UserName.FillColor = System.Drawing.Color.White;
            this.cmb_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_UserName.Items.AddRange(new object[] {
            "管理员"});
            this.cmb_UserName.Location = new System.Drawing.Point(113, 65);
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
            // txt_Password
            // 
            this.txt_Password.ButtonSymbol = 61761;
            this.txt_Password.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Password.Location = new System.Drawing.Point(113, 120);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Password.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.ShowText = false;
            this.txt_Password.Size = new System.Drawing.Size(178, 29);
            this.txt_Password.TabIndex = 277;
            this.txt_Password.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Password.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(40, 123);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(66, 23);
            this.uiLabel1.TabIndex = 278;
            this.uiLabel1.Text = "密码：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(40, 67);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(66, 23);
            this.uiLabel3.TabIndex = 279;
            this.uiLabel3.Text = "权限：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Location = new System.Drawing.Point(203, 174);
            this.btn_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(86, 42);
            this.btn_Cancel.TabIndex = 281;
            this.btn_Cancel.Text = "取    消";
            this.btn_Cancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btn_Login
            // 
            this.btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(54, 174);
            this.btn_Login.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(86, 42);
            this.btn_Login.TabIndex = 282;
            this.btn_Login.Text = "登    录";
            this.btn_Login.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // FrmPermissionLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(357, 230);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.cmb_UserName);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiLabel3);
            this.Name = "FrmPermissionLogin";
            this.Text = "FrmPermissionLogin";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIComboBox cmb_UserName;
        private Sunny.UI.UITextBox txt_Password;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton btn_Cancel;
        private Sunny.UI.UIButton btn_Login;
    }
}