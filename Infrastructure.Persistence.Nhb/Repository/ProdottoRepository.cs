using Ciccio1.Domain;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Infrastructure.Persistence.Nhb.Repository
{
    class ProdottoRepository : EntityRepository<Prodotto, int>, IProdottoRepository
    {
        public ProdottoRepository(IDataAccess da)
            : base((DataAccess)da) { }
    }
}
