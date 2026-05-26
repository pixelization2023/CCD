using System;
using System.Security.Permissions;
using Newtonsoft.Json;

namespace CCDInspection.Core.Models
{
    /// <summary>
    /// 单次检测记录
    /// </summary>
    public class InspectionRecord
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("productIndex")]
        public string ProductIndex { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("cycleTimeMs")]
        public long CycleTimeMs { get; set; }

        [JsonProperty("productColor")]
        public string    ProductColor { get; set; }

        [JsonProperty("productCode")]
        public string ProductCode { get; set; }
    }
}
