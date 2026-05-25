using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CCDInspection.Core.Models
{
    public struct Snap_Param
    {
        public int ExposureTime;// 曝光时间（单位：微秒μs）
        public int Gain;// 增益（单位：dB）
        public bool Gamma_Enable;// 是否启用Gamma校正
        public float Gamma;// Gamma值（0-1）
        public string Title;// 参数配置名称（如"标准模式"、"低光模式"）
    }

    public class Snap_Params
    {
        public List<Snap_Param> m_snap_params = new List<Snap_Param>();

        public bool Add(Snap_Param sp)
        {
            // 限制最多10个拍照参数配置
            if (m_snap_params.Count > 10)
            {
                return false;
            }

            bool ret = true;
            // 检查是否已存在相同名称的配置
            for (int i = 0; i < m_snap_params.Count; i++)
            {
                if (m_snap_params[i].Title == sp.Title)
                {
                    ret = false;
                    break;
                }
            }

            if (ret)
            {
                m_snap_params.Add(sp);
            }

            return ret;
        }

        //删除拍照参数
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < m_snap_params.Count)
            {
                m_snap_params.RemoveAt(index);
            }
        }

        //检查参数是否存在
        public bool Exists(string ImageName)
        {
            bool ret = false;

            for (int i = 0; i < m_snap_params.Count; i++)
            {
                if (m_snap_params[i].Title == ImageName)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        //根据名称获取索引
        public bool GetImageIndexFromImageName(ref int image_index, string image_name)
        {
            bool ret = false;

            for (int i = 0; i < m_snap_params.Count; i++)
            {
                if (m_snap_params[i].Title == image_name)
                {
                    image_index = i;
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        //清空所有配置
        public void Clear()
        {
            m_snap_params.Clear();
        }

        //保存配置到XML文件
        public bool SaveData(string filepath)
        {
            try
            {
                // 创建XML文档对象
                XmlDocument document = new XmlDocument();

                // 创建根元素 <root>
                XmlElement ce = document.CreateElement("", "root", "");

                document.AppendChild(ce);

                XmlNode root = document.SelectSingleNode("root");

                // 遍历所有拍照参数配置
                for (int i = 0; i < m_snap_params.Count; i++)
                {
                    XmlElement child = document.CreateElement("拍照" + i);

                    XmlAttribute A1 = document.CreateAttribute("名称");
                    XmlAttribute A2 = document.CreateAttribute("曝光");
                    XmlAttribute A3 = document.CreateAttribute("增益");
                    XmlAttribute A4 = document.CreateAttribute("Gamma_Enable");
                    XmlAttribute A5 = document.CreateAttribute("Gamma");

                    A1.Value = m_snap_params[i].Title;
                    A2.Value = m_snap_params[i].ExposureTime.ToString();
                    A3.Value = m_snap_params[i].Gain.ToString();
                    A4.Value = m_snap_params[i].Gamma_Enable.ToString();
                    A5.Value = m_snap_params[i].Gamma.ToString("0.000");

                    child.Attributes.Append(A1);
                    child.Attributes.Append(A2);
                    child.Attributes.Append(A3);
                    child.Attributes.Append(A4);
                    child.Attributes.Append(A5);

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

        //从XML文件加载配置
        public bool LoadData(string filepath)
        {
            Clear();

            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(filepath);// 加载XML文件

                XmlNode root = document.SelectSingleNode("root");


                // 遍历所有子节点
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    Snap_Param sp;

                    // 读取XML属性并赋值
                    sp.Title = root.ChildNodes[i].Attributes["名称"].Value;
                    sp.ExposureTime = int.Parse(root.ChildNodes[i].Attributes["曝光"].Value);
                    sp.Gain = int.Parse(root.ChildNodes[i].Attributes["增益"].Value);
                    sp.Gamma_Enable = bool.Parse(root.ChildNodes[i].Attributes["Gamma_Enable"].Value);
                    sp.Gamma = float.Parse(root.ChildNodes[i].Attributes["Gamma"].Value);
                    m_snap_params.Add(sp);
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
