using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Castle.Core.Logging;

namespace Ciccio1.Infrastructure.Persistence.Nhb
{
    class UnitOfWorkNhb : IUnitOfWork
    {
        ISession session;
        internal UnitOfWorkNhb(ISession session)
        {
            this.session = session;
        }       
        public void Dispose()
        {
            if (session != null)
            {
                try
                {
                    session.Close();
                    session.Dispose();
                    session = null;
                }
                catch (Exception ex)
                {
                    throw new HibernateException("Unable to close orphaned session", ex);
                }
            }
        }
    }

    class UnitOfWorkTransNhb : IUnitOfWorkTrans
    {
        ILogger logger;
        ISession session;
        internal UnitOfWorkTransNhb(ISession session)
        {
            //this.logger = logger;
            this.session = session;       
        }
        public void Commit()
        {
            session.Transaction.Commit();
        }
        public void Rollback()
        {
            session.Transaction.Rollback();
        }

        public void Dispose()
        {
            //logger.Debug("rollback Transaction");
            if (session != null)
            {
                try
                {
                    if (session.Transaction != null)
                    {
                        try
                        {
                            //if (session.Transaction.IsActive)
                            //{
                            //    session.Transaction.Rollback();
                            //}
                            session.Transaction.Dispose();
                        }
                        catch (Exception ex)
                        {
                            throw new HibernateException("Unable to rollback transaction for orphaned session", ex);
                        }
                    }
                    session.Close();
                    session.Dispose();
                    session = null;
                }
                catch (Exception ex)
                {
                    throw new HibernateException("Unable to close orphaned session", ex);
                }
            }
        }
    }


    //class UnitOfWorkFactoryNhb : IUnitOfWorkFactoryNhb
    //{
    //    ISessionFactory sessionFactory = null;
    //    ILogger logger = null;
    //    ISession session = null;
    //    IUnitOfWorkNhb uowNhb;

    //    public UnitOfWorkFactoryNhb(ISessionFactory sessionFactory, ILogger logger)
    //    {
    //        this.sessionFactory = sessionFactory;
    //        this.logger = logger;
    //        this.logger.Debug("UnitOfWorkNhb creata");
    //    }


    //    public ISession ISession
    //    {
    //        get
    //        {
    //            //if (session == null) throw new Exception("UnitOfWork non avviata");
    //            //return session;
    //            return uowNhb.ISession;
    //        }
    //    }


    //    //public bool IsInActive
    //    //{
    //    //    get
    //    //    {
    //    //        return session.Transaction != null && session.Transaction.IsActive;
    //    //    }
    //    //}

    //    //public void Begin()
    //    //{
    //    //    Rollback();
    //    //    session = sessionFactory.OpenSession();
    //    //    session.FlushMode = FlushMode.Commit;
    //    //    session.BeginTransaction();
    //    //    logger.Debug("begin Transaction");
    //    //}

    //    //public void Commit()
    //    //{
    //    //    logger.Debug("commit Transaction");
    //    //    if (session != null && session.Transaction != null && session.Transaction.IsActive)
    //    //    {
    //    //        try
    //    //        {
    //    //            session.Transaction.Commit();
    //    //        }
    //    //        catch (HibernateException ex)
    //    //        {
    //    //            Rollback();
    //    //            throw ex;
    //    //        }
    //    //        catch(Exception ex)
    //    //        {
    //    //            throw ex;
    //    //        }
    //    //    }
    //    //    else throw new Exception("Transaction non Aperta");
    //    //}

    //    void Rollback()
    //    {
    //        logger.Debug("rollback Transaction");
    //        if (session != null)
    //        {
    //            try
    //            {
    //                if (session.Transaction != null)
    //                {
    //                    try
    //                    {
    //                        if (session.Transaction.IsActive)
    //                        {
    //                            session.Transaction.Rollback();
    //                        }
    //                        session.Transaction.Dispose();
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        throw new HibernateException("Unable to rollback transaction for orphaned session", ex);
    //                    }
    //                }
    //                session.Close();
    //                session.Dispose();
    //                session = null;
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new HibernateException("Unable to close orphaned session", ex);
    //            }
    //        }
    //    }


    //    #region IDisposable Support
    //    private bool disposedValue = false; // Per rilevare chiamate ridondanti

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)
    //        {
    //            if (disposing)
    //            {
    //                Rollback();
    //            }
    //            disposedValue = true;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        logger.Debug("Dispose UnitOfWorkNhb");
    //        Dispose(true);
    //    }

    //    #endregion


    //    public IUnitOfWorkTrans CreateUnitOfWorkTrans()
    //    {
    //        ISession session = sessionFactory.OpenSession();
    //        session.FlushMode = FlushMode.Commit;
    //        session.BeginTransaction();
    //        UnitOfWorkTransNhb suca = new UnitOfWorkTransNhb(session);
    //        uowNhb = suca;
    //        return suca;
    //    }

    //    public IUnitOfWork CreateUnitOfWork()
    //    {
    //        ISession session = sessionFactory.OpenSession();
    //        //session.FlushMode = FlushMode.Commit;
    //        //session.BeginTransaction();
    //        UnitOfWorkNhb suca = new UnitOfWorkNhb(session);
    //        uowNhb = suca;
    //        return suca;
    //    }
    //}


}
