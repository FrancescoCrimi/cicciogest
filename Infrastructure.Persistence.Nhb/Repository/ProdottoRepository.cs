using CiccioGest.Domain;
using CiccioGest.Domain.Model;
using CiccioGest.Domain.ReadOnlyModel;
using CiccioGest.Domain.Repository;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class ProdottoRepository : DomainRepository<Prodotto>, IProdottoRepository
    {
        public ProdottoRepository(DataAccess da)
            : base(da) { }

        public IEnumerable<ProdottoReadOnly> GetAll()
        {
            List<ProdottoReadOnly> list = new List<ProdottoReadOnly>();
            IList<Prodotto> prodotti = da.ISession.CreateCriteria<Prodotto>().List<Prodotto>();
            foreach (Prodotto item in prodotti)
            {
                list.Add(new ProdottoReadOnly(item.Id, item.Nome, item.Prezzo, item.NomeCategoria));
            }
            return list;
        }
    }
}
