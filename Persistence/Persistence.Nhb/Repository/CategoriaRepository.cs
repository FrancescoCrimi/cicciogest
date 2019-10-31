using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Globalization;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ILogger logger, UnitOfWorkNhb unitOfWork)
            : base(unitOfWork)
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + unitOfWork.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Created");
        }

        public IEnumerable<Categoria> GetAll()
        {
            return unitOfWork.ISession.CreateCriteria<Categoria>().List<Categoria>();
        }
    }
}
