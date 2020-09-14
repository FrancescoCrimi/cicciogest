using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class ClienteRepository : DomainRepository<Cliente>, IClienteRepository
    {
        private readonly ILogger logger;

        public ClienteRepository(ILogger logger, UnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.logger = logger;
        }

        public Task<IList<Cliente>> GetAll() => Task.Run(() =>
        {
            IEnumerable<Cliente> suca = coll.FindAll();
            IList<Cliente> lr = new List<Cliente>(suca);
            return lr;
        });
    }
}
