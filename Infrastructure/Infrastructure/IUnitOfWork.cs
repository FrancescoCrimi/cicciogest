// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
