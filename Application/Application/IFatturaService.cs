using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    public interface IFatturaService : IDisposable
    {
        Task<IList<FatturaReadOnly>> GetFatture();

        Task<Fattura> GetFattura(int id);

        Task<Fattura> SaveFattura(Fattura fattura);

        Task DeleteFattura(int id);

        Task<Articolo> GetArticolo(int id);

        Task<Cliente> GetCliente(int id);
    }
}
