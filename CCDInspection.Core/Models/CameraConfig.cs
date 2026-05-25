using Newtonsoft.Json;
using CCDInspection.Core.Enums;

namespace CCDInspection.Core.Models
{
    /// <summary>
    /// 相机参数配置
    /// </summary>
    public class CameraConfig
    {
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("triggerMode")]
        public TriggerMode TriggerMode { get; set; } = TriggerMode.Software;

        [JsonProperty("exposureTime")]
        public int ExposureTime { get; set; } = 5000;

        [JsonProperty("gain")]
        public int Gain { get; set; }

        [JsonProperty("timeout")]
        public int Timeout { get; set; } = 5000;
    }
}
