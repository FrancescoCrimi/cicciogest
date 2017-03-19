using CiccioGest.Domain;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository(DataAccess da)
            : base(da) { }

        public override IEnumerable<Fattura> GetAll()
        {
            var qr = da.ISession.CreateQuery("select fat.Nome, fat.Id from Fattura fat");
            var aaa = qr.List();
            return (IEnumerable<Fattura>)aaa;
        }
    }
}
