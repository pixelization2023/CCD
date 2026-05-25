using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCDInspection.Core.Models;

namespace CCDInspection.UI.Forms
{
    public partial class FrmSnapSet : Sunny.UI.UIForm
    {
        public Snap_Params m_snap_params = new Snap_Params();
        //public int m_snap_param_index = -1;
        //public int m_step_index = -1;
        //public int m_product_index = -1;
        public string m_snap_param_name;
        public string m_Path;
        public FrmSnapSet()
        {
            InitializeComponent();
        }
        private void RefreshList()
        {
            Snap_List.Items.Clear();

            for (int i = 0; i < m_snap_params.m_snap_params.Count; i++)
            {
                Snap_List.Items.Add("");

                Snap_List.Items[i].SubItems[0].Text = i.ToString();

                Snap_List.Items[i].SubItems.Add(m_snap_params.m_snap_params[i].Title);
                Snap_List.Items[i].SubItems.Add(m_snap_params.m_snap_params[i].ExposureTime.ToString());
                Snap_List.Items[i].SubItems.Add(m_snap_params.m_snap_params[i].Gain.ToString("0.000"));
                Snap_List.Items[i].SubItems.Add(m_snap_params.m_snap_params[i].Gamma_Enable.ToString());
                Snap_List.Items[i].SubItems.Add(m_snap_params.m_snap_params[i].Gamma.ToString("0.000"));
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmSnapConfig form = new FrmSnapConfig();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (m_snap_params.Add(form.m_param))
                {
                    RefreshList();
                }
                else
                {
                    MessageBox.Show("存在相同名称的工具");
                }

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Snap_List.SelectedItems.Count > 0)
            {
                m_snap_params.RemoveAt(Snap_List.SelectedItems[0].Index);
            }
            else if (Snap_List.Items.Count > 0)
            {
                m_snap_params.RemoveAt(Snap_List.Items.Count - 1);
            }
            RefreshList();
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (Snap_List.SelectedItems.Count > 0)
            {
                FrmSnapConfig form = new FrmSnapConfig();
                form.m_param = m_snap_params.m_snap_params[Snap_List.SelectedItems[0].Index];
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    m_snap_params.m_snap_params[Snap_List.SelectedItems[0].Index] = form.m_param;
                    RefreshList();
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //if (!m_snap_params.SaveData("D:\\ConfigMESUpLoad4500\\" + m_snap_param_index + "\\" + "snap_param" + m_snap_param_index + "-" + m_step_index + ".xml"))
            if (!m_snap_params.SaveData(m_Path))
            {
                MessageBox.Show("保存失败!");
                return;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void FrmSnapSet_Load(object sender, EventArgs e)
        {
            // if (!m_snap_params.LoadData(m_Path))
            // {
            //     MessageBox.Show("读取失败!");
            // }
            string directoryPath=Path.GetDirectoryName(m_Path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                MessageBox.Show("配置目录不存在，已自动创建:"+directoryPath);
            }
            if(!m_snap_params.LoadData(m_Path))
            {
                AddDefaultParams();
                MessageBox.Show("配置文件不存在");
            }
            RefreshList();
        }
        private void AddDefaultParams()
        {
           Snap_Param default_param = new Snap_Param();
           default_param.Title = "默认参数";
           default_param.ExposureTime = 10000;
           default_param.Gain = 10;
           default_param.Gamma_Enable = false;
           default_param.Gamma = 1.0f;
           m_snap_params.Add(default_param);
        }

        private void Snap_List_DoubleClick(object sender, EventArgs e)
        {
            btn_Modify_Click(null, null);
        }
    }
}
