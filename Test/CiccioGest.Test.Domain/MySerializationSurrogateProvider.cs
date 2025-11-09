// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioSoft.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CiccioGest.Test.Domain
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
