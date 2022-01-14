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

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }

        public Task<IList<ArticoloReadOnly>> GetAll()
        {
            return Task.Run(() =>
            {
                IList<ArticoloReadOnly> list = new List<ArticoloReadOnly>();
                foreach (Articolo item in entities)
                {
                    list.Add(new ArticoloReadOnly(item.Id, item.Nome, item.Prezzo, item.Categorie));
                }
                return list;
            });
        }
    }
}
