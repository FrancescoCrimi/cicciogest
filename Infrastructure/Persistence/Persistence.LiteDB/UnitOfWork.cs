﻿using System;

namespace CiccioGest.Infrastructure.Persistence.LiteDB
{
    internal class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
