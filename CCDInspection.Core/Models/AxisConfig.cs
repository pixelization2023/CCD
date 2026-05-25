using Newtonsoft.Json;

namespace CCDInspection.Core.Models
{
    /// <summary>
    /// Z轴运动参数配置
    /// </summary>
    public class AxisConfig
    {
        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; } = "192.168.0.11";

        [JsonProperty("pulseEquivalent")]
        public float PulseEquivalent { get; set; } = 10000f;

        [JsonProperty("autoSpeed")]
        public float AutoSpeed { get; set; } = 20f;

        [JsonProperty("acceleration")]
        public float Acceleration { get; set; } = 20f;

        [JsonProperty("deceleration")]
        public float Deceleration { get; set; } = 20f;

        [JsonProperty("positiveSoftLimit")]
        public float PositiveSoftLimit { get; set; } = 200000000f;

        [JsonProperty("negativeSoftLimit")]
        public float NegativeSoftLimit { get; set; } = -200000000f;

        [JsonProperty("manualSpeed")]
        public float ManualSpeed { get; set; } = 20f;

        [JsonProperty("manualDistance")]
        public float ManualDistance { get; set; } = 5f;

        [JsonProperty("homeModel")]
        public int HomeModel { get; set; } = 14;

        [JsonProperty("homeSpeed")]
        public float HomeSpeed { get; set; } = 50f;

        [JsonProperty("creepSpeed")]
        public float CreepSpeed { get; set; } = 20f;

        [JsonProperty("originIo")]
        public int OriginIo { get; set; } = 130;

        [JsonProperty("posLimitIo")]
        public int PosLimitIo { get; set; } = 129;

        [JsonProperty("negLimitIo")]
        public int NegLimitIo { get; set; } = 128;

        [JsonProperty("alarmIo")]
        public int AlarmIo { get; set; } = -1;

        [JsonProperty("sramp")]
        public float Sramp { get; set; } = 5f;

        [JsonProperty("fastDec")]
        public float FastDec { get; set; } = 10000f;

        [JsonProperty("aType")]
        public int AType { get; set; } = 65;
    }
}
