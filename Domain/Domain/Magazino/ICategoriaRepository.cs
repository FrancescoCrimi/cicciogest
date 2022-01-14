using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Magazino
{
    public interface ICategoriaRepository : IDomainRepository<Categoria>, IDisposable
    {
        Task<IList<Categoria>> GetAll();
    }
}
