using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure
{
    public interface IUnitOfWorkFactory : IDisposable
    {
        void CreateDataAccess();
        void VerifyDataAccess();
    }
}
