using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class ClienteRepository : DomainRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<Cliente>> GetAll()
        {
            IList<Cliente> clienti = await unitOfWork.ISession.CreateCriteria<Cliente>().ListAsync<Cliente>();
            return clienti;
        }
    }
}
