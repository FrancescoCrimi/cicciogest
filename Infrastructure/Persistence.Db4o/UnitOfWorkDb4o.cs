﻿using Castle.Core.Logging;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Db4o
{
    class UnitOfWorkDb4o : IUnitOfWork
    {
        private ILogger logger;
        private IExtObjectContainer extObjectContainer;
        private IObjectContainer objectContainer;

        public UnitOfWorkDb4o(ILogger logger, UnitOfWorkFactoryDb4o unitOfWorkFactory)
        {
            this.logger = logger;
            extObjectContainer = unitOfWorkFactory.ObjectContainer;
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        internal IObjectContainer ObjectContainer
        {
            get
            {
                if(objectContainer == null)
                    objectContainer = extObjectContainer.OpenSession();
                return objectContainer;
            }
        }

        public void Commit()
        {
            try
            {
                objectContainer.Commit();
            }
            catch (Exception ex)
            {
                objectContainer.Rollback();
                throw ex;
            }
        }

        public void Rollback()
        {
            objectContainer.Rollback();
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
