using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CCDInspection.Core.Models
{
    public struct AxisBasicConfig
    {
        public string IPAddress;// 控制器IP地址

        //运动参数
        public float PulseEquivalent;// 脉冲当量
        public float AutoSpeed;// 自动速度
        public float Acceleration;// 加速度
        public float Deceleration;// 减速度
        //软件限位
        public float PositiveSoftLimit;// 正软极限
        public float NegativeSoftLimit;// 负软极限
        //轴标识
        public int AxisIndex;// 轴号
        //手动控制参数
        public float ManualSpeed;//手动点动速度
        public float ManualDistance;//手动点动距离
        //回零参数
        public int HomeModel;//回零模式
        public float HomeSpeed;//回零速度
        public float SlowSpeed;//爬行速度

        //IO信号点号
        public int OriginPointNum;//原点点号
        public int PositivePointNum;//正极限点号
        public int NegtivePointNum;//负极限点号
        public int AlarmPointNum;//报警点号
    }
    public class AxisBasicConfigs
    {
        public List< AxisBasicConfig >m_AxisBasicConfig = new List<AxisBasicConfig>();
        public void SaveData(string filePath)//保存轴基本配置到XML文件
        {
        
            XmlDocument document = new XmlDocument();

            XmlElement ce = document.CreateElement("", "root", "");

            document.AppendChild(ce);

            XmlNode root = document.SelectSingleNode("root");

            for (int i = 0; i < m_AxisBasicConfig.Count; i++)
            {
                XmlElement child = document.CreateElement("轴" + i);

                XmlAttribute A1 = document.CreateAttribute("IP地址");
                XmlAttribute A2 = document.CreateAttribute("脉冲当量");
                XmlAttribute A3 = document.CreateAttribute("自动速度");
                XmlAttribute A4 = document.CreateAttribute("加速度");
                XmlAttribute A5 = document.CreateAttribute("减速度");
                XmlAttribute A6 = document.CreateAttribute("正软极限");
                XmlAttribute A7 = document.CreateAttribute("负软极限");
                XmlAttribute A8 = document.CreateAttribute("轴号");
                XmlAttribute A9 = document.CreateAttribute("手动速度");
                XmlAttribute A10 = document.CreateAttribute("手动运行距离");
                XmlAttribute A11 = document.CreateAttribute("回零模式");
                XmlAttribute A12 = document.CreateAttribute("回零速度");
                XmlAttribute A13 = document.CreateAttribute("爬行速度");

                XmlAttribute A14 = document.CreateAttribute("正极限");
                XmlAttribute A15 = document.CreateAttribute("负极限");
                XmlAttribute A16 = document.CreateAttribute("原点");
                XmlAttribute A17 = document.CreateAttribute("报警");

                //赋值
                A1.Value = m_AxisBasicConfig[i].IPAddress.ToString();
                A2.Value = m_AxisBasicConfig[i].PulseEquivalent.ToString();
                A3.Value = m_AxisBasicConfig[i].AutoSpeed.ToString();
                A4.Value = m_AxisBasicConfig[i].Acceleration.ToString();
                A5.Value = m_AxisBasicConfig[i].Deceleration.ToString();
                A6.Value = m_AxisBasicConfig[i].PositiveSoftLimit.ToString();
                A7.Value = m_AxisBasicConfig[i].NegativeSoftLimit.ToString();
                A8.Value = m_AxisBasicConfig[i].AxisIndex.ToString();
                A9.Value = m_AxisBasicConfig[i].ManualSpeed.ToString();
                A10.Value = m_AxisBasicConfig[i].ManualDistance.ToString();
                A11.Value = m_AxisBasicConfig[i].HomeModel.ToString();
                A12.Value = m_AxisBasicConfig[i].HomeSpeed.ToString();
                A13.Value = m_AxisBasicConfig[i].SlowSpeed.ToString();

                A14.Value = m_AxisBasicConfig[i].PositivePointNum.ToString();
                A15.Value = m_AxisBasicConfig[i].NegtivePointNum.ToString();
                A16.Value = m_AxisBasicConfig[i].OriginPointNum.ToString();
                A17.Value = m_AxisBasicConfig[i].AlarmPointNum.ToString();


                //添加属性到元素
                child.Attributes.Append(A1);
                child.Attributes.Append(A2);
                child.Attributes.Append(A3);
                child.Attributes.Append(A4);
                child.Attributes.Append(A5);
                child.Attributes.Append(A6);
                child.Attributes.Append(A7);
                child.Attributes.Append(A8);
                child.Attributes.Append(A9);
                child.Attributes.Append(A10);
                child.Attributes.Append(A11);
                child.Attributes.Append(A12);
                child.Attributes.Append(A13);

                child.Attributes.Append(A14);
                child.Attributes.Append(A15);
                child.Attributes.Append(A16);
                child.Attributes.Append(A17);

                //添加元素到根节点
                root.AppendChild(child);
            }

            document.Save(filePath);
        }

    }
}
