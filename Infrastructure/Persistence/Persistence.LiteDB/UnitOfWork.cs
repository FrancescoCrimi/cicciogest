using Castle.Core.Logging;
using LiteDB;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger logger;

        public UnitOfWork(ILogger logger, UnitOfWorkFactory unitOfWorkFactory)
        {
            this.logger = logger;
            LiteDB = unitOfWorkFactory.LiteDB;
            var result = LiteDB.BeginTrans();
            if (!result)
            {
                LiteDB.Rollback();
                LiteDB.BeginTrans();
            }
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        internal LiteDatabase LiteDB { get; }


        public void Commit()
        {
            try
            {
                LiteDB.Commit();
            }
            catch (Exception ex)
            {
                LiteDB.Rollback();
                LiteDB.BeginTrans();
                throw ex;
            }
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Commit");
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }

        public void Rollback()
        {
            LiteDB.Rollback();
            LiteDB.BeginTrans();
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Rollback");
        }
    }
}
