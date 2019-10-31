using System.Configuration;

namespace CiccioGest.Infrastructure.Conf
{
    [ConfigurationCollection(typeof(ConfigurationElement), AddItemName = "Conf", CollectionType = System.Configuration.ConfigurationElementCollectionType.BasicMap)]
    sealed class ConfigurationElementCollection : System.Configuration.ConfigurationElementCollection
    {
        public void Add(ConfigurationElement element)
        {
            BaseAdd(element);
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new ConfigurationElement();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((ConfigurationElement)element).Name;
        }

        public ConfigurationElement this[int index]
        {
            get { return BaseGet(index) as ConfigurationElement; }
        }

        public new ConfigurationElement this[string key]
        {
            get { return BaseGet(key) as ConfigurationElement; }
        }

        [ConfigurationProperty("default", DefaultValue = "Cazzo")]
        public string Default
        {
            get { return (string)base["default"]; }
            set { base["default"] = value; }
        }
    }
}
