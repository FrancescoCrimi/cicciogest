using CiccioGest.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Documenti
{
    public interface IFatturaRepository : IDomainRepository<Fattura>
    {
        Task<IList<FatturaReadOnly>> GetAll();
    }
}
