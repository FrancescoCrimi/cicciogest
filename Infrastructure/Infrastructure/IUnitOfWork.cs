using System;

namespace CiccioGest.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        // void Begin();
        void Commit();
        void Rollback();
    }
}
