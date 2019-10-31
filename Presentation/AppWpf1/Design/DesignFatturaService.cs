using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppWpf1.Design
{
    class DesignFatturaService : IFatturaService
    {
        public Task<Fattura> GetFattura(int id) =>
            Task.Run(() => DesignData.Fatture.First(fa => fa.Id == id));
        public Task<IEnumerable<FatturaReadOnly>> GetFatture() =>
            Task.Run(() => (IEnumerable<FatturaReadOnly>)DesignData.FattureRO);
        public Task DeleteFattura(int id) => throw new NotImplementedException();
        public Task<Fattura> SaveFattura(Fattura fattura) => throw new NotImplementedException();
        public Task<Articolo> GetArticolo(int id) => throw new NotImplementedException();
        public Task<Cliente> GetCliente(int idCliente) => throw new NotImplementedException();
        public void Dispose() { }
    }
}
