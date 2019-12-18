//using System;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.ServiceModel.Description;
//using System.Xml;

//namespace CiccioGest.Presentation.Uwp.App1.Wcf
//{
//    public class DCSWithSurrogatesOperationBehavior : DataContractSerializerOperationBehavior
//    {
//        public DCSWithSurrogatesOperationBehavior(DataContractSerializerOperationBehavior dcsBehavior)
//            : base(null, dcsBehavior.DataContractFormatAttribute)
//        {
//            MaxItemsInObjectGraph = dcsBehavior.MaxItemsInObjectGraph;
//            DataContractResolver = dcsBehavior.DataContractResolver;
//        }

//        public DCSWithSurrogatesOperationBehavior()
//            : base(null) { }

//        public ISerializationSurrogateProvider SerializationSurrogateProvider { get; set; }

//        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
//        {
//            var dcs = (DataContractSerializer)base.CreateSerializer(type, name, ns, knownTypes);
//            dcs.SetSerializationSurrogateProvider(SerializationSurrogateProvider);
//            return dcs;
//        }

//        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
//        {
//            var dcs = (DataContractSerializer)base.CreateSerializer(type, name, ns, knownTypes);
//            dcs.SetSerializationSurrogateProvider(SerializationSurrogateProvider);
//            return dcs;
//        }
//    }
//}
