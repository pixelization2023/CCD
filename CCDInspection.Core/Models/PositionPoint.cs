using Newtonsoft.Json;

namespace CCDInspection.Core.Models
{
    /// <summary>
    /// 位置点配置（用于辅助定位）
    /// </summary>
    public class PositionPoint
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("z")]
        public float Z { get; set; }

        [JsonProperty("zSpeed")]
        public float ZSpeed { get; set; } = 50f;
    }
}
