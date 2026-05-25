using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace CCDInspection.Core.Models
{
    public class ProductTypeConfig
    {
        public struct ProductType
        {
            public string ProductIndex;// 产品编号（唯一标识，支持字母）
            public string ProductName;// 产品名称
            public int SnapParamIndex;// 拍照参数索引（关联相机配置）
            public int SnapCount;// 拍照次数
            public string ProductColor;// 产品颜色
            public int RoutePlanIndex;// 路径计划索引（关联路径配置）
            public float ZHeight;// Z轴高度（相机高度，单位：mm）
            
            // 公母端检测相关
            public bool IsMale;      // 是否为公端
            public bool IsFemale;   // 是否为母端
            public string GenderType; // 公母端类型: "Male"(公), "Female"(母), "Both"(两者都要检测)
            public string ExpectedStyle; // 预期样式
        }

        public List<ProductType> m_products = new List<ProductType>();

        //检查产品是否存在
        public bool ExistProduct(string product_index)
        {
            bool ret = false;

            for (int i = 0; i < m_products.Count; i++)
            {
                if (m_products[i].ProductIndex == product_index)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        //根据编号获取产品
        public bool GetProductTypeByIndex(string index, ref ProductType type)
        {
            bool ret = false;
            for (int i = 0; i < m_products.Count; i++)
            {
                if (m_products[i].ProductIndex == index)
                {
                    type = m_products[i];
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        //根据名称获取产品
        public bool GetProductType(string name, ref ProductType type)
        {
            bool ret = false;
            for (int i = 0; i < m_products.Count; i++)
            {
                if (m_products[i].ProductName == name)
                {
                    type = m_products[i];
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        //修改产品信息
        public bool ModifyProductType(string index, ProductType productType)
        {
            bool ret = false;
            for (int i = 0; i < m_products.Count; i++)
            {
                if (m_products[i].ProductIndex == index)
                {
                    m_products[i] = productType;
                    ret = true;
                    break;
                }
            }

            return ret;
        }


        //保存配置到CSV文件
        public bool Save(string filepath)
        {
            bool ret = true;

             // 创建StreamWriter，覆盖模式（false）
            StreamWriter writer = new StreamWriter(filepath, false);

            string str = "";

            //遍历所有产品
            for (int i = 0; i < m_products.Count; i++)
            {
                // 拼接CSV格式字符串：编号,名称,拍照参数索引,拍照次数,产品颜色,路径索引,Z轴高度
                str = m_products[i].ProductIndex;
                str += ",";
                str += m_products[i].ProductName;
                str += ",";
                str += m_products[i].SnapParamIndex.ToString();
                str += ",";
                str += m_products[i].SnapCount.ToString();
                str += ",";
                str += m_products[i].ProductColor;
                str += ",";
                str += m_products[i].RoutePlanIndex.ToString();
                str += ",";
                str += m_products[i].ZHeight.ToString();
                writer.WriteLine(str);
            }
            writer.Close();
            writer.Dispose();
            writer = null;
            return ret;
        }

        //从CSV文件加载配置
        public bool Load(string filepath)
        {
            bool ret = true;

             // 检查文件是否存在
            if (File.Exists(filepath))
            {
                m_products.Clear();//清空现有数据
                ProductType pt = new ProductType();

                // 创建StreamReader读取文件
                StreamReader reader = new StreamReader(filepath);

                string str = "";
                //逐行读取
                while ((str = reader.ReadLine()) != null)
                {
                    List<string> m_items = new List<string>();

                    int count = 1;
                    int pre_index = 0;

                    //查找第一个逗号
                    int index = str.IndexOf(",", 0);
                    if (index == -1)
                    {
                        continue;
                    }

                    else
                    {
                        m_items.Add(str.Substring(pre_index, index - pre_index));//将对象添加到 System.Collections.Generic.List<T> 的结尾处。
                                                                                 //Substring截取从此实例检索子字符串。子字符串从指定的字符位置开始且具有指定的长度。
                    }

                    //查找后续逗号
                    while (count < 5)
                    {
                        pre_index = index + 1;
                        index = str.IndexOf(",", index + 1);
                        if (index == -1)
                        {
                            continue;
                        }
                        else
                        {
                            m_items.Add(str.Substring(pre_index, index - pre_index));
                        }
                        count++;
                    }

                    //截取最后一个字段
                    pre_index = index + 1;
                    if (str.Length > pre_index)
                    {
                        m_items.Add(str.Substring(pre_index, str.Length - pre_index));
                    }

                    //解析字段并赋值
                    if (m_items.Count > 5)
                    {
                        pt.ProductIndex = m_items[0];
                        pt.ProductName = m_items[1];
                        
                        // 安全解析数字，避免格式错误
                        if (int.TryParse(m_items[2], out int snapParam))
                            pt.SnapParamIndex = snapParam;
                        else
                            pt.SnapParamIndex = 1;
                        
                        if (int.TryParse(m_items[3], out int snapCount))
                            pt.SnapCount = snapCount;
                        else
                            pt.SnapCount = 1;
                        
                        pt.ProductColor = m_items[4];
                        
                        if (int.TryParse(m_items[5], out int routePlan))
                            pt.RoutePlanIndex = routePlan;
                        else
                            pt.RoutePlanIndex = 1;
                        
                        if (m_items.Count > 6 && float.TryParse(m_items[6], out float zHeight))
                        {
                            pt.ZHeight = zHeight;
                        }
                        else
                        {
                            pt.ZHeight = 0.0f;
                        } 
                    }


                    m_products.Add(pt);
                    m_items.Clear();
                }
                reader.Close();
                reader.Dispose();
                reader = null;
            }
            else
            {
                return false;
            }
            return ret;
        }
    }
}
