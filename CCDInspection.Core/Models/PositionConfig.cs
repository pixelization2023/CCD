using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CCDInspection.Core.Models
{
    [Serializable]
    public class PositionConfig
    {
        public BindingList<PathPlan> PathPlans = new BindingList<PathPlan>();
        public BindingList<AssistPoint> AssistPoints = new BindingList<AssistPoint>();
        //在反序列化前执行
        [OnDeserializing()]
        public void OnDeserializingMethod(StreamingContext context)
        {
        }
        //在反序列化后执行
        [OnDeserialized()]
        public void OnDeserializedMethod(StreamingContext context)
        {
            if (PathPlans == null) PathPlans = new BindingList<PathPlan>();
            if (AssistPoints == null) AssistPoints = new BindingList<AssistPoint>();
        }

        //在序列化前执行
        [OnSerializing()]
        public void OnSerializingMethod(StreamingContext context)
        {
        }

        //在序列化后执行
        [OnSerialized()]
        public void OnSerializedMethod(StreamingContext context)
        {
        }
    }
    /// <summary>
    /// 路线规划
    /// </summary>
    [Serializable]
    public class PathPlan
    {
        public int Index { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

       //public ushort CodeLineType { get; set; }

       // public ushort CodeType { get; set; }

        public float YSpeed { get; set; }

        public float ZSpeed { get; set; }

        public string MaterialNum { get; set; }

        public int MatrlNumStartIndex { get; set; }

        public int MatrlNumEndIndex { get; set; }

        public string Lot { get; set; }

        public int LotStartIndex { get; set; }

        public int LotEndIndex { get; set; }
    }
    [Serializable]
    public class AssistPoint
    {
        public string Location { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public float YSpeed { get; set; }
        public float ZSpeed { get; set; }
    }
}
