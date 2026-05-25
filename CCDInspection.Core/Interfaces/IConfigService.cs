using CCDInspection.Core.Models;

namespace CCDInspection.Core.Interfaces
{
    /// <summary>
    /// 配置读写接口
    /// </summary>
    public interface IConfigService
    {
        /// <summary>
        /// 加载应用配
        /// </summary>
        /// <returns></returns>
        AppConfig Load();
        /// <summary>
        /// 保存应用配置
        /// </summary>
        /// <param name="config"></param>
        void Save(AppConfig config);
        /// <summary>
        /// 加载生产统计数据
        /// </summary>
        /// <returns></returns>
        ProductionStatistics LoadStatistics();
        /// <summary>
        /// 保存生产统计数据
        /// </summary>
        /// <param name="stats"></param>
        void SaveStatistics(ProductionStatistics stats);
    }
}
