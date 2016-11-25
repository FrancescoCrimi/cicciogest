using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Ciccio1.Infrastructure.Conf
{
    [ConfigurationCollection(typeof(DddTestConfigurationElement), AddItemName = "Conf", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    sealed class DddTestConfigurationElementCollection : ConfigurationElementCollection
    {
        public void Add(DddTestConfigurationElement element)
        {
            BaseAdd(element);
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new DddTestConfigurationElement();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((DddTestConfigurationElement)element).Name;
        }

        public DddTestConfigurationElement this[int index]
        {
            get { return base.BaseGet(index) as DddTestConfigurationElement; }
        }

        public new DddTestConfigurationElement this[string key]
        {
            get { return base.BaseGet(key) as DddTestConfigurationElement; }
        }

        [System.Configuration.ConfigurationProperty("default", DefaultValue = "Cazzo")]
        public string Default
        {
            get { return (string)base["default"]; }
            set { base["default"] = value; }
        }
    }
}
