using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Ciccio1.Infrastructure.Conf
{
    sealed class DataAccessConfigurationElement : System.Configuration.ConfigurationElement
    {
        [ConfigurationProperty("database", DefaultValue = Databases.SSCE)]
        public Databases Database
        {
            get { return (Databases)this["database"]; }
            set { this["database"] = value; }
        }

        [ConfigurationProperty("cs", DefaultValue = "Data Source=DddTest.sdf")]
        public String CS
        {
            get { return (String)this["cs"]; }
            set { this["cs"] = value; }
        }
    }
}
