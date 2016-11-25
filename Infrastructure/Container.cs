using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.Facilities.WcfIntegration;
using Ciccio1.Infrastructure.Conf;
using Castle.Facilities.TypedFactory;

namespace Ciccio1.Infrastructure
{
    public class Container : IDisposable
    {
        private IWindsorContainer windsor = null;
        private ILogger logger = null;
        private IConf conf = null;

        #region Costruttori

        public Container()
        {
            conf = readConfiguration();
            startWindsor();
        }

        public Container(IConf iConf)
        {
            conf = iConf;
            startWindsor();
        }

        #endregion


        #region Metodi Privati

        private void startWindsor()
        {
            windsor = new WindsorContainer();
            windsor.AddFacility<TypedFactoryFacility>();
            //windsor.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithAppConfig());
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());
            //windsor.AddFacility<LoggingFacility>(f => f.UseNLog().WithConfig("NLog.config"));
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.NLog).WithConfig("NLog.config"));
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.NLog).WithAppConfig());
            windsor.AddFacility<WcfFacility>();
            windsor.Register(Component.For<IConf>().Instance(conf));
            logger = windsor.Resolve<ILogger>();
            logger.Debug("Container Avviato");
        }

        private IConf readConfiguration()
        {
            IConf conf = null;
            try
            {
                DddTestConfigurationSection cs = (DddTestConfigurationSection)System.Configuration.ConfigurationManager.GetSection("DddTest");
                conf = (IConf)cs.Configurazioni[cs.Configurazioni.Default];
            }
            catch (Exception ex)
            {
                throw new Exception("Orrore Configurazione", ex);
            }
            return conf;
        }

        private void writeConfiguration(IConf iConf)
        {
            //TODO: fix non deve funziare in modalità Web
            System.Configuration.Configuration configuration =
                System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

            DddTestConfigurationSection cs = (DddTestConfigurationSection)configuration.Sections["DddTest"];

            DddTestConfigurationElement conf = (DddTestConfigurationElement)cs.Configurazioni[cs.Configurazioni.Default];

            conf.DataAccess = iConf.DataAccess;
            conf.UserInterface = iConf.UserInterface;
            conf.DataAccessConfig.CS = iConf.ConnectionString;
            conf.DataAccessConfig.Database = iConf.Database;
            configuration.Save(System.Configuration.ConfigurationSaveMode.Minimal, false);
        }

        #endregion


        #region Metodi Pubblici

        public void Install(params IWindsorInstaller[] installers)
        {
            windsor.Install(installers);
        }

        public T Resolve<T>()
        {
            return windsor.Resolve<T>();
        }

        public void Release(object instance)
        {
            windsor.Release(instance);
        }

        public void CreateDataAccess()
        {
            windsor.Resolve<IDataAccess>().CreateDataAccess();
            writeConfiguration(conf);
        }

        public void VerifyDataAccess()
        {
            windsor.Resolve<IDataAccess>().VerifyDataAccess();
            writeConfiguration(conf);
        }

        #endregion


        public IWindsorContainer Windsor { get { return windsor; } }

        public void Dispose()
        {
            windsor.Dispose();
        }
    }
}