using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CCDInspection.Core;
using CCDInspection.Core.Models;



namespace CCDInspection.UI.Forms
{
    public partial class FrmLogin : Sunny.UI.UIForm
    {

        LoginConfigs m_LoginConfigs = new LoginConfigs();
        ProductTypeConfig m_product = new ProductTypeConfig();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e) => ReloadProducts();

        /// <summary>从 ProductConfig.json 重新加载产品数据 — 保存配方后无需重启</summary>
        public void ReloadProducts()
        {
            try
            {
                cmb_ProductType.Items.Clear();
                Init_uiComboBox_Productmodel();
                var ports = new HashSet<string>();
                foreach (var p in productModels) ports.Add(p.Product_port);
                foreach (var port in ports) cmb_ProductType.Items.Add(port);
                if (cmb_ProductType.Items.Count > 0) cmb_ProductType.SelectedIndex = 0;

                m_product.m_products.Clear();
                foreach (var p in productModels)
                {
                    m_product.m_products.Add(new ProductTypeConfig.ProductType
                    {
                        ProductIndex = p.Product_code,
                        ProductName = p.Product_port,
                        ProductColor = p.Product_color,
                        SnapCount = 1,
                        RoutePlanIndex = 1,
                        SnapParamIndex = 1,
                        ZHeight = float.TryParse(p.Product_zHeight, out var zh) ? zh : 0f
                    });
                }
                cmb_UserName.SelectedIndex = 0;

                if (m_LoginConfigs.m_Logins.Count == 0)
                    m_LoginConfigs.m_Logins.Add(new LoginConfig { UserName = "管理员", PassWord = "123456" });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ReloadProducts(); // 每次显示时刷新，加载最新配方数据
        }
        List<ProductModel> productModels;
        private void Init_uiComboBox_Productmodel()
        {
            productModels = new List<ProductModel>();
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "ProductConfig.json");
                if (File.Exists(path))
                {
                    var Json_str = File.ReadAllText(path);
                    productModels = JsonConvert.DeserializeObject<List<ProductModel>>(Json_str) ?? new List<ProductModel>();
                }
            }
            catch { }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!VerifyPassword())
            {
                return;
            }
            if (txt_Account.Text.Length == 0)
            {
                MessageBox.Show("管理ID不能为空");
                return;
            }
        
            FrmMain m_FrmMain = CompositionRoot.Resolve<FrmMain>();
            m_FrmMain._loginConfigs = m_LoginConfigs;
            m_FrmMain._productConfig = m_product;
            // 设置当前选中的端口类型
            //if (cmb_ProductType.SelectedItem == null || uiComboBox_Productmodel.SelectedItem == null)
            //{
            //    MessageBox.Show("请选择产品类型和型号");
            //    return;
            //}
            m_FrmMain._currentProductPort = cmb_ProductType.Text.ToString();
            m_FrmMain._currentProductModel = uiComboBox_Productmodel.Text.ToString();
            m_FrmMain._operatorId = txt_Account.Text.Trim();
            m_FrmMain._currentUser = cmb_UserName.Text.ToString();
            m_FrmMain.StartPosition = FormStartPosition.CenterScreen;
            m_FrmMain._needLoadRecipe = true; // 标记需要在FrmMain初始化后加载配方
            m_FrmMain.Show();
            this.Hide();

        }

        private bool VerifyPassword()
        {
            if (txt_Password.Text.Length == 0)
            {
                MessageBox.Show("请输入登录密码！");
                return false;
            }

            if (cmb_UserName.SelectedItem.ToString() == "管理员")
            {
                string password = GetPassWord("管理员");
                if (!VerifyPassword(password, txt_Password.Text.Trim()))
                {
                    MessageBox.Show("密码错误");
                    return false;
                }
            }

            return true;
        }

        private string GetPassWord(string username)
        {
            for (int i = 0; i < m_LoginConfigs.m_Logins.Count; i++)
            {
                if (m_LoginConfigs.m_Logins[i].UserName == username)
                {
                    return m_LoginConfigs.m_Logins[i].PassWord;
                }
            }
            return string.Empty;
        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            return password == hashedPassword;
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiComboBox_Productmodel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productModels == null) return;
            var selectedPort = cmb_ProductType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedPort)) return;

            uiComboBox_Productmodel.Items.Clear();
            for (int i = 0; i < productModels.Count; i++)
            {
                var item = productModels[i];
                if (item.Product_port == selectedPort)
                {
                    uiComboBox_Productmodel.Items.Add(item.Product_model);
                   
                    
                }
            }
        }
    }
}
