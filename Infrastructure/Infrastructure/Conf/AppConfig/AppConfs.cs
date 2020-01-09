using System.Configuration;

namespace CiccioGest.Infrastructure.Conf.AppConfig
{
    [ConfigurationCollection(typeof(AppConf), AddItemName = "Conf", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    sealed class AppConfs : ConfigurationElementCollection
    {
        public void Add(AppConf element)
        {
            BaseAdd(element);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new AppConf();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AppConf)element).Name;
        }

        public AppConf this[int index]
        {
            get { return BaseGet(index) as AppConf; }
        }

        public new AppConf this[string key]
        {
            get { return BaseGet(key) as AppConf; }
        }

        [ConfigurationProperty("default", DefaultValue = "Cazzo")]
        public string Default
        {
            get { return (string)base["default"]; }
            set { base["default"] = value; }
        }
    }
}
