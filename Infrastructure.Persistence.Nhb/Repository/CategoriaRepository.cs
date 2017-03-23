using CiccioGest.Domain.Model;
using CiccioGest.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DataAccess da)
            : base(da)
        {
        }

        public IEnumerable<Categoria> GetAll()
        {
            return da.ISession.CreateCriteria<Categoria>().List<Categoria>();
        }
    }
}
