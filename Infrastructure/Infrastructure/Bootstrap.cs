using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Infrastructure.Conf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Infrastructure
{
    public sealed class Bootstrap : IDisposable
    {
        private readonly ILogger logger;

        static Bootstrap()
        {
            Windsor = new WindsorContainer();
            new Bootstrap();
        }

        Bootstrap()
        {
            Windsor.AddFacility<LoggingFacility>(f => f.LogUsing<Log4netFactory>().WithAppConfig());
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithAppConfig());
            Windsor.AddFacility<WcfFacility>();

            IConf conf = readConfiguration();
            Windsor.Register(Component.For<IConf>().Instance(conf));

            logger = Windsor.Resolve<ILoggerFactory>().Create(this.GetType());
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " Created");
        }

        public static IWindsorContainer Windsor { get; private set; }

        private IConf readConfiguration()
        {
            try
            {
                ConfigurationSection cs = (ConfigurationSection)System.Configuration.ConfigurationManager.GetSection("CiccioGest");
                ConfigurationElement confa = cs.Configurazioni[cs.Configurazioni.Default];
                return confa;
            }
            catch (Exception ex)
            {
                throw new Exception("Orrore Configurazione", ex);
            }
        }

        private void writeConfiguration(IConf iConf)
        {
            //TODO: fix non deve funziare in modalità Web
            System.Configuration.Configuration configuration =
                System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

            ConfigurationSection cs = (ConfigurationSection)configuration.Sections["DddTest"];

            ConfigurationElement conf = (ConfigurationElement)cs.Configurazioni[cs.Configurazioni.Default];

            conf.DataAccess = iConf.DataAccess;
            conf.UserInterface = iConf.UserInterface;
            conf.CS = iConf.CS;
            conf.Database = iConf.Database;
            configuration.Save(System.Configuration.ConfigurationSaveMode.Minimal, false);
        }

        public void Dispose()
        {
            Windsor.Dispose();
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " Disposed");
        }
    }
}