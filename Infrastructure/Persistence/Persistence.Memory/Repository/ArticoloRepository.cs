// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Memory.Repository
{
    internal class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository()
        {
        }

        public Task<IList<Articolo>> GetAll()
        {
            return Task.Run(() =>
            {
                IList<Articolo> list = new List<Articolo>();
                foreach (Articolo item in entities)
                {
                    list.Add(item);
                }
                return list;
            });
        }

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }
    }
}
