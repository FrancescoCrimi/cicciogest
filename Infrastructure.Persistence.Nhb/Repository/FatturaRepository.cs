using Ciccio1.Domain;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Infrastructure.Persistence.Nhb.Repository
{
    class FatturaRepository : EntityRepository<Fattura, int>, IFatturaRepository
    {
        public FatturaRepository(IDataAccess da)
            : base((DataAccess)da) { }
    }
}
