
namespace CCDInspection.UI.Forms
{
    partial class FrmSnapConfig
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
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.Gamma_Enable = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Gamma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Gain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Exposure = new System.Windows.Forms.TextBox();
            this.btn_OK = new Sunny.UI.UIButton();
            this.btn_Cancel = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "名称:";
            // 
            // txt_Title
            // 
            this.txt_Title.Location = new System.Drawing.Point(86, 47);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(100, 26);
            this.txt_Title.TabIndex = 18;
            this.txt_Title.Text = "拍照";
            // 
            // Gamma_Enable
            // 
            this.Gamma_Enable.AutoSize = true;
            this.Gamma_Enable.Location = new System.Drawing.Point(35, 139);
            this.Gamma_Enable.Name = "Gamma_Enable";
            this.Gamma_Enable.Size = new System.Drawing.Size(115, 20);
            this.Gamma_Enable.TabIndex = 17;
            this.Gamma_Enable.Text = "Gama_Enable";
            this.Gamma_Enable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Gamma:";
            // 
            // txt_Gamma
            // 
            this.txt_Gamma.Location = new System.Drawing.Point(94, 167);
            this.txt_Gamma.Name = "txt_Gamma";
            this.txt_Gamma.Size = new System.Drawing.Size(92, 26);
            this.txt_Gamma.TabIndex = 13;
            this.txt_Gamma.Text = "1.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "增益";
            // 
            // txt_Gain
            // 
            this.txt_Gain.Location = new System.Drawing.Point(86, 105);
            this.txt_Gain.Name = "txt_Gain";
            this.txt_Gain.Size = new System.Drawing.Size(100, 26);
            this.txt_Gain.TabIndex = 12;
            this.txt_Gain.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "曝光:";
            // 
            // txt_Exposure
            // 
            this.txt_Exposure.Location = new System.Drawing.Point(86, 76);
            this.txt_Exposure.Name = "txt_Exposure";
            this.txt_Exposure.Size = new System.Drawing.Size(100, 26);
            this.txt_Exposure.TabIndex = 11;
            this.txt_Exposure.Text = "100";
            // 
            // btn_OK
            // 
            this.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.Location = new System.Drawing.Point(35, 207);
            this.btn_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(55, 26);
            this.btn_OK.TabIndex = 20;
            this.btn_OK.Text = "OK";
            this.btn_OK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Location = new System.Drawing.Point(131, 207);
            this.btn_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(55, 26);
            this.btn_Cancel.TabIndex = 20;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmSnapConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(221, 253);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Title);
            this.Controls.Add(this.Gamma_Enable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Gamma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Gain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Exposure);
            this.Name = "FrmSnapConfig";
            this.Text = "FrmSnapConfig";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FrmSnapConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.CheckBox Gamma_Enable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Gamma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Gain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Exposure;
        private Sunny.UI.UIButton btn_OK;
        private Sunny.UI.UIButton btn_Cancel;
    }
}