using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(UnitOfWorkNhb unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Categoria> GetAll()
        {
            return unitOfWork.ISession.CreateCriteria<Categoria>().List<Categoria>();
        }
    }
}
