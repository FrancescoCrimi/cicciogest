using Castle.Core.Logging;
using CiccioGest.Domain.Documenti;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        private readonly ILogger logger;
        private readonly UnitOfWork unitOfWork;

        public FatturaRepository(ILogger logger, UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task<IList<FatturaReadOnly>> GetAll() => Task.Run(() =>
        {
            var lstArt = coll.FindAll();
            IList<FatturaReadOnly> lst = new List<FatturaReadOnly>();
            foreach (var item in lstArt)
            {
                lst.Add(new FatturaReadOnly(item.Id, item.Nome, item.Totale));
            }
            return lst;
        });
    }
}
