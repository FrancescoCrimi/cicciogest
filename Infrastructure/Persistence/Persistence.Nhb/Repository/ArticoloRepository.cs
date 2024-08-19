// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository(ILogger<ArticoloRepository> logger,
                                  UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public Task<IList<Articolo>> GetAll()
        {
            return _unitOfWork.Session.CreateCriteria<Articolo>().ListAsync<Articolo>();
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
