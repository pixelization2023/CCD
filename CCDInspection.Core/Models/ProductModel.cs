using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCDInspection.Core.Models
{
    public class ProductModel
    {
        /// <summary>
        /// 产品型号
        /// </summary>
        public string Product_model { get; set; }

        /// <summary>
        /// 产品端口
        /// </summary>
        public string Product_port { get; set; }

        /// <summary>
        /// 产品颜色
        /// </summary>
        public string Product_color { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string Product_code { get; set; }

        /// <summary>
        /// Z轴检测高度(mm)
        /// </summary>
        public string Product_zHeight { get; set; }
    }
}
