// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class FornitoreRepository : DomainRepository<Fornitore>, IFornitoreRepository
    {
        public FornitoreRepository(ILogger<FornitoreRepository> logger,
                                   UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }

        public async Task<IList<Fornitore>> GetAll()
        {
            IList<Fornitore> fornitori = await _unitOfWork.Session.CreateCriteria<Fornitore>().ListAsync<Fornitore>();
            return fornitori;
        }
    }
}
