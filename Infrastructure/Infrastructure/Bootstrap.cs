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
    public class Bootstrap : IDisposable
    {
        private static IWindsorContainer windsor = null;
        private ILogger logger = null;
        private IConf conf = null;

        #region Costruttori

        static Bootstrap()
        {
            windsor = new WindsorContainer();
            new Bootstrap();
        }

        Bootstrap()
        {
            conf = readConfiguration();
            startWindsor();
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " Created");
        }

        #endregion


        #region Proprietà pubbliche

        public static IWindsorContainer Windsor { get { return windsor; } }

        //public  static IWindsorContainer DesignWindsor
        //{
        //    get
        //    {
        //        var swsw = new WindsorContainer();
        //        swsw.AddFacility<LoggingFacility>();
        //        return swsw;
        //    }
        //}

        #endregion


        #region Metodi Privati

        private void startWindsor()
        {
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<Log4netFactory>().WithAppConfig());
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithAppConfig());
            windsor.AddFacility<WcfFacility>();

            windsor.Register(Component.For<IConf>().Instance(conf));
            logger = windsor.Resolve<ILogger>();
            logger.Debug(windsor.GetType().Name + ":" + windsor.GetHashCode().ToString() + " Created");
        }

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

        #endregion


        #region Metodi Pubblici

        //public void CreateDataAccess()
        //{
        //    windsor.Resolve<IDataAccess>().CreateDataAccess();
        //    writeConfiguration(conf);
        //}

        //public void VerifyDataAccess()
        //{
        //    windsor.Resolve<IDataAccess>().VerifyDataAccess();
        //    writeConfiguration(conf);
        //}

        public void Dispose()
        {
            windsor.Dispose();
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " Disposed");
        }

        #endregion
    }
}