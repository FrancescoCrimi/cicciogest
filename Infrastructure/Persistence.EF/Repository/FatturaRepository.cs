using CiccioGest.Domain;
using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        IEnumerable<FatturaReadOnly> IFatturaRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
