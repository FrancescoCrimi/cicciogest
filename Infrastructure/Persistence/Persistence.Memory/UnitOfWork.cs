// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Memory
{
    internal class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
        }

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public Task BeginAsync()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }
    }
}
