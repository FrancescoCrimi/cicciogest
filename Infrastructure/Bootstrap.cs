using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
//using Castle.Services.Logging.Log4netIntegration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Infrastructure.Conf;
using System;

namespace CiccioGest.Infrastructure
{
    public static  class Bootstrap
    {
        private static ILogger logger;
        //public static IWindsorContainer Windsor { get; private set; }

        static Bootstrap()
        {
            Start();
        }

        public static void Restart(IConf conf)
        {
            StartWindsor();
            //Windsor.Register(Component.For<IConf>().Instance(conf));
            //logger.Debug("Manual start");
        }

        public static void Start()
        {
            StartWindsor();
            //IConf conf = ConfMgr.ReadConfiguration();
            //Windsor.Register(Component.For<IConf>().Instance(conf));
            //logger.Debug("Normal start");
        }

        private static void StartWindsor()
        {
            try
            {
                //if (Windsor != null) Windsor.Dispose();
                //Windsor = new WindsorContainer();
                ////Windsor.AddFacility<LoggingFacility>(f => f.LogUsing<Log4netFactory>().WithAppConfig());
                //Windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
                ////Windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithAppConfig());
                ////Windsor.AddFacility<WcfFacility>();
                //logger = Windsor.Resolve<ILoggerFactory>().Create("CiccioGest.Infrastructure.Bootstrap");
            }
            catch (Exception e)
            {
                throw new Exception("Start windsor error", e);
            }
        }
    }
}
