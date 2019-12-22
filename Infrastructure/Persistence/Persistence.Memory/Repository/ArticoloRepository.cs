using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Memory.Repository
{
    internal class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository()
        {
        }

        public Task<IEnumerable<ArticoloReadOnly>> GetAll()
        {
            return Task.Run(() => {
                List<ArticoloReadOnly> list = new List<ArticoloReadOnly>();
                foreach (Articolo item in entities)
                {
                    list.Add(new ArticoloReadOnly(item.Id, item.Nome, item.Prezzo, item.NomeCategoria));
                }
                return (IEnumerable<ArticoloReadOnly>)list;
            });
        }
    }
}
