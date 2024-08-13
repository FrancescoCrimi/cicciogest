// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository(ILogger<ArticoloRepository> logger, UnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        public Task<IList<Articolo>> GetAll() => Task.Run(() =>
        {
            var lstArt = coll.FindAll();
            IList<Articolo> lst = new List<Articolo>();
            foreach (var item in lstArt)
            {
                lst.Add(item);
            }
            return lst;
        });

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }
    }
}
