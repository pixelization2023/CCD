using System;
using System.Drawing;

namespace CCDInspection.Core.Models
{
    /// <summary>
    /// 图像采集结果
    /// </summary>
    public class ImageCaptureResult
    {
        public bool Success { get; set; }
        public Bitmap Image { get; set; }
        public string Error { get; set; }
        public DateTime CapturedAt { get; set; } = DateTime.Now;
    }
}
