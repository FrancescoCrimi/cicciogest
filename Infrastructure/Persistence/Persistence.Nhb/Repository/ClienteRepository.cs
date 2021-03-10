using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class ClienteRepository : DomainRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ILogger<ClienteRepository> logger,
                                 IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        public async Task<IList<Cliente>> GetAll()
        {
            IList<Cliente> clienti = await unitOfWork.ISession.CreateCriteria<Cliente>().ListAsync<Cliente>();
            return clienti;
        }
    }
}
