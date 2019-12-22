using System;

namespace CiccioGest.Infrastructure.Persistence.Memory
{
    internal class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
        }

        public void Commit()
        {
        }

        public void Dispose()
        {
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
