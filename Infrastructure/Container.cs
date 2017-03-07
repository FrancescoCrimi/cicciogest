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

        public Container(UI ui)
        {
            conf = readConfiguration(ui);
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

            // Aggiungi Facility TypeFactory
            //windsor.AddFacility<TypedFactoryFacility>();

            // Aggiungi Facility logging con Log4Net
            //windsor.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithAppConfig());
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());

            // Aggiungi Facility logging con NLog
            //windsor.AddFacility<LoggingFacility>(f => f.UseNLog().WithConfig("NLog.config"));
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.NLog).WithConfig("NLog.config"));
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.NLog).WithAppConfig());

            // Aggiungi WcfFacility
            windsor.AddFacility<WcfFacility>();

            windsor.Register(Component.For<IConf>().Instance(conf));
            logger = windsor.Resolve<ILogger>();
            logger.Debug("Container Avviato");
        }

        private IConf readConfiguration(UI ui)
        {
            //IConf conf = null;
            try
            {
                ConfigurationSection cs = (ConfigurationSection)System.Configuration.ConfigurationManager.GetSection("CiccioGest");
                ConfigurationElement confa = cs.Configurazioni[cs.Configurazioni.Default];
                confa.UserInterface = ui;
                return confa;
            }
            catch (Exception ex)
            {
                throw new Exception("Orrore Configurazione", ex);
            }
            //return conf;
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