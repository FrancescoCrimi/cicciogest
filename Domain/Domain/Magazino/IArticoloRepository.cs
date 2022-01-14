using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Magazino
{
    public interface IArticoloRepository : IDomainRepository<Articolo>, IDisposable
    {
        Task<IList<ArticoloReadOnly>> GetAll();
    }
}
