using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Domain.ClientiFornitori
{
    public interface IClienteRepository : IDomainRepository<Cliente>, IDisposable
    {
        Task<IList<Cliente>> GetAll();
    }
}
