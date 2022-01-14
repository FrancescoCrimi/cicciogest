using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository(ILogger<ArticoloRepository> logger, UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }

        public Task<IList<ArticoloReadOnly>> GetAll() => Task.Run(() =>
        {
            var lstArt = coll.FindAll();
            IList<ArticoloReadOnly> lst = new List<ArticoloReadOnly>();
            foreach (var item in lstArt)
            {
                lst.Add(new ArticoloReadOnly(item.Id, item.Nome, item.Prezzo, item.Categorie));
            }
            return lst;
        });
    }
}
