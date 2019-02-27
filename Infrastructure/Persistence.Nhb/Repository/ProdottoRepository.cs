using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class ProdottoRepository : DomainRepository<Prodotto>, IProdottoRepository
    {
        public ProdottoRepository(ILogger logger, UnitOfWorkNhb unitOfWork)
            : base(unitOfWork)
        {
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " (uow:" + unitOfWork.GetHashCode().ToString() + " ) Created");
        }

        public IEnumerable<ProdottoReadOnly> GetAll()
        {
            List<ProdottoReadOnly> list = new List<ProdottoReadOnly>();
            IList<Prodotto> prodotti = unitOfWork.ISession.CreateCriteria<Prodotto>().List<Prodotto>();
            foreach (Prodotto item in prodotti)
            {
                list.Add(new ProdottoReadOnly(item.Id, item.Nome, item.Prezzo, item.NomeCategoria));
            }
            return list;
        }
    }
}
