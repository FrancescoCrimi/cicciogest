using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Memory.Repository
{
    internal class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository()
        {
        }

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }

        public Task<IList<Categoria>> GetAll()
        {
            return Task.Run(() =>
            {
                return entities;
            });
        }
    }
}
