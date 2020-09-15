using CiccioGest.Infrastructure.Conf;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace CiccioGest.Presentation.Client.Wcf
{
    internal class FatturaService : FatturaServiceClient
    {
        public FatturaService(CiccioGestConf conf)
            : base(GetBinding(), GetEndpointAddress(conf))
        {
        }

        protected override void ConfigureEndpoint(ServiceEndpoint serviceEndpoint, ClientCredentials clientCredentials)
        {
            foreach (OperationDescription od in serviceEndpoint.Contract.Operations)
            {
                DCSWithSurrogatesOperationBehavior newBehavior = null;
                var oldBehavior = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (null != oldBehavior)
                {
                    newBehavior = new DCSWithSurrogatesOperationBehavior(oldBehavior);
                    od.OperationBehaviors.Remove(oldBehavior);
                }
                else
                {
                    newBehavior = new DCSWithSurrogatesOperationBehavior();
                }
                newBehavior.SerializationSurrogateProvider = new MySerializationSurrogateProvider();
                od.OperationBehaviors.Add(newBehavior);
            }
        }

        private static Binding GetBinding()
        {
            BasicHttpBinding result = new BasicHttpBinding();
            result.MaxBufferSize = int.MaxValue;
            result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
            result.MaxReceivedMessageSize = int.MaxValue;
            result.AllowCookies = true;
            return result;
        }

        private static EndpointAddress GetEndpointAddress(CiccioGestConf conf)
        {
            //return new EndpointAddress("http://localhost:8000/fatturaservice.svc");
            return new EndpointAddress(conf.CS + "/fatturaservice.svc");
        }
    }
}
