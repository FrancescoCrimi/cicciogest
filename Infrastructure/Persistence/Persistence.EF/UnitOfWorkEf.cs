using Castle.Core.Logging;
using System;

namespace CiccioGest.Infrastructure.Persistence.EF
{
    class UnitOfWorkEf : IUnitOfWork
    {
        private ILogger logger;

        public UnitOfWorkEf(ILogger logger)
        {
            this.logger = logger;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
