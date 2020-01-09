using CiccioGest.Infrastructure.Conf.AppConfig;
using System;
//using System.Configuration;

namespace CiccioGest.Infrastructure.Conf
{
    public class ConfigurationManager
    {
        public static IAppConf ReadConfiguration()
        {
            try
            {
                ConfigurationSection cs = (ConfigurationSection)System.Configuration.ConfigurationManager.GetSection("CiccioGest");
                AppConfig.AppConf confa = cs.Configurazioni[cs.Configurazioni.Default];
                return confa;
            }
            catch (Exception ex)
            {
                throw new CiccioGestConfigurationException("Read configuration error", ex);
            }
        }

        public static void WriteConfiguration(IAppConf iConf)
        {
            //TODO: fix non deve funziare in modalità Web
            System.Configuration.Configuration configuration =
                System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

            ConfigurationSection cs = (ConfigurationSection)configuration.Sections["CiccioGest"];

            AppConfig.AppConf conf = cs.Configurazioni[cs.Configurazioni.Default];

            conf.DataAccess = iConf.DataAccess;
            conf.UserInterface = iConf.UserInterface;
            conf.CS = iConf.CS;
            conf.Database = iConf.Database;
            configuration.Save(System.Configuration.ConfigurationSaveMode.Minimal, false);
        }
    }
}
