using CiccioGest.Domain.Common;
using System.Collections.Generic;

namespace CiccioGest.Domain.Magazino
{
    public interface ICategoriaRepository : IDomainRepository<Categoria>
    {
        IEnumerable<Categoria> GetAll();
    }
}
