using CiccioGest.Domain.Common;
using System.Collections.Generic;

namespace CiccioGest.Domain.Documenti
{
    public interface IFatturaRepository : IDomainRepository<Fattura>
    {
        IEnumerable<FatturaReadOnly> GetAll();
        //IList<FatturaReadOnly> GetAll();
    }
}
