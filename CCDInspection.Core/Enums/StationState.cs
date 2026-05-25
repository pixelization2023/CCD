namespace CCDInspection.Core.Enums
{
    /// <summary>
    /// 工位顶层状态
    /// </summary>
    public enum StationState
    {
        /// <summary>
        /// 空闲：等待启动，所有设备处于初始状态
        /// </summary>
        Idle,        // 空闲，等待启动
        /// <summary>
        /// 自动检测中：正在执行自动检测流程，设备根据流程步骤自动动作
        /// </summary>
        AutoRun,     // 自动检测运行中
        /// <summary>
        /// 暂停：自动检测流程暂停，设备保持当前状态不动，等待继续或停止指令
        /// </summary>
        Paused,      // 暂停
        /// <summary>
        /// 报警：发生异常需要人工干预，所有设备急停，等待复位指令
        /// </summary>
        Alarm,       // 报警（急停所有动作）
        /// <summary>
        /// 复位中：正在执行复位流程，清除报警 → 气缸缩回 → 轴回零 → 空闲
        /// </summary>
        Resetting    // 复位中
    }
}
