using System.Collections.Generic;
using Newtonsoft.Json;

namespace CCDInspection.Core.Models
{
    /// <summary>
    /// 顶层应用配置，聚合所有子配置
    /// </summary>
    public class AppConfig
    {
        [JsonProperty("axis")]
        public AxisConfig Axis { get; set; } = new AxisConfig();
        [JsonProperty("products")]
        public List<ProductConfig> Products { get; set; } = new List<ProductConfig>();

        [JsonProperty("inspectionItems")]
        public List<InspectionItem> InspectionItems { get; set; } = new List<InspectionItem>();

        [JsonProperty("positions")]
        public List<PositionPoint> Positions { get; set; } = new List<PositionPoint>();

        [JsonProperty("inspection")]
        public InspectionSettings Inspection { get; set; } = new InspectionSettings();

        [JsonProperty("features")]
        public FeaturesConfig Features { get; set; } = new FeaturesConfig();
    }

    public class InspectionSettings
    {
        [JsonProperty("solDirectory")]
        public string SolDirectory { get; set; } = "VisionSol";

        [JsonProperty("imageSavePath")]
        public string ImageSavePath { get; set; } = @"D:\Images";

        [JsonProperty("saveOkImages")]
        public bool SaveOkImages { get; set; }

        [JsonProperty("saveNgImages")]
        public bool SaveNgImages { get; set; } = true;

        [JsonProperty("lightOnDelayMs")]
        public int LightOnDelayMs { get; set; } = 200;

        [JsonProperty("cylinderTimeoutMs")]
        public int CylinderTimeoutMs { get; set; } = 20000;

        [JsonProperty("detectZHeight")]
        public float DetectZHeight { get; set; } = 20f;
    }

    public class FeaturesConfig
    {
        [JsonProperty("shieldBuzzer")]
        public bool ShieldBuzzer { get; set; }

        [JsonProperty("shieldDoor")]
        public bool ShieldDoor { get; set; }

        [JsonProperty("shieldUpDown")]
        public bool ShieldUpDown { get; set; }

        [JsonProperty("updateStatusToUI")]
        public bool UpdateStatusToUI { get; set; } = true;

        [JsonProperty("saveOkImage")]
        public bool SaveOkImage { get; set; }

        [JsonProperty("saveNgImage")]
        public bool SaveNgImage { get; set; } = true;

        [JsonProperty("saveResultImage")]
        public bool SaveResultImage { get; set; } = true;

        [JsonProperty("fastMode")]
        public bool FastMode { get; set; }

        [JsonProperty("singleMachineTest")]
        public bool SingleMachineTest { get; set; }

        [JsonProperty("shieldCamera")]
        public bool ShieldCamera { get; set; }

        [JsonProperty("shieldLightCurtain")]
        public bool ShieldLightCurtain { get; set; }

        [JsonProperty("shieldCylinder")]
        public bool ShieldCylinder { get; set; }
    }
}
