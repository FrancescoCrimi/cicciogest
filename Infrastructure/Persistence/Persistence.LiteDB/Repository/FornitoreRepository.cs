// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class FornitoreRepository : DomainRepository<Fornitore>, IFornitoreRepository
    {
        public FornitoreRepository(ILogger<FornitoreRepository> logger, UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }

        public Task<IList<Fornitore>> GetAll() => Task.Run(() => 
        {
            IEnumerable<Fornitore> fornitores1 = coll.FindAll();
            IList<Fornitore> fornitores = new List<Fornitore>(fornitores1);
            return fornitores;
        });
    }
}
