using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository()
        {
        }

        public Task<IEnumerable<FatturaReadOnly>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
