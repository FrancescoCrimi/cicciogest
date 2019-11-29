using System.Collections.Generic;
using System.Threading.Tasks;
using CiccioGest.Domain.Magazino;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public Task<IEnumerable<Categoria>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
