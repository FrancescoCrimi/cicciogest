// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Magazzino
{
    public interface IArticoloRepository : IDomainRepository<Articolo>, IDisposable
    {
        Task<IList<Articolo>> GetAll();
    }
}
