using CiccioGest.Domain.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Utils
{
    public class MyDataContractSurrogate : IDataContractSurrogate
    {
        public MyDataContractSurrogate()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Prodotto, Prodotto>();
                cfg.CreateMap<Categoria, Categoria>();
            });
        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }

        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }

        public Type GetDataContractType(Type type)
        {
            // Changes the IList<T> to List<T>
            if (type.IsGenericType && !type.IsGenericTypeDefinition
                && type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                return typeof(List<>).MakeGenericType(type.GetGenericArguments()[0]);
            }
            return type;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            return obj;
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if(obj.GetType().Name == targetType.Name + "Proxy")
            {
                var aswq = AutoMapper.Mapper.Map(obj, typeof(object), targetType);
                return aswq;
            }
            return obj;
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return null;
        }
    }
}
