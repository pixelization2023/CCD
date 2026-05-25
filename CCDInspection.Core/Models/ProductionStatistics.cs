using Newtonsoft.Json;

namespace CCDInspection.Core.Models
{
    /// <summary>
    /// 生产统计数据
    /// </summary>
    public class ProductionStatistics
    {
        [JsonProperty("currentOkCount")]
        public int CurrentOkCount { get; set; }

        [JsonProperty("currentNgCount")]
        public int CurrentNgCount { get; set; }

        [JsonProperty("currentTotalCount")]
        public int CurrentTotalCount { get; set; }

        [JsonProperty("totalOkCount")]
        public uint TotalOkCount { get; set; }

        [JsonProperty("totalNgCount")]
        public uint TotalNgCount { get; set; }

        [JsonProperty("totalCount")]
        public uint TotalCount { get; set; }

        public double CurrentOkYield =>
            CurrentTotalCount > 0 ? (double)CurrentOkCount / CurrentTotalCount * 100 : 0;

        public double CurrentNgYield =>
            CurrentTotalCount > 0 ? (double)CurrentNgCount / CurrentTotalCount * 100 : 0;

        public double TotalOkYield =>
            TotalCount > 0 ? (double)TotalOkCount / TotalCount * 100 : 0;

        public double TotalNgYield =>
            TotalCount > 0 ? (double)TotalNgCount / TotalCount * 100 : 0;
    }
}
