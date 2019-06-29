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
        ILogger logger;

        public UnitOfWorkNhb(UnitOfWorkFactoryNhb unitOfWorkFactory, ILogger logger)
        {
            this.sessionFactory = unitOfWorkFactory.SessionFactory();
            this.logger = logger;
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        internal ISession ISession
        {
            get
            {
                if (session == null)
                    startSession();
                return session;
            }
        }

        private void startSession()
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
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
