using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciccio1.Infrastructure
{

    //public interface IUnitOfWork : IDisposable
    //{
    //}

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }

    //public interface IUnitOfWorkFactory : IDisposable
    //{
    //    //bool IsInActive { get; }
    //    //void Begin();
    //    //void Commit();
    //    //void Rollback();
    //    IUnitOfWorkTrans CreateUnitOfWorkTrans();
    //    IUnitOfWork CreateUnitOfWork();
    //}
}
