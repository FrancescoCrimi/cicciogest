using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public Task<IEnumerable<FatturaReadOnly>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
