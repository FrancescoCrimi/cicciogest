using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Globalization;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository(ILogger logger, UnitOfWorkNhb unitOfWork)
            : base(unitOfWork)
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + unitOfWork.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Created");
        }

        public IEnumerable<ArticoloReadOnly> GetAll()
        {
            List<ArticoloReadOnly> list = new List<ArticoloReadOnly>();
            IList<Articolo> prodotti = unitOfWork.ISession.CreateCriteria<Articolo>().List<Articolo>();
            foreach (Articolo item in prodotti)
            {
                list.Add(new ArticoloReadOnly(item.Id, item.Nome, item.Prezzo, item.NomeCategoria));
            }
            return list;
        }
    }
}
