using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class FornitoreRepository : DomainRepository<Fornitore>, IFornitoreRepository
    {
        private readonly ILogger logger;

        public FornitoreRepository(ILogger logger, UnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.logger = logger;
        }

        public Task<IList<Fornitore>> GetAll() => Task.Run(() => 
        {
            IEnumerable<Fornitore> fornitores1 = coll.FindAll();
            IList<Fornitore> fornitores = new List<Fornitore>(fornitores1);
            return fornitores;
        });
    }
}
