using CiccioGest.Infrastructure.Conf;
using System;
using System.Configuration;

namespace CiccioGest.Interface.Wcf.WebService.Conf
{
    public class ConfMgr
    {
        public static IAppConf ReadConfiguration()
        {
            try
            {
                CiccioGestConfigurationSection cs = 
                    (CiccioGestConfigurationSection)System.Configuration.ConfigurationManager.GetSection("CiccioGest");
                CiccioGestConfigurationElement confa = cs.Configurazioni[cs.Configurazioni.Default];
                return confa;
            }
            catch (Exception ex)
            {
                throw new Exception("Read configuration error", ex);
            }
        }

        public static void WriteConfiguration(IAppConf iConf)
        {
            //TODO: fix non deve funziare in modalità Web
            Configuration configuration =
                System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            CiccioGestConfigurationSection cs = (CiccioGestConfigurationSection)configuration.Sections["CiccioGest"];

            CiccioGestConfigurationElement conf = cs.Configurazioni[cs.Configurazioni.Default];

            conf.DataAccess = iConf.DataAccess;
            conf.UserInterface = iConf.UserInterface;
            conf.CS = iConf.CS;
            conf.Database = iConf.Database;
            configuration.Save(ConfigurationSaveMode.Minimal, false);
        }
    }
}
