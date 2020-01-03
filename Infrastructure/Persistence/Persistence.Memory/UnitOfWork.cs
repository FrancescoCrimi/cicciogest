using System;
using System.Threading.Tasks;

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
    }
}
