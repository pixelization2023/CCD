using CCDInspection.Core.Interfaces;
using CCDInspection.Core.Models;
using CCDInspection.Core;

namespace CCDInspection.Services
{
    /// <summary>
    /// 生产统计服务
    /// </summary>
    public class StatisticsService
    {
        private readonly IConfigService _config;
        private ProductionStatistics _stats;

        public ProductionStatistics Current => _stats;

        public StatisticsService(IConfigService config)
        {
            _config = config;
            _stats = config.LoadStatistics();
        }

        public void RecordOK()
        {
            _stats.CurrentOkCount++;
            _stats.CurrentTotalCount++;
            _stats.TotalOkCount++;
            _stats.TotalCount++;

            LogService.Information("检测OK, 当前批次: {Ok}/{Total}", _stats.CurrentOkCount, _stats.CurrentTotalCount);
            SaveIfNeeded();
        }

        public void RecordNG(string reason)
        {
            _stats.CurrentNgCount++;
            _stats.CurrentTotalCount++;
            _stats.TotalNgCount++;
            _stats.TotalCount++;

            LogService.Warning("检测NG, 原因={Reason}, 当前批次: {Ng}/{Total}", reason, _stats.CurrentNgCount, _stats.CurrentTotalCount);
            SaveIfNeeded();
        }

        private int _saveCounter;
        private const int SaveInterval = 10; // 每10次检测才写一次磁盘
        private void SaveIfNeeded()
        {
            _saveCounter++;
            if (_saveCounter >= SaveInterval)
            {
                _config.SaveStatistics(_stats);
                _saveCounter = 0;
            }
        }

        public void ClearCurrent()
        {
            _stats.CurrentOkCount = 0;
            _stats.CurrentNgCount = 0;
            _stats.CurrentTotalCount = 0;
            _config.SaveStatistics(_stats);
            LogService.Information("当前批次计数已清零");
        }

        public void ClearAll()
        {
            _stats = new ProductionStatistics();
            _config.SaveStatistics(_stats);
            LogService.Information("全部计数已清零");
        }
    }
}
