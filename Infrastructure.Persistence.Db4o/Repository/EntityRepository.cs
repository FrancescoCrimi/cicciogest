using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using CiccioGest.Domain;
using CiccioGest.Infrastructure.DomainBase;
using Castle.Core.Logging;

namespace CiccioGest.Infrastructure.Persistence.Db4o.Repository
{
    abstract class EntityRepository<TEntity, TId>
        : IEntityRepository<TEntity, TId> where TEntity : Entity<TEntity, TId>
    {
        protected DataAccess da;

        protected EntityRepository(DataAccess da)
        {
            this.da = da;
        }

        public IEnumerable<TEntity> GetAll()
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
