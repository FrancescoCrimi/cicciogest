using CiccioGest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Db4o.Repository
{
    class FatturaRepository : EntityRepository<Fattura, int>, IFatturaRepository
    {
        public FatturaRepository(DataAccess da)
            : base(da) { }
    }
}
