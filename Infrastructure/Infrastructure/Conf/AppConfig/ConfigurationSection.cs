using System.Configuration;

namespace CiccioGest.Infrastructure.Conf.AppConfig
{
    sealed class ConfigurationSection : System.Configuration.ConfigurationSection
    {
        [ConfigurationProperty("Confs")]
        public AppConfs Configurazioni
        {
            get
            {
                return (AppConfs)this["Confs"];
            }
        }
    }
}
