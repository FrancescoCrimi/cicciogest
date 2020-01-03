using System;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        // void Begin();
        void Commit();
        Task CommitAsync();
        void Rollback();
    }
}
