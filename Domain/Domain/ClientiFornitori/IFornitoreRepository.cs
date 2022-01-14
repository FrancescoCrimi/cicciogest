using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain.ClientiFornitori
{
    public interface IFornitoreRepository : IDomainRepository<Fornitore>, IDisposable
    {
        Task<IList<Fornitore>> GetAll();
    }
}
