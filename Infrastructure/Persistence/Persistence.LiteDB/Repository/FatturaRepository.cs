using CiccioGest.Domain.Documenti;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository(ILogger<FatturaRepository> logger, UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
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
