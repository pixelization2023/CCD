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
    public partial class FrmPermissionLogin : Sunny.UI.UIForm
    {
        public FrmPermissionLogin()
        {
            InitializeComponent();
        }
        public string m_userName;
        public LoginConfigs m_LoginConfigs = new LoginConfigs();
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
        private bool VerifyPassword()
        {
                if (txt_Password.Text.Length == 0)
                {
                    MessageBox.Show("请输入登录密码！");
                    return false;
                }
    
                if(m_LoginConfigs.m_Logins.Count == 0)
                {
                    m_LoginConfigs.m_Logins.Add(new LoginConfig { UserName = "管理员", PassWord = "123456" });
                }

            string password = GetPassWord("管理员");
            if(string.IsNullOrEmpty(password))
            {
                MessageBox.Show("未找到管理员");
                return false;
            }
            if (!VerifyPassword(password, txt_Password.Text.Trim()))
            {
                MessageBox.Show("密码错误");
                return false;
            }
            return true;
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!VerifyPassword())
            {
                return;
            }
            m_userName = cmb_UserName.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
