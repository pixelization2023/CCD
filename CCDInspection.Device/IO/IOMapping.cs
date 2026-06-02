namespace CCDInspection.Device.IO
{
    /// <summary>
    /// IO 引脚集中映射
    /// in0=门禁 in1=设备启动 in2=急停 in3=复位 in4=伸出到位 in5=缩回到位 in6=保留 in7=流程启动 in8=停止
    /// </summary>
    public static class IOMapping
    {
        // === 输出引脚 ===
        public const int OUT_CylinderOUT = 1;      // 电磁阀A
        public const int OUT_CylinderIN = 0;      // 电磁阀B
        public const int OUT_Light = 2;          // 光源 COM123
        public const int OUT_Light2 = 3;         // 光源 COM4
        public const int OUT_YellowLight = 5;    // 三色灯 黄
        public const int OUT_GreenLight = 6;     // 三色灯 绿
        public const int OUT_RedLight = 7;       // 三色灯 红
        public const int OUT_Buzzer = 8;         // 蜂鸣器

        // === 输入引脚 ===
        public const int IN_LightCurtain = 0;    // 门禁/安全光栅（常闭）
        public const int IN_MachineStart = 1;    // 设备启动（进入AutoRun模式）
        public const int IN_EmergencyStop = 2;   // 急停（常闭）
        public const int IN_Reset = 3;           // 复位
        public const int IN_CylinderExtendOk = 4;// 气缸伸出到位
        public const int IN_CylinderRetractOk = 5;// 气缸缩回到位
        public const int IN_FlowStart = 7;       // 流程启动（触发单次检测）
        public const int IN_Stop = 8;            // 停止（中断流程）
        
    }
}
