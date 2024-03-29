﻿using Microsoft.Extensions.Logging;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger logger;
        private readonly ISessionFactory sessionFactory;
        private ISession session;

        public UnitOfWork(ILogger<UnitOfWork> logger,
                          IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.logger = logger;
            this.sessionFactory = ((UnitOfWorkFactory)unitOfWorkFactory).SessionFactory();
            logger.LogDebug("Created: " + GetHashCode().ToString());
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
            session.GetCurrentTransaction().Commit();
            DisposeSession();
            session.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await session.GetCurrentTransaction().RollbackAsync();
            DisposeSession();
            session.BeginTransaction();
        }

        public void Rollback()
        {
            session.GetCurrentTransaction().Rollback();
            DisposeSession();
            session.BeginTransaction();
        }

        private void DisposeSession()
        {
            if (session != null)
            {
                //try
                //{
                if (session.GetCurrentTransaction() != null)
                {
                    try
                    {
                        if (session.GetCurrentTransaction().IsActive)
                        {
                            session.GetCurrentTransaction().Rollback();
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
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
