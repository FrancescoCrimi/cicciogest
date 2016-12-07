using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Infrastructure.Persistence.Db4o.Repository
{
    class ProdottoRepository : EntityRepository<Prodotto, int>, IProdottoRepository
    {
        public ProdottoRepository(DataAccess da)
            : base(da) { }
    }
}
