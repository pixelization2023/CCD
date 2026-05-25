using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CCDInspection.Core.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class AliasAttribute : Attribute
    {
        public string Alias { get; private set; }

        public AliasAttribute(string alias)
        {
            Alias = alias;
        }
    }
    [Serializable]
    public class CodeConfig
    {
        //在反序列化前执行
        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
        }
        //在反序列化后执行
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
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

