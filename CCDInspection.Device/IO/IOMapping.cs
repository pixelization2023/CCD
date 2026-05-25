namespace CCDInspection.Device.IO
{
    /// <summary>
    /// IO 引脚集中映射（与 ZMC 控制器实际接线对应）
    /// </summary>
    public static class IOMapping
    {
        // === 输出引脚 ===
        public const int OUT_Cylinder = 0;      // 电磁阀
        public const int OUT_Light = 2;          // 光源 COM123
        public const int OUT_Light2 = 3;         // 光源 COM4
        public const int OUT_YellowLight = 5;    // 三色灯 黄
        public const int OUT_GreenLight = 6;     // 三色灯 绿
        public const int OUT_RedLight = 7;       // 三色灯 红
        public const int OUT_Buzzer = 8;         // 蜂鸣器

        // === 输入引脚 ===
        public const int IN_StartButton = 1;     // 启动按钮（单次）
        public const int IN_EmergencyStop = 2;   // 急停
        public const int IN_Reset = 3;           // 复位按钮
        public const int IN_CylinderExtendOk = 4;// 气缸伸出到位传感器
        public const int IN_CylinderRetractOk = 5;// 气缸缩回到位传感器
        public const int IN_LeftStart = 6;       // 左启动（双手安全）
        public const int IN_RightStart = 7;      // 右启动（双手安全）
        public const int IN_LightCurtain = 0;    // 安全光栅/门禁
    }
}
