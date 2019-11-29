using CiccioGest.Infrastructure.Conf;
using System;

namespace CiccioGest.Infrastructure
{
    public static class Bootstrap
    {
        static Bootstrap()
        {
            Start();
        }

        public static void Restart(IConf conf)
        {
        }

        public static void Start()
        {
        }

        //Windsor.AddFacility<LoggingFacility>(f => f.LogUsing<Log4netFactory>().WithAppConfig());
        //Windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
        //Windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithAppConfig());
    }
}
