using Autofac;
using CCDInspection.Core.Interfaces;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core.Interfaces.Services;
using IVisionProcessor = CCDInspection.Core.Interfaces.Hardware.IVisionAnalyzer;
using CCDInspection.Core.Models;
using CCDInspection.Device.IO;
using CCDInspection.Device.Motion;
using CCDInspection.Device.Vision;
using CCDInspection.Services;
using CCDInspection.UI.Forms;
using IAlarmHandler = CCDInspection.Core.Interfaces.Services.IAlarmHandler;

namespace CCDInspection.UI
{
    /// <summary>
    /// Autofac DI 组合根
    /// </summary>
    public static class CompositionRoot
    {
        private static IContainer _container;

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // === 配置 ===
            var configService = new ConfigService();
            var appConfig = configService.Load();
            builder.RegisterInstance(configService).As<IConfigService>().As<ConfigService>().SingleInstance();
            builder.RegisterInstance(appConfig).As<AppConfig>().SingleInstance();

            // === 设备 ===
            builder.RegisterType<DeviceManager>().SingleInstance();

            builder.Register(ctx =>
            {
                var config = ctx.Resolve<AppConfig>();
                var mc = new ZmcController();
                ((IMotionController)mc).Connect(config.Axis.IpAddress);
                return mc;
            }).As<IMotionController>().SingleInstance();

            builder.RegisterType<VmVisionProcessor>()
                .As<IVisionProcessor>().SingleInstance();

            builder.Register(ctx =>
            {
                var mc = ctx.Resolve<IMotionController>();
                return new Cylinder(mc, IOMapping.OUT_Cylinder, IOMapping.IN_CylinderExtendOk, IOMapping.IN_CylinderRetractOk);
            }).As<ICylinder>().SingleInstance();

            builder.Register(ctx =>
            {
                var mc = ctx.Resolve<IMotionController>();
                var lc = new LightCurtain(mc);
                lc.StartMonitoring();
                return lc;
            }).As<ILightCurtain>().SingleInstance();

            // === 服务 ===
            builder.RegisterType<AlarmHandler>()
                .As<IAlarmHandler>().As<AlarmHandler>().SingleInstance();

            builder.RegisterType<StatisticsService>().As<StatisticsService>().SingleInstance();

            builder.RegisterType<StationController>()
                .As<IInspectionStation>().InstancePerDependency();

            // === UI Forms ===
            builder.RegisterType<FrmLogin>().PropertiesAutowired();
            builder.RegisterType<FrmMain>().PropertiesAutowired();
            builder.RegisterType<FrmSettings>().PropertiesAutowired();
            builder.RegisterType<FrmPermissionLogin>().PropertiesAutowired();

            _container = builder.Build();
            return _container;
        }

        public static T Resolve<T>() => _container.Resolve<T>();
    }
}
