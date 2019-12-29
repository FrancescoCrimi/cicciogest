using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        private readonly ILogger logger;
        private readonly UnitOfWork unitOfWork;

        public ArticoloRepository(ILogger logger, UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task<IList<ArticoloReadOnly>> GetAll() => Task.Run(() =>
        {
            var lstArt = coll.FindAll();
            IList<ArticoloReadOnly> lst = new List<ArticoloReadOnly>();
            foreach (var item in lstArt)
            {
                lst.Add(new ArticoloReadOnly(item.Id, item.Nome, item.Prezzo, item.NomeCategoria));
            }
            return lst;
        });
    }
}
