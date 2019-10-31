using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel.Description;

namespace CiccioGest.Presentation.ClientStd
{
    public partial class FatturaServiceClient : System.ServiceModel.ClientBase<IFatturaService>, IFatturaService
    {
        public FatturaServiceClient() :
                base(GetBinding(), GetEndpointAddress())
        {
            this.Endpoint.Name = "BasicHttpBinding_IFatturaService";

            // Personalizza ServiceEndpoint
            foreach (OperationDescription od in Endpoint.Contract.Operations)
            {
                var dcsob = od.Behaviors.Find<DataContractSerializerOperationBehavior>();

                //Imposta DataContractSurrogate
                dcsob.SerializationSurrogateProvider = new MySerializationSurrogateProvider();
                //dcsob.GetType().InvokeMember("SerializationSurrogateProvider", BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, Type.DefaultBinder, dcsob, new object[] { new MySerializationSurrogateProvider() });

                ////Imposta DataContractResolver
                //dcsob.DataContractResolver = new MyDataContractResolver();
            }
        }



        public System.Collections.Generic.IEnumerable<FatturaReadOnly> GetFatture()
        {
            return base.Channel.GetFatture();
        }

        public Fattura GetFattura(int id)
        {
            return base.Channel.GetFattura(id);
        }

        public Fattura SaveFattura(Fattura fattura)
        {
            return base.Channel.SaveFattura(fattura);
        }

        public void DeleteFattura(int id)
        {
            base.Channel.DeleteFattura(id);
        }

        public Articolo GetProdotto(int id)
        {
            return base.Channel.GetProdotto(id);
        }

        public Cliente GetCliente(int idCliente)
        {
            return base.Channel.GetCliente(idCliente);
        }



        private static System.ServiceModel.Channels.Binding GetBinding()
        {
            System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
            result.MaxBufferSize = int.MaxValue;
            result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
            result.MaxReceivedMessageSize = int.MaxValue;
            result.AllowCookies = true;
            return result;
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress()
        {
            return new System.ServiceModel.EndpointAddress("http://localhost:8000/FatturaService.svc");
        }
    }
}
