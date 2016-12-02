using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciccio1.Infrastructure
{
    public interface IDataAccess : IDisposable
    {
        void CreateDataAccess();
        void VerifyDataAccess();
        void Begin();
        void Commit();
        void Rollback();
    }
}
