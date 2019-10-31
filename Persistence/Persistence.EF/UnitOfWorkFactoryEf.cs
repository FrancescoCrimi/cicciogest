using Castle.Core.Logging;
using CiccioGest.Infrastructure.Conf;
using System;

namespace CiccioGest.Infrastructure.Persistence.EF
{
    class UnitOfWorkFactoryEf : IUnitOfWorkFactory
    {
        private ILogger logger;
        private IConf conf;
        private ModelContext context;

        public UnitOfWorkFactoryEf(ILogger logger, IConf conf)
        {
            this.conf = conf;
            this.logger = logger;
        }

        internal ModelContext Model
        {
            get
            {
                return context;
            }
        }

        public void CreateDataAccess()
        {
            throw new NotImplementedException();
        }

        public void VerifyDataAccess()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
