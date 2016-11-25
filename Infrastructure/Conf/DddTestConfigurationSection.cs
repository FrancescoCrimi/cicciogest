using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Ciccio1.Infrastructure.Conf
{
    sealed class DddTestConfigurationSection : System.Configuration.ConfigurationSection
    {
        [ConfigurationProperty("Confs")]
        public DddTestConfigurationElementCollection Configurazioni
        {
            get
            {
                return (DddTestConfigurationElementCollection)this["Confs"];
            }
        }
    }
}
