using System;

namespace CCDInspection.Core.Models
{
    public class InspectionRecordEntity
    {
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public string ProductModel { get; set; }
        public string ProductPort { get; set; }
        public string ProductColor { get; set; }
        public string ProductCode { get; set; }
        public string Result { get; set; }
        public string NgReason { get; set; }
    }
}
