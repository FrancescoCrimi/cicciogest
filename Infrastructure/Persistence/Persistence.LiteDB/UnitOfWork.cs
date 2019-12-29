using Castle.Core.Logging;
using LiteDB;
using System;

namespace CiccioGest.Infrastructure.Persistence.LiteDB
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger logger;
        private readonly UnitOfWorkFactory unitOfWorkFactory;

        public UnitOfWork(ILogger logger, UnitOfWorkFactory unitOfWorkFactory)
        {
            this.logger = logger;
            this.unitOfWorkFactory = unitOfWorkFactory;
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        internal LiteDatabase LiteDB => unitOfWorkFactory.LiteDB;


        public void Commit()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Commit");
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }

        public void Rollback()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Rollback");
        }
    }
}
