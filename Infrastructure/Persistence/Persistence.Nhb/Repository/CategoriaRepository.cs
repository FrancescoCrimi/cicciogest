using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ILogger logger, UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + unitOfWork.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Created");
        }

        public Task<IList<Categoria>> GetAll()
        {
            return unitOfWork.ISession.CreateCriteria<Categoria>().ListAsync<Categoria>();
        }
    }
}
