using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Models;

namespace CCDInspection.Core.Interfaces.Hardware
{
    /// <summary>
    /// 单轴控制接口 — 封装 ZMC 运动控制器的单轴操作
    /// </summary>
    public interface IAxis
    {
        /// <summary>轴索引号（控制器轴号）</summary>
        int Index { get; }
        /// <summary>当前指令位置（DPOS）</summary>
        float CurrentPosition { get; }
        /// <summary>轴是否正在运动</summary>
        bool IsMoving { get; }

        /// <summary>绝对定位运动到目标位置</summary>
        Task<bool> MoveAbs(float position, float? speed = null);
        /// <summary>相对移动指定距离</summary>
        Task<bool> MoveRel(float distance, float? speed = null);
        /// <summary>执行回零操作</summary>
        Task<bool> Home(AxisConfig config);
        /// <summary>点动（持续运动），direction: 1=正向 -1=负向</summary>
        void Jog(int direction, float speed);
        /// <summary>停止当前运动</summary>
        void Stop();
        /// <summary>使能轴</summary>
        bool Enable();
        /// <summary>去使能轴</summary>
        bool Disable();
        /// <summary>清除轴报警（停止原因+重新使能）</summary>
        void ClearAlarm();

        /// <summary>
        /// 测试回原
        /// </summary>
        /// <param name="axisConfig"></param>
        void TestHom(AxisConfig axisConfig);

    }
}
