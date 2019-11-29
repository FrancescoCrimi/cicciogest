using CiccioGest.Domain;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Db4o.Repository
{
    class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(UnitOfWorkDb4o da)
            : base(da) { }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return da.ObjectContainer.Query<Categoria>();
        }
    }
}
