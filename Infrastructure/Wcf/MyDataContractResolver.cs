using NHibernate.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CiccioGest.Infrastructure.Wcf
{
    public class MyDataContractResolver : DataContractResolver
    {
        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            return declaredType;
        }

        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            if (typeof(INHibernateProxy).IsAssignableFrom(type))
                return knownTypeResolver.TryResolveType(declaredType, declaredType, null, out typeName, out typeNamespace);
            if (typeof(NHibernate.Proxy.DynamicProxy.ProxyObjectReference).IsAssignableFrom(type))
                return knownTypeResolver.TryResolveType(declaredType.BaseType, declaredType.BaseType, null, out typeName, out typeNamespace);
            //return knownTypeResolver.TryResolveType(type, declaredType, null, out typeName, out typeNamespace);
            var dic = new XmlDictionary();
            typeName = dic.Add("Categoria");
            typeNamespace = dic.Add("http://ciccio.it");
            return true;
        }
    }
}
