// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Documenti;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository(ILogger<FatturaRepository> logger,
                                 UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public Task<IList<Fattura>> GetAll()
        {
           return _unitOfWork.Session.CreateCriteria<Fattura>().ListAsync<Fattura>();
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
