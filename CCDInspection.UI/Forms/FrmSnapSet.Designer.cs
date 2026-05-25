
namespace CCDInspection.UI.Forms
{
    partial class FrmSnapSet
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
            this.Snap_List = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Add = new Sunny.UI.UIButton();
            this.btn_Delete = new Sunny.UI.UIButton();
            this.btn_Modify = new Sunny.UI.UIButton();
            this.btn_Save = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // Snap_List
            // 
            this.Snap_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.Snap_List.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Snap_List.FullRowSelect = true;
            this.Snap_List.GridLines = true;
            this.Snap_List.HideSelection = false;
            this.Snap_List.Location = new System.Drawing.Point(0, 35);
            this.Snap_List.MultiSelect = false;
            this.Snap_List.Name = "Snap_List";
            this.Snap_List.Size = new System.Drawing.Size(672, 413);
            this.Snap_List.TabIndex = 4;
            this.Snap_List.UseCompatibleStateImageBehavior = false;
            this.Snap_List.View = System.Windows.Forms.View.Details;
            this.Snap_List.DoubleClick += new System.EventHandler(this.Snap_List_DoubleClick);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "编号";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "曝光";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "增益";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Gamma_Enable";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Gamma";
            this.columnHeader5.Width = 100;
            // 
            // btn_Add
            // 
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.Location = new System.Drawing.Point(3, 454);
            this.btn_Add.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(126, 59);
            this.btn_Add.TabIndex = 5;
            this.btn_Add.Text = "增    加";
            this.btn_Add.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.Location = new System.Drawing.Point(135, 454);
            this.btn_Delete.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(126, 59);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "删    除";
            this.btn_Delete.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Modify.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Modify.Location = new System.Drawing.Point(267, 454);
            this.btn_Modify.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(126, 59);
            this.btn_Modify.TabIndex = 5;
            this.btn_Modify.Text = "修    改";
            this.btn_Modify.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.Location = new System.Drawing.Point(546, 454);
            this.btn_Save.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(126, 59);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "保    存";
            this.btn_Save.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // FrmSnapSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(675, 522);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Modify);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.Snap_List);
            this.Name = "FrmSnapSet";
            this.Text = "FrmSnapSet";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 675, 522);
            this.Load += new System.EventHandler(this.FrmSnapSet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Snap_List;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private Sunny.UI.UIButton btn_Add;
        private Sunny.UI.UIButton btn_Delete;
        private Sunny.UI.UIButton btn_Modify;
        private Sunny.UI.UIButton btn_Save;
    }
}