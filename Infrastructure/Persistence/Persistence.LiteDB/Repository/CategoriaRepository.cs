using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository()
        {
        }

        public Task<IEnumerable<Categoria>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
