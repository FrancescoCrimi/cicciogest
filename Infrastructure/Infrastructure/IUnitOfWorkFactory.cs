using System;

namespace CiccioGest.Infrastructure
{
    public interface IUnitOfWorkFactory : IDisposable
    {
        void CreateDataAccess();
        void VerifyDataAccess();
    }
}
