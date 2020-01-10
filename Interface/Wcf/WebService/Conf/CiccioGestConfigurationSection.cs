using System.Configuration;

namespace CiccioGest.Interface.Wcf.WebService.Conf
{
    sealed class CiccioGestConfigurationSection : System.Configuration.ConfigurationSection
    {
        [ConfigurationProperty("Confs")]
        public CiccioGestConfigurationElementCollection Configurazioni
        {
            get
            {
                return (CiccioGestConfigurationElementCollection)this["Confs"];
            }
        }
    }
}
