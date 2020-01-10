using System.Configuration;

namespace CiccioGest.Interface.Wcf.AppService.Conf
{
    [ConfigurationCollection(typeof(CiccioGestConfigurationElement), AddItemName = "Conf", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    sealed class CiccioGestConfigurationElementCollection : ConfigurationElementCollection
    {
        public void Add(CiccioGestConfigurationElement element)
        {
            BaseAdd(element);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CiccioGestConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CiccioGestConfigurationElement)element).Name;
        }

        public CiccioGestConfigurationElement this[int index]
        {
            get { return BaseGet(index) as CiccioGestConfigurationElement; }
        }

        public new CiccioGestConfigurationElement this[string key]
        {
            get { return BaseGet(key) as CiccioGestConfigurationElement; }
        }

        [ConfigurationProperty("default", DefaultValue = "Cazzo")]
        public string Default
        {
            get { return (string)base["default"]; }
            set { base["default"] = value; }
        }
    }
}
