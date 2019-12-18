using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace CiccioGest.Presentation.Client
{
    public class FatturaServiceClient : FatturaServiceClientBase
    {
        //private IOperationBehavior oldBehavior;

        public FatturaServiceClient() :
            base(GetBinding(), GetEndpointAddress())
        {
            // Personalizza ServiceEndpoint
            foreach (OperationDescription od in Endpoint.Contract.Operations)
            {
                var dcsob = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
                //Imposta DataContractSurrogate
                dcsob.SerializationSurrogateProvider = new MySerializationSurrogateProvider();

                //DCSWithSurrogatesOperationBehavior newBehavior = null;
                //var oldBehavior = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
                //if (null != oldBehavior)
                //{
                //    newBehavior = new DCSWithSurrogatesOperationBehavior(oldBehavior);
                //    od.OperationBehaviors.Remove(oldBehavior);
                //}
                //else
                //{
                //    newBehavior = new DCSWithSurrogatesOperationBehavior();
                //}
                //newBehavior.SerializationSurrogateProvider = new MySerializationSurrogateProvider();
                //od.OperationBehaviors.Add(newBehavior);
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

        private static EndpointAddress GetEndpointAddress()
        {
            return new EndpointAddress("http://localhost:8000/fatturaservice.svc");
        }
    }
}
