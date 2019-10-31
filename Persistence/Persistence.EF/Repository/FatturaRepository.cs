using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        IList<FatturaReadOnly> IFatturaRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
