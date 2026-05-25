using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CCDInspection.Core.Models
{
    public class OptionalConfig
    {
        public class OptionalPara
        {
            public string UpdateStatusToUI;
            public string Direct;
            public string ShieldBuzzer;
            public string FastModel;
            public string ReverseOutBoard;
            public string ShieldDoor;
            public string ShieldMES;
            public string SingleMachineTest;
            public string SaveSourceImage;
            public string SaveNGSourceImage;
            public string SaveResultImage;
            public string SheildUpDown;
        }

        public class OptionalParas
        {
            public OptionalPara optionalPara = new OptionalPara();
            public void SaveData(string filePath)
            {
                XmlDocument document = new XmlDocument();

                XmlElement ce = document.CreateElement("", "root", "");

                document.AppendChild(ce);

                XmlNode root = document.SelectSingleNode("root");

                XmlElement child = document.CreateElement("屏蔽选项配置");

                XmlAttribute A1 = document.CreateAttribute("刷新状态信息");
                XmlAttribute A2 = document.CreateAttribute("直进直出");
                XmlAttribute A3 = document.CreateAttribute("屏蔽蜂鸣器");
                XmlAttribute A5 = document.CreateAttribute("快速模式");
                XmlAttribute A6 = document.CreateAttribute("出板反转");
                XmlAttribute A9 = document.CreateAttribute("屏蔽安全门");
                XmlAttribute A7 = document.CreateAttribute("屏蔽MES");
                XmlAttribute A8 = document.CreateAttribute("单机测试");
                XmlAttribute A10 = document.CreateAttribute("保存原图");
                XmlAttribute A11 = document.CreateAttribute("保存NG原图");
                XmlAttribute A12= document.CreateAttribute("保存结果图片");
                XmlAttribute A13= document.CreateAttribute("屏蔽升降");


                A1.Value = optionalPara.UpdateStatusToUI;
                A2.Value = optionalPara.Direct;
                A3.Value = optionalPara.ShieldBuzzer;
                A5.Value = optionalPara.FastModel;
                A6.Value = optionalPara.ReverseOutBoard;
                A7.Value = optionalPara.ShieldDoor;
                A8.Value = optionalPara.ShieldMES;
                A9.Value = optionalPara.SingleMachineTest;
                A10.Value = optionalPara.SaveSourceImage;
                A11.Value = optionalPara.SaveNGSourceImage;
                A12.Value = optionalPara.SaveResultImage;
                A13.Value = optionalPara.SheildUpDown;

                child.Attributes.Append(A1);
                child.Attributes.Append(A2);
                child.Attributes.Append(A3);
                child.Attributes.Append(A5);
                child.Attributes.Append(A6);
                child.Attributes.Append(A7);
                child.Attributes.Append(A8);
                child.Attributes.Append(A9);
                child.Attributes.Append(A10);
                child.Attributes.Append(A11);
                child.Attributes.Append(A12);
                child.Attributes.Append(A13);

                root.AppendChild(child);
                document.Save(filePath);
            }

            public void LoadData(string filepath)
            {

                XmlDocument document = new XmlDocument();
                document.Load(filepath);

                XmlNode root = document.SelectSingleNode("root");
                optionalPara.UpdateStatusToUI = root.ChildNodes[0].Attributes["刷新状态信息"].Value.ToString();
                optionalPara.Direct = root.ChildNodes[0].Attributes["直进直出"].Value.ToString();
                optionalPara.ShieldBuzzer = root.ChildNodes[0].Attributes["屏蔽蜂鸣器"].Value.ToString();
                optionalPara.FastModel = root.ChildNodes[0].Attributes["快速模式"].Value.ToString();
                optionalPara.ReverseOutBoard = root.ChildNodes[0].Attributes["出板反转"].Value.ToString();
                optionalPara.ShieldDoor = root.ChildNodes[0].Attributes["屏蔽安全门"].Value.ToString();
                optionalPara.ShieldMES = root.ChildNodes[0].Attributes["屏蔽MES"].Value.ToString();
                optionalPara.SingleMachineTest = root.ChildNodes[0].Attributes["单机测试"].Value.ToString();
                optionalPara.SaveSourceImage = root.ChildNodes[0].Attributes["保存原图"].Value.ToString();
                optionalPara.SaveNGSourceImage = root.ChildNodes[0].Attributes["保存NG原图"].Value.ToString();
                optionalPara.SaveResultImage = root.ChildNodes[0].Attributes["保存结果图片"].Value.ToString();
                //optionalPara.SheildUpDown = root.ChildNodes[0].Attributes["屏蔽升降"].Value.ToString();
            }
        }
    }
}
