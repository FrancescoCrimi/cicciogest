using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Client
{
    public class FatturaServiceClientBase : ClientBase<IFatturaService>, IFatturaService
    {
        public FatturaServiceClientBase(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        { }

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
            return Task.Factory.FromAsync(((ICommunicationObject)this).BeginOpen(null, null), new Action<IAsyncResult>(((ICommunicationObject)this).EndOpen));
        }

        public virtual Task CloseAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)this).BeginClose(null, null), new Action<IAsyncResult>(((ICommunicationObject)this).EndClose));
        }
    }
}
