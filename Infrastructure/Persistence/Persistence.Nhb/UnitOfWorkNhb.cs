using Castle.Core.Logging;
using NHibernate;
using System;
using System.Globalization;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    class UnitOfWorkNhb : IUnitOfWork
    {
        private readonly ILogger logger;
        private readonly ISessionFactory sessionFactory;
        private ISession session;

        public UnitOfWorkNhb(ILogger logger, UnitOfWorkFactoryNhb unitOfWorkFactory)
        {
            this.logger = logger;
            this.sessionFactory = unitOfWorkFactory.SessionFactory();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        internal ISession ISession
        {
            get
            {
                if (session == null)
                    StartSession();
                return session;
            }
        }

        private void StartSession()
        {
            DisposeSession();
            session = sessionFactory.OpenSession();
            session.FlushMode = FlushMode.Commit;
            session.BeginTransaction();
        }

        public void Commit()
        {
            session.Transaction.Commit();
            DisposeSession();
            session.BeginTransaction();
        }

        public void Rollback()
        {
            session.Transaction.Rollback();
            DisposeSession();
            session.BeginTransaction();
        }

        private void DisposeSession()
        {
            if (session != null)
            {
                //try
                //{
                if (session.Transaction != null)
                {
                    try
                    {
                        if (session.Transaction.IsActive)
                        {
                            session.Transaction.Rollback();
                        }
                        //session.Transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        throw new HibernateException("Unable to rollback transaction for orphaned session", ex);
                    }
                }
                //    session.Close();
                //    session.Dispose();
                //    session = null;
                //}
                //catch (Exception ex)
                //{
                //    throw new HibernateException("Unable to close orphaned session", ex);
                //}
            }
        }

        public void Dispose()
        {
            //    session.Close();
            //    session.Dispose();
            //    session = null;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
