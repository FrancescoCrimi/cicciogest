using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CiccioGest.Infrastructure.Conf
{
    sealed class ConfigurationElement : System.Configuration.ConfigurationElement, IConf
    {
        public UI UserInterface { get; set; }

        [ConfigurationProperty("data_access", DefaultValue = Storage.NHibernate)]
        public Storage DataAccess
        {
            get { return (Storage)this["data_access"]; }
            set { this["data_access"] = value; }
        }

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

        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "ssce")]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
    }
}
