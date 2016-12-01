﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Castle.Core.Logging;

namespace Ciccio1.Infrastructure.Persistence.Db4o
{

    class UnitOfWork : IUnitOfWork
    {
        private IObjectContainer container;
        //private ILogger logger;

        internal UnitOfWork(IObjectContainer container)
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
