namespace Vmtset
{
    partial class Form1
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
            this.vmRenderControl1 = new VMControls.Winform.Release.VmRenderControl();
            this.btn_lod = new System.Windows.Forms.Button();
            this.txt_show = new System.Windows.Forms.TextBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_clea = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vmRenderControl1
            // 
            this.vmRenderControl1.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl1.CoordinateInfoVisible = true;
            this.vmRenderControl1.ImageSource = null;
            this.vmRenderControl1.IsShowCustomROIMenu = false;
            this.vmRenderControl1.Location = new System.Drawing.Point(25, 46);
            this.vmRenderControl1.ModuleSource = null;
            this.vmRenderControl1.Name = "vmRenderControl1";
            this.vmRenderControl1.Size = new System.Drawing.Size(400, 300);
            this.vmRenderControl1.TabIndex = 0;
            // 
            // btn_lod
            // 
            this.btn_lod.Location = new System.Drawing.Point(526, 46);
            this.btn_lod.Name = "btn_lod";
            this.btn_lod.Size = new System.Drawing.Size(75, 23);
            this.btn_lod.TabIndex = 1;
            this.btn_lod.Text = "加载";
            this.btn_lod.UseVisualStyleBackColor = true;
            this.btn_lod.Click += new System.EventHandler(this.btn_lod_Click);
            // 
            // txt_show
            // 
            this.txt_show.Location = new System.Drawing.Point(50, 381);
            this.txt_show.Name = "txt_show";
            this.txt_show.Size = new System.Drawing.Size(297, 21);
            this.txt_show.TabIndex = 2;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(526, 75);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "运行";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_clea
            // 
            this.btn_clea.Location = new System.Drawing.Point(526, 127);
            this.btn_clea.Name = "btn_clea";
            this.btn_clea.Size = new System.Drawing.Size(75, 23);
            this.btn_clea.TabIndex = 1;
            this.btn_clea.Text = "clear";
            this.btn_clea.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_show);
            this.Controls.Add(this.btn_clea);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.btn_lod);
            this.Controls.Add(this.vmRenderControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VMControls.Winform.Release.VmRenderControl vmRenderControl1;
        private System.Windows.Forms.Button btn_lod;
        private System.Windows.Forms.TextBox txt_show;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_clea;
    }
}

