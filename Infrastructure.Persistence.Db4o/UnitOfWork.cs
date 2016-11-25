using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Castle.Core.Logging;

namespace Ciccio1.Infrastructure.Persistence.Db4o
{
    class UnitOfWorkDb4o : IUnitOfWork
    {
        private IObjectContainer container;
        //private ILogger logger;
        internal UnitOfWorkDb4o(IObjectContainer container)
        {
            this.container = container;
        }
        public void Dispose()
        {
            container.Rollback();
            container.Close();
            container.Dispose();
        }
    }

    class UnitOfWorkTransDb4o : IUnitOfWorkTrans
    {
        private IObjectContainer container;
        //private ILogger logger;

        //internal UnitOfWorkTransDb4o(IObjectContainer container, ILogger logger)
        internal UnitOfWorkTransDb4o(IObjectContainer container)
        {
            this.container = container;
            //this.logger = logger;
            //this.logger.Debug("SessioneDb4o Creata");
        }

        public void Commit()
        {
            try
            {
                container.Commit();
            }
            catch (Exception ex)
            {
                container.Rollback();
            }
        }

        public void Rollback()
        {
            container.Rollback();
        }

        public void Dispose()
        {
            container.Rollback();
            container.Close();
            container.Dispose();
        }
    }
}
