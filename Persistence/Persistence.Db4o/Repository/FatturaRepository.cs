using CiccioGest.Domain;
using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Db4o.Repository
{
    class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository(UnitOfWorkDb4o da)
            : base(da) { }

        IEnumerable<FatturaReadOnly> IFatturaRepository.GetAll()
        {
            var list = da.ObjectContainer.Query<Fattura>();
            var listRo = new List<FatturaReadOnly>();
            foreach (Fattura item in list)
            {
                listRo.Add(new FatturaReadOnly(item.Id, item.Nome, item.Totale));
            }
            return listRo;
        }
    }
}
