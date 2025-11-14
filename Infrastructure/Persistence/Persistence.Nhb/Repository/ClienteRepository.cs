// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class ClienteRepository : DomainRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ILogger<ClienteRepository> logger,
                                 UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public async Task<IList<Cliente>> GetAll()
        {
            IList<Cliente> clienti = await _unitOfWork.Session.CreateCriteria<Cliente>().ListAsync<Cliente>();
            return clienti;
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
