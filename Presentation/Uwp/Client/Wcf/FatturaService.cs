using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Uwp.Client.Wcf
{
    class FatturaService : FatturaServiceClient, Application.IFatturaService
    {
        public Task DeleteFattura(int id)
        {
            return DeleteFatturaAsync(id);
        }

        public Task<Domain.Magazino.Articolo> GetArticolo(int id)
        {
            return GetArticolo(id);
        }

        public Task<Domain.ClientiFornitori.Cliente> GetCliente(int idCliente)
        {
            return GetCliente(idCliente);
        }

        public Task<Domain.Documenti.Fattura> GetFattura(int id)
        {
            return GetFatturaAsync(id);
        }

        public Task<IList<Domain.Documenti.FatturaReadOnly>> GetFatture()
        {
            return Task.Run(async () =>
            {
                var lst = await GetFattureAsync();
                return (IList<Domain.Documenti.FatturaReadOnly>)lst;
            });
        }

        public Task<Domain.Documenti.Fattura> SaveFattura(Domain.Documenti.Fattura fattura)
        {
            return SaveFatturaAsync(fattura);
        }
    }
}
