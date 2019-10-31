using CiccioGest.Domain.Common;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Db4o.Repository
{
    class DomainRepository<TEntity>
         : IDomainRepository<TEntity> where TEntity : DomainEntity<TEntity>
    {
        protected UnitOfWorkDb4o da;

        public DomainRepository(UnitOfWorkDb4o da)
        {
            this.da = da;
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
                da.ObjectContainer.Delete(entity);
        }

        public TEntity Get(int id)
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
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            da.ObjectContainer.Store(entity);
        }
    }
}
