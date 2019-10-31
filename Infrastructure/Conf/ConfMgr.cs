using System;
using System.Configuration;

namespace CiccioGest.Infrastructure.Conf
{
    public class ConfMgr
    {
        public static IConf ReadConfiguration()
        {
            try
            {
                ConfigurationSection cs = (ConfigurationSection)ConfigurationManager.GetSection("CiccioGest");
                ConfigurationElement confa = cs.Configurazioni[cs.Configurazioni.Default];
                return confa;
            }
            catch (Exception ex)
            {
                throw new CiccioGestConfigurationException("Read configuration error", ex);
            }
        }

        public static void WriteConfiguration(IConf iConf)
        {
            //TODO: fix non deve funziare in modalità Web
            Configuration configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConfigurationSection cs = (ConfigurationSection)configuration.Sections["CiccioGest"];

            ConfigurationElement conf = cs.Configurazioni[cs.Configurazioni.Default];

            conf.DataAccess = iConf.DataAccess;
            conf.UserInterface = iConf.UserInterface;
            conf.CS = iConf.CS;
            conf.Database = iConf.Database;
            configuration.Save(ConfigurationSaveMode.Minimal, false);
        }
    }
}
