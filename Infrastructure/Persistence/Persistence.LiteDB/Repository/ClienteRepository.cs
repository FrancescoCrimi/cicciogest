using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class ClienteRepository : DomainRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ILogger<ClienteRepository> logger, UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }

        public Task<IList<Cliente>> GetAll() => Task.Run(() =>
        {
            IEnumerable<Cliente> suca = coll.FindAll();
            IList<Cliente> lr = new List<Cliente>(suca);
            return lr;
        });
    }
}
