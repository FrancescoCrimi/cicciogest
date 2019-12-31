using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Client.Wcf
{
    internal abstract class FatturaServiceClient : ClientBase<IFatturaService>, IFatturaService
    {
        protected abstract void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public FatturaServiceClient(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
            ConfigureEndpoint(Endpoint, ClientCredentials);
        }

        public Task<IList<FatturaReadOnly>> GetFatture()
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
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((ICommunicationObject)(this)).EndOpen));
        }

        public virtual Task CloseAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((ICommunicationObject)(this)).EndClose));
        }
    }
}
