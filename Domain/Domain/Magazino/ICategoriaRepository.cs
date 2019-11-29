using CiccioGest.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Magazino
{
    public interface ICategoriaRepository : IDomainRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetAll();
    }
}
