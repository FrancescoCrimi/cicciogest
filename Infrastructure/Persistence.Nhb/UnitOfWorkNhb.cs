using Castle.Core.Logging;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    class UnitOfWorkNhb : IUnitOfWork
    {
        ISessionFactory sessionFactory;
        ISession session;
        ITransaction transaction;
        IStatelessSession statelessSession;
        ILogger logger;


        public UnitOfWorkNhb(UnitOfWorkFactoryNhb unitOfWorkFactory, ILogger logger)
        {
            this.sessionFactory = unitOfWorkFactory.SessionFactory();
            statelessSession = sessionFactory.OpenStatelessSession();
            this.logger = logger;
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " Created");
        }


        #region Proprietà Internal

        //internal ISession ISession
        //{
        //    get
        //    {
        //        if (session == null)
        //            startSession();
        //        return session;
        //    }
        //}

        internal IStatelessSession IStatelessSession
        {
            get
            {
                return statelessSession;
            }
        }

        internal ISession ISession
        {
            get
            {
                if (session != null)
                    return session;
                else
                {
                    Begin();
                    return session;
                }
            }
        }

        #endregion


        public void Begin()
        {
            disposeSession();
            session = sessionFactory.OpenSession();
            session.FlushMode = FlushMode.Commit;
            session.BeginTransaction();
        }

        public void Commit()
        {
            session.Transaction.Commit();
            disposeSession();
        }

        public void Rollback()
        {
            session.Transaction.Rollback();
        }

        private void disposeSession()
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
                            if (session.Transaction.IsActive)
                            {
                                session.Transaction.Rollback();
                            }
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

        public void Dispose()
        {
            logger.Debug(this.GetHashCode().ToString() + ":" + this.GetType().Name + " Disposed");
        }
    }
}
