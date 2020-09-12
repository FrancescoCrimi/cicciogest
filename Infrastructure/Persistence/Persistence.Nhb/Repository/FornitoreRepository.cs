using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class FornitoreRepository : DomainRepository<Fornitore>, IFornitoreRepository
    {
        public FornitoreRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<Fornitore>> GetAll()
        {
            IList<Fornitore> fornitori = await unitOfWork.ISession.CreateCriteria<Fornitore>().ListAsync<Fornitore>();
            return fornitori;
        }
    }
}
