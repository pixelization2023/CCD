namespace CCDInspection.Core.Models
{
    /// <summary>
    /// 视觉分析结果
    /// </summary>
    public class VisionResult
    {
        public bool Success { get; set; }
        public bool Passed { get; set; }
        public string Reason { get; set; }
        public double CycleMs { get; set; }
    }
}
