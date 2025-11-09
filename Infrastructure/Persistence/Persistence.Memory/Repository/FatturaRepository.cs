// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Documenti;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Memory.Repository
{
    internal class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository()
        {
        }

        public Task<IList<Fattura>> GetAll()
        {
            return Task.Run(() =>
            {
                IList<Fattura> list = new List<Fattura>();
                foreach (Fattura item in entities)
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
