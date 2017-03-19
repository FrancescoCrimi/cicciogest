using CiccioGest.Domain;
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

        public override IEnumerable<Prodotto> GetAll()
        {
            var qr = da.ISession.CreateQuery("select prod.Id, prod.Nome from Prodotto prod");
            return qr.Enumerable<Prodotto>();
        }
    }
}
