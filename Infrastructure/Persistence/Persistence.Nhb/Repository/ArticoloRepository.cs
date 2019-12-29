using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository(ILogger logger, UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + unitOfWork.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Created");
        }

        public Task<IList<ArticoloReadOnly>> GetAll()
        {
            return Task.Run(() =>
            {
                IList<ArticoloReadOnly> list = new List<ArticoloReadOnly>();
                IList<Articolo> prodotti = unitOfWork.ISession.CreateCriteria<Articolo>().List<Articolo>();
                foreach (Articolo item in prodotti)
                {
                    list.Add(new ArticoloReadOnly(item.Id, item.Nome, item.Prezzo, item.NomeCategoria));
                }
                return list;
            });
        }
    }
}
