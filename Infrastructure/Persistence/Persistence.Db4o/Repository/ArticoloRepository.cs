using CiccioGest.Domain;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Db4o.Repository
{
    class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository(UnitOfWorkDb4o da)
            : base(da) { }

        public async Task<IEnumerable<ArticoloReadOnly>> GetAll()
        {
            var list = da.ObjectContainer.Query<Articolo>();
            var listRO = new List<ArticoloReadOnly>(list.Count);
            foreach (Articolo item in list)
            {
                listRO.Add(new ArticoloReadOnly(item.Id, item.Nome, item.Prezzo, item.NomeCategoria));
            }
            return listRO;
        }
    }
}
