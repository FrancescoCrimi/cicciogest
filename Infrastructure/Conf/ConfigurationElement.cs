using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Ciccio1.Infrastructure.Conf
{
    sealed class DddTestConfigurationElement : ConfigurationElement, IConf
    {
        [ConfigurationProperty("user_interface", DefaultValue = UI.Form)]
        public UI UserInterface
        {
            get { return (UI)this["user_interface"]; }
            set { this["user_interface"] = value; }
        }

        [ConfigurationProperty("data_access", DefaultValue = Storage.NHibernate)]
        public Storage DataAccess
        {
            get { return (Storage)this["data_access"]; }
            set { this["data_access"] = value; }
        }

        [ConfigurationProperty("data_access_config")]
        public DataAccessConfigurationElement DataAccessConfig
        {
            get { return (DataAccessConfigurationElement)this["data_access_config"]; }
            set { this["data_access_config"] = value; }
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "ssce")]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }



        UI IConf.UserInterface { get { return UserInterface; } }
        Storage IConf.DataAccess { get { return DataAccess; } }
        Databases IConf.Database { get { return DataAccessConfig.Database; } }
        string IConf.ConnectionString { get { return DataAccessConfig.CS; } }
        string IConf.Name { get { return Name; } }
    }
}
