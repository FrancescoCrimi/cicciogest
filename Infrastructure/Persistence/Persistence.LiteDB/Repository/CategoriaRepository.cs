using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ILogger<CategoriaRepository> logger, UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }

        public Task<IList<Categoria>> GetAll() => Task.Run(() =>
        {
            IEnumerable<Categoria> asd = coll.FindAll();
            IList<Categoria> suca = new List<Categoria>(asd);
            return suca;
        });
    }
}
