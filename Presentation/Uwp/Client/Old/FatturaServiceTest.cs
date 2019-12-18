//using System;
//using System.Collections.Generic;
//using System.ServiceModel;
//using System.ServiceModel.Description;
//using System.Threading.Tasks;

//namespace CiccioGest.Presentation.Uwp.App1.Wcf
//{
//    public class FatturaServiceTest : ClientBase<Application.IFatturaService>, Application.IFatturaService
//    {
//        public FatturaServiceTest() :
//            base(GetBindingForEndpoint(), GetEndpointAddress())
//        {
//            foreach (OperationDescription od in Endpoint.Contract.Operations)
//            {
//                DCSWithSurrogatesOperationBehavior newBehavior = null;
//                var oldBehavior = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
//                if (null != oldBehavior)
//                {
//                    newBehavior = new DCSWithSurrogatesOperationBehavior(oldBehavior);
//                    od.OperationBehaviors.Remove(oldBehavior);
//                }
//                else
//                {
//                    newBehavior = new DCSWithSurrogatesOperationBehavior();
//                }
//                newBehavior.SerializationSurrogateProvider = new MySerializationSurrogateProvider();
//                od.OperationBehaviors.Add(newBehavior);
//            }
//        }

//        public FatturaServiceTest(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress) :
//            base(binding, remoteAddress)
//        { }

//        public Task<IEnumerable<Domain.Documenti.FatturaReadOnly>> GetFatture()
//        {
//            return Channel.GetFatture();
//        }

//        public Task<Domain.Documenti.Fattura> GetFattura(int id)
//        {
//            return Channel.GetFattura(id);
//        }

//        public Task<Domain.Documenti.Fattura> SaveFattura(Domain.Documenti.Fattura fattura)
//        {
//            return Channel.SaveFattura(fattura);
//        }

//        public Task DeleteFattura(int id)
//        {
//            return Channel.DeleteFattura(id);
//        }

//        public Task<Domain.Magazino.Articolo> GetArticolo(int id)
//        {
//            return Channel.GetArticolo(id);
//        }

//        public Task<Domain.ClientiFornitori.Cliente> GetCliente(int idCliente)
//        {
//            return Channel.GetCliente(idCliente);
//        }

//        public virtual Task OpenAsync()
//        {
//            return Task.Factory.FromAsync(((ICommunicationObject)this).BeginOpen(null, null), new Action<IAsyncResult>(((ICommunicationObject)this).EndOpen));
//        }

//        public virtual Task CloseAsync()
//        {
//            return Task.Factory.FromAsync(((ICommunicationObject)this).BeginClose(null, null), new Action<IAsyncResult>(((ICommunicationObject)this).EndClose));
//        }

//        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint()
//        {
//            BasicHttpBinding result = new BasicHttpBinding();
//            result.MaxBufferSize = int.MaxValue;
//            result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
//            result.MaxReceivedMessageSize = int.MaxValue;
//            result.AllowCookies = true;
//            return result;
//        }

//        private static EndpointAddress GetEndpointAddress()
//        {
//            return new EndpointAddress("http://localhost:8000/FatturaService.svc");
//        }
//    }
//}
