using System;
using System.Runtime.Serialization;

namespace CCDInspection.Core.Models
{
    [Serializable]
    public struct ProductionInfo
    {
        public ushort CalculateNGYeilNGCount;// 当前批次不良品率计数（可能是中间变量）
        public ushort CurrentOKCount;// 当前批次良品数
        public ushort CurrentNGCount;// 当前批次不良品数
        public ushort CurrentTotalCount;// 当前批次总数量
        public double CurrentOKYeild;// 当前批次良品率
        public double CurrentNGYeild;// 当前批次不良品率

        public UInt32 TotalOKCount;// 总良品数
        public UInt32 TotalNGCount;// 总不良品数
        public UInt32 TotalCount;// 总数量
        public double TotalOKYeild;// 总良品率
    
        public double TotalNGYeild;// 总不良品率
    }
    [Serializable]
    public class ProductionInfos
    {
        public ProductionInfo m_ProductInfo = new ProductionInfo();
        //在反序列化前执行
        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {

        }
        //在反序列化后执行
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (m_ProductInfo.Equals(default(ProductionInfo))) m_ProductInfo = new ProductionInfo();
        }

        //在序列化前执行
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {

        }

        //在序列化后执行
        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {

        }
    }
}
