using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Documenti
{
    public interface IFatturaRepository : IDomainRepository<Fattura>, IDisposable
    {
        Task<IList<FatturaReadOnly>> GetAll();
    }
}
