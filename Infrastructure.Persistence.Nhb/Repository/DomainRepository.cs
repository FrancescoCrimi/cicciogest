using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CiccioGest.Domain.Repository;
using CiccioGest.Domain.Model;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    abstract class DomainRepository<TEntity>
        : IDomainRepository<TEntity> where TEntity : DomainEntity<TEntity>
    {
        protected DataAccess da;

        protected DomainRepository(DataAccess da)
        {
            this.da = da;
        }

        public TEntity Get(int id)
        {
            return da.ISession.Get<TEntity>(id);
        }

        public int Save(TEntity entity)
        {
            return (int)da.ISession.Save(entity);
        }

        public void Delete(TEntity entity)
        {
            da.ISession.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            da.ISession.Update(entity);
        }
    }
}
