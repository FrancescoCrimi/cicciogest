using System.Configuration;

namespace CiccioGest.Infrastructure.Conf
{
    sealed class ConfigurationSection : System.Configuration.ConfigurationSection
    {
        [ConfigurationProperty("Confs")]
        public ConfigurationElementCollection Configurazioni
        {
            get
            {
                return (ConfigurationElementCollection)this["Confs"];
            }
        }
    }
}
