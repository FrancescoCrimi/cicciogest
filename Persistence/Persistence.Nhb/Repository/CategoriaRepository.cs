using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ILogger logger, UnitOfWorkNhb unitOfWork)
            : base(unitOfWork)
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + unitOfWork.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Created");
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await unitOfWork.ISession.CreateCriteria<Categoria>().ListAsync<Categoria>();
        }
    }
}
