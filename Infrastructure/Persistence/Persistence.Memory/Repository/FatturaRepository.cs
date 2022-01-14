using CiccioGest.Domain.Documenti;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Memory.Repository
{
    internal class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository()
        {
        }

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }

        public Task<IList<FatturaReadOnly>> GetAll()
        {
            return Task.Run(() =>
            {
                IList<FatturaReadOnly> list = new List<FatturaReadOnly>();
                foreach (Fattura item in entities)
                {
                    list.Add(new FatturaReadOnly(item.Id, item.Nome, item.Totale));
                }
                return list;
            });
        }
    }
}
