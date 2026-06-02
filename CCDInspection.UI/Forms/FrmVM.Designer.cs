namespace CCDInspection.UI.Forms
{
    partial class FrmVM
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
            this.components = new System.ComponentModel.Container();
            this.vmMainViewConfigControl1 = new VMControls.Winform.Release.VmMainViewConfigControl();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.timer_Pos = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // vmMainViewConfigControl1
            // 
            this.vmMainViewConfigControl1.Location = new System.Drawing.Point(11, 11);
            this.vmMainViewConfigControl1.Margin = new System.Windows.Forms.Padding(2);
            this.vmMainViewConfigControl1.Name = "vmMainViewConfigControl1";
            this.vmMainViewConfigControl1.Size = new System.Drawing.Size(1675, 1019);
            this.vmMainViewConfigControl1.TabIndex = 0;
// TODO: “”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1700, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Z: --";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_up
            // 
            this.btn_up.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btn_up.Location = new System.Drawing.Point(1720, 80);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(140, 50);
            this.btn_up.TabIndex = 2;
            this.btn_up.Text = "上升 ▲";
            this.btn_up.UseVisualStyleBackColor = true;
            // 
            // btn_down
            // 
            this.btn_down.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btn_down.Location = new System.Drawing.Point(1720, 145);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(140, 50);
            this.btn_down.TabIndex = 3;
            this.btn_down.Text = "下降 ▼";
            this.btn_down.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btn_save.Location = new System.Drawing.Point(1720, 220);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(140, 50);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "另存方案";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // timer_Pos
            // 
            this.timer_Pos.Interval = 200;
            this.timer_Pos.Tick += new System.EventHandler(this.timer_Pos_Tick);
            // 
            // FrmVM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vmMainViewConfigControl1);
            this.Name = "FrmVM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "视觉方案配置";
            this.ResumeLayout(false);

        }

        #endregion

        private VMControls.Winform.Release.VmMainViewConfigControl vmMainViewConfigControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Timer timer_Pos;
    }
}
