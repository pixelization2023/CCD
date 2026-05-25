using Newtonsoft.Json;

namespace CCDInspection.Core.Models
{
    /// <summary>
    /// 产品配置
    /// </summary>
    public class ProductConfig
    {
        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("zHeight")]
        public float ZHeight { get; set; }

        [JsonProperty("solPath")]
        public string SolPath { get; set; }
    }
}
