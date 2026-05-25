using System;

namespace CCDInspection.Core.Interfaces.Services
{
    /// <summary>
    /// 报警处理接口 — 触发和清除设备报警
    /// </summary>
    public interface IAlarmHandler
    {
        /// <summary>当前是否处于报警状态</summary>
        bool IsAlarming { get; }

        /// <summary>触发报警（报警码, 报警消息）</summary>
        void RaiseAlarm(string code, string message);
        /// <summary>清除当前报警</summary>
        void ClearAlarm();

        /// <summary>报警触发事件（报警码, 报警消息）</summary>
        event Action<string, string> OnAlarm;
        /// <summary>报警清除事件</summary>
        event Action OnAlarmCleared;
    }
}
