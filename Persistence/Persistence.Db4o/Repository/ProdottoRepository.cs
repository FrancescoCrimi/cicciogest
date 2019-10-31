using CiccioGest.Domain;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Db4o.Repository
{
    class ProdottoRepository : DomainRepository<Prodotto>, IProdottoRepository
    {
        public ProdottoRepository(UnitOfWorkDb4o da)
            : base(da) { }

        public IEnumerable<ProdottoReadOnly> GetAll()
        {
            var list = da.ObjectContainer.Query<Prodotto>();
            var listRO = new List<ProdottoReadOnly>(list.Count);
            foreach (Prodotto item in list)
            {
                listRO.Add(new ProdottoReadOnly(item.Id, item.Nome, item.Prezzo, item.NomeCategoria));
            }
            return listRO;
        }
    }
}
