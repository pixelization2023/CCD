using System;
using System.Windows.Forms;
using CCDInspection.Core.Enums;
using CCDInspection.Core.Models;
using CCDInspection.Services;
using CCDInspection.Core;

namespace CCDInspection.UI.Forms
{
    public partial class FrmSettings : Form
    {
        private readonly AppConfig _config;
        private readonly ConfigService _configService;

        public FrmSettings(AppConfig config, ConfigService configService)
        {
            InitializeComponent();
            _config = config;
            _configService = configService;
            LoadSettingsToUI();
        }

        private void LoadSettingsToUI()
        {
            // 轴配置
            txt_IpAddress.Text = _config.Axis.IpAddress;
            txt_AutoSpeed.Text = _config.Axis.AutoSpeed.ToString();
            txt_Acceleration.Text = _config.Axis.Acceleration.ToString();
            txt_Deceleration.Text = _config.Axis.Deceleration.ToString();
            txt_ManualSpeed.Text = _config.Axis.ManualSpeed.ToString();
            txt_HomeSpeed.Text = _config.Axis.HomeSpeed.ToString();
            num_HomeModel.Value = _config.Axis.HomeModel;
            num_PosLimit.Value = (decimal)_config.Axis.PositiveSoftLimit;
            num_NegLimit.Value = (decimal)_config.Axis.NegativeSoftLimit;

            // 检测配置
            txt_SolDir.Text = _config.Inspection.SolDirectory;
            txt_ImagePath.Text = _config.Inspection.ImageSavePath;
            chk_SaveOK.Checked = _config.Inspection.SaveOkImages;
            chk_SaveNG.Checked = _config.Inspection.SaveNgImages;
            num_LightDelay.Value = _config.Inspection.LightOnDelayMs;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                // 轴配置
                _config.Axis.IpAddress = txt_IpAddress.Text.Trim();
                _config.Axis.AutoSpeed = float.Parse(txt_AutoSpeed.Text);
                _config.Axis.Acceleration = float.Parse(txt_Acceleration.Text);
                _config.Axis.Deceleration = float.Parse(txt_Deceleration.Text);
                _config.Axis.ManualSpeed = float.Parse(txt_ManualSpeed.Text);
                _config.Axis.HomeSpeed = float.Parse(txt_HomeSpeed.Text);
                _config.Axis.HomeModel = (int)num_HomeModel.Value;
                _config.Axis.PositiveSoftLimit = (float)num_PosLimit.Value;
                _config.Axis.NegativeSoftLimit = (float)num_NegLimit.Value;

                // 检测配置
                _config.Inspection.SolDirectory = txt_SolDir.Text.Trim();
                _config.Inspection.ImageSavePath = txt_ImagePath.Text.Trim();
                _config.Inspection.SaveOkImages = chk_SaveOK.Checked;
                _config.Inspection.SaveNgImages = chk_SaveNG.Checked;
                _config.Inspection.LightOnDelayMs = (int)num_LightDelay.Value;

                _configService.Save(_config);
                LogService.Information("配置保存成功");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                LogService.Error(ex, "配置保存失败");
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
