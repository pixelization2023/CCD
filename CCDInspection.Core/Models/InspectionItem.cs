using Newtonsoft.Json;

namespace CCDInspection.Core.Models
{
    /// <summary>
    /// 检测项配置
    /// </summary>
    public class InspectionItem
    {
        [JsonProperty("enable")]
        public bool Enable { get; set; } = true;

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
