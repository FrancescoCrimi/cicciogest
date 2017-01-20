using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Ciccio1.Infrastructure;
using Ciccio1.Domain;
using Ciccio1.Infrastructure.DomainBase;
using NHibernate.Criterion;

namespace Ciccio1.Infrastructure.Persistence.Nhb.Repository
{
    abstract class DomainRepository<TEntity>
        : IDomainRepository<TEntity> where TEntity : DomainEntity<TEntity>
    {
        protected DataAccess da;

        protected DomainRepository(DataAccess da)
        {
            this.da = da;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                ICriteria criteria = da.ISession.CreateCriteria<TEntity>();
                return criteria.List<TEntity>();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                throw new DataAccessException("Suca Sql", ex);
            }
        }

        public TEntity Get(int id)
        {
            return da.ISession.Get<TEntity>(id);
        }

        public int Save(TEntity entity)
        {
           return (int) da.ISession.Save(entity);
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
