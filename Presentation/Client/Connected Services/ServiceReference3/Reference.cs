using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServiceReference3
{
    [ServiceContract(ConfigurationName = "ServiceReference3.IFatturaService")]
    public interface IFatturaService
    {
        [OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/GetFatture", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/GetFattureResponse")]
        Task<CiccioSoft.Collections.Generic.CiccioList<FatturaReadOnly>> GetFattureAsync();

        [OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/GetFattura", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/GetFatturaResponse")]
        Task<Fattura> GetFatturaAsync(int id);

        [OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/SaveFattura", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/SaveFatturaResponse")]
        Task<Fattura> SaveFatturaAsync(Fattura fattura);

        [OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/DeleteFattura", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/DeleteFatturaResponse")]
        Task DeleteFatturaAsync(int id);

        [OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/GetArticolo", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/GetArticoloResponse")]
        Task<Articolo> GetArticoloAsync(int id);

        [OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/GetCliente", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/GetClienteResponse")]
        Task<Cliente> GetClienteAsync(int idCliente);
    }


    public partial class FatturaServiceClient : ClientBase<IFatturaService>, IFatturaService
    {

        /// <summary>
        /// Implementare questo metodo parziale per configurare l'endpoint servizio.
        /// </summary>
        /// <param name="serviceEndpoint">Endpoint da configurare</param>
        /// <param name="clientCredentials">Credenziali del client</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public FatturaServiceClient() :
                base(GetBindingForEndpoint(), GetEndpointAddress())
        {
            ConfigureEndpoint(Endpoint, ClientCredentials);
        }

        public FatturaServiceClient(string remoteAddress) :
                base(GetBindingForEndpoint(), new EndpointAddress(remoteAddress))
        {
            ConfigureEndpoint(Endpoint, ClientCredentials);
        }

        public FatturaServiceClient(EndpointAddress remoteAddress) :
                base(GetBindingForEndpoint(), remoteAddress)
        {
            ConfigureEndpoint(Endpoint, ClientCredentials);
        }

        public FatturaServiceClient(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public Task<CiccioSoft.Collections.Generic.CiccioList<FatturaReadOnly>> GetFattureAsync()
        {
            return Channel.GetFattureAsync();
        }

        public Task<Fattura> GetFatturaAsync(int id)
        {
            return Channel.GetFatturaAsync(id);
        }

        public Task<Fattura> SaveFatturaAsync(Fattura fattura)
        {
            return Channel.SaveFatturaAsync(fattura);
        }

        public Task DeleteFatturaAsync(int id)
        {
            return Channel.DeleteFatturaAsync(id);
        }

        public Task<Articolo> GetArticoloAsync(int id)
        {
            return Channel.GetArticoloAsync(id);
        }

        public Task<Cliente> GetClienteAsync(int idCliente)
        {
            return Channel.GetClienteAsync(idCliente);
        }

        public virtual Task OpenAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((ICommunicationObject)(this)).EndOpen));
        }

        public virtual Task CloseAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((ICommunicationObject)(this)).EndClose));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint()
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
