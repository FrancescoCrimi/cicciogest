using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ILogger<CategoriaRepository> logger,
                                   IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
            logger.LogDebug("HashCode: " + GetHashCode() + " (uow: " + unitOfWork.GetHashCode() + ") Created");
        }

        public async Task<IList<Categoria>> GetAll()
        {
            return await unitOfWork.ISession.CreateCriteria<Categoria>().ListAsync<Categoria>();
        }
    }
}
