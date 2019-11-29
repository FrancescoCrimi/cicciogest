using CiccioGest.Domain.Common;
using CiccioGest.Infrastructure.DomainBase;
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
         : IDomainRepository<TEntity> where TEntity : DomainEntity
    {
        protected UnitOfWorkDb4o da;

        public DomainRepository(UnitOfWorkDb4o da)
        {
            this.da = da;
        }

        public async Task Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
                da.ObjectContainer.Delete(entity);
        }

        public async Task<TEntity> GetById(int id)
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

        public async Task<int> Save(TEntity entity)
        {
            da.ObjectContainer.Store(entity);
            return entity.Id;
        }

        public async Task Update(TEntity entity)
        {
            da.ObjectContainer.Store(entity);
        }
    }
}
