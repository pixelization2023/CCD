using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CCDInspection.Core.Models
{
    public class CheckItem
    {
        public bool ItemEnable;// 是否启用该检查项
        public int ItemIndex;// 检查项序号（唯一标识）
        public string ItemContent;// 检查项内容描述
    }

    public class CheckItemsConfig
    {
        public List<CheckItem> m_CheckItems = new List<CheckItem>();

        //添加检查项
        public bool Add(CheckItem sp)
        {
            // 限制最多10个检查项
            if (m_CheckItems.Count > 10)
            {
                return false;
            }

            bool ret = true;
            // 检查是否已存在相同序号或相同内容的检查项
            for (int i = 0; i < m_CheckItems.Count; i++)
            {
                if (m_CheckItems[i].ItemIndex == sp.ItemIndex|| m_CheckItems[i].ItemContent == sp.ItemContent)
                {
                    ret = false;
                    break;
                }
            }

            // 如果不存在重复项，则添加
            if (ret)
            {
                m_CheckItems.Add(sp);
            }

            return ret;
        }

        //删除检查项
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < m_CheckItems.Count)
            {
                m_CheckItems.RemoveAt(index);
            }
        }


        //检查检查项是否存在
        public bool Exists(int index,string content)
        {
            bool ret = false;

            for (int i = 0; i < m_CheckItems.Count; i++)
            {
                if (m_CheckItems[i].ItemIndex == index || m_CheckItems[i].ItemContent == content)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        public void Clear()
        {
            m_CheckItems.Clear();
        }

        //保存检查项配置
        public bool SaveData(string filepath)
        {
            try
            {
                //创建XML文档
                XmlDocument document = new XmlDocument();

                //创建根元素
                XmlElement ce = document.CreateElement("", "root", "");

                document.AppendChild(ce);

                XmlNode root = document.SelectSingleNode("root");

                //遍历所有检查项
                for (int i = 0; i < m_CheckItems.Count; i++)
                {
                    //创建检查项元素
                    XmlElement child = document.CreateElement("检查项" + i);

                    XmlAttribute A1 = document.CreateAttribute("启用");
                    XmlAttribute A2 = document.CreateAttribute("序号");
                    XmlAttribute A3 = document.CreateAttribute("内容");

                    //赋值
                    A1.Value = m_CheckItems[i].ItemEnable.ToString();
                    A2.Value = m_CheckItems[i].ItemIndex.ToString();
                    A3.Value = m_CheckItems[i].ItemContent.ToString();

                    //将属性添加到元素
                    child.Attributes.Append(A1);
                    child.Attributes.Append(A2);
                    child.Attributes.Append(A3);

                    //将检查项元素添加到根元素
                    root.AppendChild(child);
                }
                document.Save(filepath);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //加载检查项配置
        public bool LoadData(string filepath)
        {
            Clear();
            try
            {
                // 检查文件是否存在，不存在则创建默认文件
                if (!System.IO.File.Exists(filepath))
                {
                    SaveData(filepath);
                    return true;
                }

                XmlDocument document = new XmlDocument();
                document.Load(filepath);//加载XML文件
                XmlNode root = document.SelectSingleNode("root");
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    CheckItem ci=new CheckItem();
                    ci.ItemEnable = bool.Parse(root.ChildNodes[i].Attributes["启用"].Value);
                    ci.ItemIndex = int.Parse(root.ChildNodes[i].Attributes["序号"].Value);
                    ci.ItemContent = root.ChildNodes[i].Attributes["内容"].Value;
                    m_CheckItems.Add(ci);
                }
            }
            catch (Exception ex)
            {
                // MessageBox removed from Core
                return false;
            }
            return true;
        }
    }
}
