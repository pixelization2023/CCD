namespace CCDInspection.Core.Enums
{
    /// <summary>
    /// 检测流程子状态
    /// </summary>
    public enum InspectionFlowState
    {
        /// <summary>
        /// 初始状态，等待启动信号。此时工位状态为 StationState.Idle，直到接收到启动信号后才进入 CylinderExtend 状态。
        /// </summary>
        Init,
        WaitStart,          // 等待启动信号
        /// <summary>
        /// 气缸伸出状态：接收到启动信号后，工位状态变为 StationState.Running，进入 CylinderExtend 状态。此时会控制气缸伸出，并等待伸出到位传感器反馈确认气缸已完全伸出。
        /// </summary>
        CylinderExtend,     // 气缸伸出
        /// <summary>
        /// 光源开启状态：气缸伸出到位后，进入 LightOn 状态。此时会控制光源开启，为拍照和视觉处理提供足够的照明。
        /// </summary>
        LightOn,            // 光源开启
        /// <summary>
        /// Z轴移动状态：光源开启后，进入 ZAxisMove 状态。此时会控制 Z 轴移动到预设的检测高度，确保相机对准被检测物体进行拍照和视觉处理。
        /// </summary>
        ZAxisMove,          // Z轴移动到检测高度
        /// <summary>
        /// 视觉处理状态：VM方案内部触发相机拍照+算法分析，输出OK/NG结果
        /// </summary>
        VisionProcess,      // 视觉处理（含拍照）
        /// <summary>
        /// 保存结果状态：视觉处理完成后，进入 SaveResult 状态。此时会将检测结果保存到数据库或文件系统中，并准备进行下一步的流程操作（如光源关闭、Z轴复位等）。
        /// </summary>
        SaveResult,         // 保存结果
        /// <summary>
        /// 光源关闭状态：结果保存完成后，进入 LightOff 状态。此时会控制光源关闭，节省能源并减少设备磨损。完成后会继续进行 Z 轴复位和气缸缩回等后续操作，最终回到等待启动的初始状态。
        /// </summary>
        LightOff,           // 光源关闭
        /// <summary>
        /// Z轴复位状态：光源关闭后，进入 ZAxisReturn 状态。此时会控制 Z 轴返回到初始位置，为下一次检测做好准备。完成后会继续进行气缸缩回等后续操作，最终回到等待启动的初始状态。
        /// </summary>
        ZAxisReturn,        // Z轴复位
        /// <summary>
        /// 气缸缩回状态：Z轴复位后，进入 CylinderRetract 状态。此时会控制气缸缩回到初始位置，为下一次检测做好准备。完成后会回到等待启动的初始状态，等待下一次检测流程的启动信号。
        /// </summary>
        CylinderRetract,    // 气缸缩回
        /// <summary>
        /// 完成状态：整个检测流程完成后，进入 Completed 状态。此时工位状态会回到 StationState.Idle，等待下一次检测流程的启动信号。此状态主要用于标识一次完整的检测流程已经结束，可以进行结果统计、日志记录等后续操作。
        /// </summary>
        Completed           // 完成
    }
}
