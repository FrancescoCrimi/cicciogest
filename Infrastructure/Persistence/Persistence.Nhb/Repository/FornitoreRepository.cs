using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class FornitoreRepository : DomainRepository<Fornitore>, IFornitoreRepository
    {
        public FornitoreRepository(ILogger<FornitoreRepository> logger,
                                   IUnitOfWork unitOfWork) 
            : base(logger, unitOfWork)
        {
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }

        public async Task<IList<Fornitore>> GetAll()
        {
            IList<Fornitore> fornitori = await unitOfWork.ISession.CreateCriteria<Fornitore>().ListAsync<Fornitore>();
            return fornitori;
        }
    }
}
