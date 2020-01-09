using System;
using System.Configuration;

namespace CiccioGest.Infrastructure.Conf.AppConfig
{
    sealed class AppConf : System.Configuration.ConfigurationElement, IAppConf
    {

        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "ssee")]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }


        //public UI UserInterface { get; set; }
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


        [ConfigurationProperty("database", DefaultValue = Databases.SSEE)]
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
