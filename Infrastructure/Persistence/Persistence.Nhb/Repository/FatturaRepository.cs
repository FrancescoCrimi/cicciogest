using CiccioGest.Domain.Documenti;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository(ILogger<FatturaRepository> logger,
                                 IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
            logger.LogDebug("HashCode: " + GetHashCode() + " (uow: " + unitOfWork.GetHashCode()+ ") Created");
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }

        public async Task<IList<FatturaReadOnly>> GetAll()
        {
                IList<FatturaReadOnly> list = new List<FatturaReadOnly>();
                //IList qr = da.ISession.CreateQuery("select fat.Id, fat.Nome, fat.Totale from Fattura fat").List();
                IList<Fattura> fatture = await unitOfWork.ISession.CreateCriteria<Fattura>().ListAsync<Fattura>();
                foreach (Fattura item in fatture)
                {
                    list.Add(new FatturaReadOnly(item.Id, item.Nome, item.Totale));
                }
                return list;
        }
    }
}
