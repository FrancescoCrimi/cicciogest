// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using LiteDB;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger logger;

        public UnitOfWork(ILogger<UnitOfWork> logger, UnitOfWorkFactory unitOfWorkFactory)
        {
            this.logger = logger;
            LiteDB = unitOfWorkFactory.LiteDB;
            var result = LiteDB.BeginTrans();
            if (!result)
            {
                LiteDB.Rollback();
                LiteDB.BeginTrans();
            }
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        internal LiteDatabase LiteDB { get; }

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
            try
            {
                LiteDB.Commit();
            }
            catch (Exception)
            {
                LiteDB.Rollback();
                LiteDB.BeginTrans();
                throw;
            }
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Commit");
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }

        public void Rollback()
        {
            LiteDB.Rollback();
            LiteDB.BeginTrans();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Rollback");
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }
    }
}
