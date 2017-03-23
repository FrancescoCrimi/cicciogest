using CiccioGest.Domain;
using CiccioGest.Domain.Model;
using CiccioGest.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain.ReadOnlyModel;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class FatturaRepository : EntityRepository<Fattura, int>, IFatturaRepository
    {
        IEnumerable<FatturaReadOnly> IFatturaRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
