using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        private readonly ILogger logger;
        private readonly UnitOfWork unitOfWork;

        public CategoriaRepository(ILogger<CategoriaRepository> logger, UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task<IList<Categoria>> GetAll() => Task.Run(() =>
        {
            IEnumerable<Categoria> asd = coll.FindAll();
            IList<Categoria> suca = new List<Categoria>(asd);
            return suca;
        });
    }
}
