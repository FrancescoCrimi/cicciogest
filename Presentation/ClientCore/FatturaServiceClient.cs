using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.ClientCore
{
    public partial class FatturaServiceClient : ClientBase<IFatturaService>, IFatturaService
    {
        ///// <summary>
        ///// Implementare questo metodo parziale per configurare l'endpoint servizio.
        ///// </summary>
        ///// <param name="serviceEndpoint">Endpoint da configurare</param>
        ///// <param name="clientCredentials">Credenziali del client</param>
        //static partial void ConfigureEndpoint(ServiceEndpoint serviceEndpoint, ClientCredentials clientCredentials);

        public FatturaServiceClient() :
            base(GetDefaultBinding(), GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IFatturaService.ToString();
            //ConfigureEndpoint(this.Endpoint, this.ClientCredentials);

            // Personalizza ServiceEndpoint
            foreach (OperationDescription od in Endpoint.Contract.Operations)
            {
                var dcsob = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
                //Imposta DataContractSurrogate
                dcsob.SerializationSurrogateProvider = new MySerializationSurrogateProvider();
            }
        }

        public Task<IEnumerable<FatturaReadOnly>> GetFatture()
        {
            return Channel.GetFatture();
        }

        public Task<Fattura> GetFattura(int id)
        {
            return Channel.GetFattura(id);
        }

        public Task<Fattura> SaveFattura(Fattura fattura)
        {
            return Channel.SaveFattura(fattura);
        }

        public Task DeleteFattura(int id)
        {
            return Channel.DeleteFattura(id);
        }

        public Task<Articolo> GetArticolo(int id)
        {
            return Channel.GetArticolo(id);
        }

        public Task<Cliente> GetCliente(int idCliente)
        {
            return Channel.GetCliente(idCliente);
        }

        public virtual Task OpenAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginOpen(null, null), new Action<IAsyncResult>(((ICommunicationObject)(this)).EndOpen));
        }

        public virtual Task CloseAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginClose(null, null), new Action<IAsyncResult>(((ICommunicationObject)(this)).EndClose));
        }

        private static Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if (endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IFatturaService)
            {
                BasicHttpBinding result = new BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new InvalidOperationException(string.Format("L\'endpoint denominato \'{0}\' non è stato trovato.", endpointConfiguration));
        }

        private static EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if (endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IFatturaService)
            {
                return new EndpointAddress("http://localhost:8000/FatturaService.svc");
            }
            throw new InvalidOperationException(string.Format("L\'endpoint denominato \'{0}\' non è stato trovato.", endpointConfiguration));
        }

        private static Binding GetDefaultBinding()
        {
            return GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IFatturaService);
        }

        private static EndpointAddress GetDefaultEndpointAddress()
        {
            return GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IFatturaService);
        }

        public enum EndpointConfiguration
        {
            BasicHttpBinding_IFatturaService,
        }
    }
}
