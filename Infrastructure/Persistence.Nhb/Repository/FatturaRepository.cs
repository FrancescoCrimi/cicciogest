using CiccioGest.Domain.Documenti;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository(UnitOfWorkNhb unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<FatturaReadOnly> GetAll()
        {
            List<FatturaReadOnly> list = new List<FatturaReadOnly>();
            //IList qr = da.ISession.CreateQuery("select fat.Id, fat.Nome, fat.Totale from Fattura fat").List();
            IList<Fattura> fatture = unitOfWork.ISession.CreateCriteria<Fattura>().List<Fattura>();
            foreach (Fattura item in fatture)
            {
                list.Add(new FatturaReadOnly(item.Id, item.Nome, item.Totale));
            }
            return list;
        }
    }
}
