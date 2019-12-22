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

        public Task<IEnumerable<FatturaReadOnly>> GetAll()
        {
            return Task.Run(() =>
            {
                List<FatturaReadOnly> list = new List<FatturaReadOnly>();
                foreach (Fattura item in entities)
                {
                    list.Add(new FatturaReadOnly(item.Id, item.Nome, item.Totale));
                }
                return (IEnumerable<FatturaReadOnly>)list;
            });
        }
    }
}
