using System;
using Serilog;
using Serilog.Events;

namespace CCDInspection.Core
{
    /// <summary>
    /// 统一日志服务 — 所有日志经此写入 Serilog
    /// </summary>
    public static class LogService
    {
        private static bool _initialized;

        public static void Init(string logDir)
        {
            if (_initialized) return;

            if (!System.IO.Directory.Exists(logDir))
                System.IO.Directory.CreateDirectory(logDir);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(System.IO.Path.Combine(logDir, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    outputTemplate: "{Timestamp:HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(System.IO.Path.Combine(logDir, "error-.txt"),
                    restrictedToMinimumLevel: LogEventLevel.Error,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            _initialized = true;
            Information("====== 软件启动 | 日志目录: {Dir} ======", logDir);
        }

        public static void Debug(string message, params object[] args) => Log.Debug(message, args);
        public static void Information(string message, params object[] args) => Log.Information(message, args);
        public static void Warning(string message, params object[] args) => Log.Warning(message, args);
        public static void Error(string message, params object[] args) => Log.Error(message, args);
        public static void Error(Exception ex, string message, params object[] args) => Log.Error(ex, message, args);
        public static void Fatal(Exception ex, string message, params object[] args) => Log.Fatal(ex, message, args);

        public static void Shutdown()
        {
            Information("====== 软件退出 ======");
            Log.CloseAndFlush();
        }
    }
}
