using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    abstract class DomainRepository<TEntity>
        : IDomainRepository<TEntity> where TEntity : DomainEntity<TEntity>
    {
        protected UnitOfWorkNhb unitOfWork;

        protected DomainRepository(UnitOfWorkNhb unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public TEntity Get(int id)
        {
            return unitOfWork.ISession.Get<TEntity>(id);
        }

        public int Save(TEntity entity)
        {
            return (int)unitOfWork.ISession.Save(entity);
        }

        public void Delete(int id)
        {
            var entity = unitOfWork.ISession.Get<TEntity>(id);
            if (entity != null)
                unitOfWork.ISession.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            unitOfWork.ISession.Merge<TEntity>(entity);
            //unitOfWork.ISession.Update(entity);
        }
    }
}
