using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository(ILogger<ArticoloRepository> logger,
                                  IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
            logger.LogDebug("Created: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }

        public async Task<IList<ArticoloReadOnly>> GetAll()
        {
            IList<ArticoloReadOnly> list = new List<ArticoloReadOnly>();
            IList<Articolo> prodotti = await unitOfWork.ISession.CreateCriteria<Articolo>().ListAsync<Articolo>();
            foreach (Articolo item in prodotti)
            {
                list.Add(new ArticoloReadOnly(item.Id, item.Nome, item.Prezzo, item.Categorie));
            }
            return list;
        }
    }
}
