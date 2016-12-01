﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Ciccio1.Domain;
using Ciccio1.Infrastructure.DomainBase;
using Castle.Core.Logging;

namespace Ciccio1.Infrastructure.Persistence.Db4o.Repository
{
    abstract class EntityRepository<TEntity, TId>
        : IEntityRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        protected DataAccess da;

        protected EntityRepository(DataAccess da)
        {
            this.da = da;
        }

        public IList<TEntity> GetAll()
        {
            return da.ObjectContainer.Query<TEntity>();
        }

        public TEntity Get(TId id)
        {
            IQuery query = da.ObjectContainer.Query();
            query.Constrain(typeof(TEntity));
            query.Descend("id").Constrain(id);
            IObjectSet rst = query.Execute();
            if (rst.Count == 0)
                return null;
            else
                return (TEntity)rst.Next();
        }

        public TEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Save(TEntity entity)
        {
            da.ObjectContainer.Store(entity);
            return 0;
        }

        public void Delete(TEntity entity)
        {
            da.ObjectContainer.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            da.ObjectContainer.Store(entity);
        }
    }
}
