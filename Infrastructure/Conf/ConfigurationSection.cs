using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Ciccio1.Infrastructure.Conf
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
