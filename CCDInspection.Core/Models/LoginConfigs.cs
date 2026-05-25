using System.Collections.Generic;
using System.Xml;

namespace CCDInspection.Core.Models
{
    public class LoginConfig
    {
        public string UserName="管理员";
        public string PassWord="123456";
    }
    public class LoginConfigs
    {
        public List< LoginConfig> m_Logins = new List<LoginConfig>();

        public void SaveData(string filePath)
        {
            XmlDocument document = new XmlDocument();

            XmlElement ce = document.CreateElement("", "root", "");

            document.AppendChild(ce);

            XmlNode root = document.SelectSingleNode("root");

            for (int i = 0; i < m_Logins.Count; i++)
            {
                XmlElement child = document.CreateElement("用户" + i);

                XmlAttribute A1 = document.CreateAttribute("用户名");
                XmlAttribute A2 = document.CreateAttribute("密码");


                A1.Value = m_Logins[i].UserName.ToString();
                A2.Value = m_Logins[i].PassWord.ToString();

                child.Attributes.Append(A1);
                child.Attributes.Append(A2);
                root.AppendChild(child);
            }

            document.Save(filePath);
        }

        public void LoadData(string filepath)
        {

            XmlDocument document = new XmlDocument();
            document.Load(filepath);

            XmlNode root = document.SelectSingleNode("root");
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                LoginConfig lc=new LoginConfig();
                lc.UserName = root.ChildNodes[i].Attributes["用户名"].Value;
                lc.PassWord = root.ChildNodes[i].Attributes["密码"].Value;
                m_Logins.Add(lc);
            }

        }
    }
}
