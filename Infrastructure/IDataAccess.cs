using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciccio1.Infrastructure
{
    public interface IDataAccess : IDisposable
    {
        //IUnitOfWork Sessione();
        void CreateDataAccess();
        void VerifyDataAccess();
        IUnitOfWork CreateUnitOfWork();
        //IUnitOfWork CreateUnitOfWork();
    }
}
