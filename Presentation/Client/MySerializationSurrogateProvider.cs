using CiccioSoft.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CiccioGest.Presentation.Client
{
    public class MySerializationSurrogateProvider : ISerializationSurrogateProvider
    {
        public object GetDeserializedObject(object obj, Type targetType)
        {
            return obj;
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            return obj;
        }

        public Type GetSurrogateType(Type type)
        {
            // Changes the IList<T> to CiccioList<T>
            if (type.IsGenericType && !type.IsGenericTypeDefinition
                && type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                return typeof(CiccioList<>).MakeGenericType(type.GetGenericArguments()[0]);
            }
            return type;
        }
    }
}
