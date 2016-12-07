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
    abstract class EntityRepository<TEntity, TId>
        : IEntityRepository<TEntity, TId> where TEntity : Entity<TEntity, TId>
    {
        protected DataAccess da;

        protected EntityRepository(DataAccess da)
        {
            this.da = da;
        }

        public IList<TEntity> GetAll()
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

        public TEntity Get(TId id)
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
