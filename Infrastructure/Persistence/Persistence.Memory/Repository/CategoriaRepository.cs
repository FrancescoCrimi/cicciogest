// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Memory.Repository
{
    internal class CategoriaRepository : DomainRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository()
        {
        }

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }

        public Task<IList<Categoria>> GetAll()
        {
            return Task.Run(() =>
            {
                return entities;
            });
        }
    }
}
