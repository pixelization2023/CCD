using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCDInspection.Core.Models;

namespace CCDInspection.UI.Forms
{
    public partial class FrmSnapConfig : Sunny.UI.UIForm
    {
        public Snap_Param m_param;
        public FrmSnapConfig()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            m_param.Title = txt_Title.Text;
            m_param.ExposureTime = int.Parse(txt_Exposure.Text);
            m_param.Gain = int.Parse(txt_Gain.Text);
            m_param.Gamma_Enable = Gamma_Enable.Checked;
            m_param.Gamma = float.Parse(txt_Gamma.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmSnapConfig_Load(object sender, EventArgs e)
        {
            txt_Title.Text = m_param.Title;
            txt_Exposure.Text = m_param.ExposureTime.ToString();
            txt_Gain.Text = m_param.Gain.ToString();
            Gamma_Enable.Checked = m_param.Gamma_Enable;
            txt_Gamma.Text = m_param.Gamma.ToString();
        }
    }
}
