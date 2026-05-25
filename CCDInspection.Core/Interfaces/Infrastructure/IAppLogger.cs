using System;

namespace CCDInspection.Core.Interfaces.Infrastructure
{
    /// <summary>
    /// 应用日志抽象
    /// </summary>
    public interface IAppLogger
    {
        void Debug(string message, params object[] args);
        void Info(string message, params object[] args);
        void Warn(string message, params object[] args);
        void Error(string message, params object[] args);
        void Error(Exception ex, string message, params object[] args);
    }
}
