using System;
using System.IO;
using CCDInspection.Core.Interfaces;
using CCDInspection.Core.Models;
using Newtonsoft.Json;
using CCDInspection.Core;

namespace CCDInspection.Services
{
    /// <summary>
    /// JSON 配置读写服务（使用相对路径）
    /// </summary>
    public class ConfigService : IConfigService
    {
        private static readonly string ConfigRoot =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");

        private readonly string _configDir;
        private readonly string _mainConfigPath;
        private readonly string _statisticsPath;

        public ConfigService(string configDir = null)
        {
            _configDir = configDir ?? ConfigRoot;
            _mainConfigPath = Path.Combine(_configDir, "appsettings.json");
            _statisticsPath = Path.Combine(_configDir, "statistics.json");

            if (!Directory.Exists(_configDir))
                Directory.CreateDirectory(_configDir);
        }

        public AppConfig Load()
        {
            try
            {
                if (File.Exists(_mainConfigPath))
                {
                    var json = File.ReadAllText(_mainConfigPath);
                    var config = JsonConvert.DeserializeObject<AppConfig>(json);
                    LogService.Debug("配置加载成功: {Path}", _mainConfigPath);
                    return config ?? CreateDefault();
                }
            }
            catch (Exception ex)
            {
                LogService.Error(ex, "配置加载失败，使用默认配置");
            }

            LogService.Information("配置文件不存在，创建默认配置: {Path}", _mainConfigPath);
            var defaultConfig = CreateDefault();
            Save(defaultConfig);
            return defaultConfig;
        }

        public void Save(AppConfig config)
        {
            try
            {
                if (!Directory.Exists(_configDir)) Directory.CreateDirectory(_configDir);
                var json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(_mainConfigPath, json);
                LogService.Information("配置保存成功: {Path}", _mainConfigPath);
            }
            catch (Exception ex)
            {
                LogService.Error(ex, "配置保存失败");
            }
        }

        public ProductionStatistics LoadStatistics()
        {
            try
            {
                if (File.Exists(_statisticsPath))
                {
                    var json = File.ReadAllText(_statisticsPath);
                    return JsonConvert.DeserializeObject<ProductionStatistics>(json)
                        ?? new ProductionStatistics();
                }
            }
            catch (Exception ex)
            {
                LogService.Error(ex, "统计数据加载失败");
            }
            return new ProductionStatistics();
        }

        public void SaveStatistics(ProductionStatistics stats)
        {
            try
            {
                var json = JsonConvert.SerializeObject(stats, Formatting.Indented);
                File.WriteAllText(_statisticsPath, json);
            }
            catch (Exception ex)
            {
                LogService.Error(ex, "统计数据保存失败");
            }
        }

        private AppConfig CreateDefault()
        {
            return new AppConfig
            {
                Axis = new AxisConfig(),
                Inspection = new InspectionSettings()
            };
        }
    }
}
