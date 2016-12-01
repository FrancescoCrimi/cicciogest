using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Castle.Core.Logging;

namespace Ciccio1.Infrastructure.Persistence.Nhb
{
    class UnitOfWork : IUnitOfWork
    {
        ILogger logger;
        ISession session;

        internal UnitOfWork(ISession session)
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
}
