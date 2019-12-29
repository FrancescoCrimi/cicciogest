using CiccioGest.Domain.Common;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal abstract class DomainRepository<TEntity>
        : IDomainRepository<TEntity> where TEntity : DomainEntity
    {
        protected UnitOfWork unitOfWork;

        protected DomainRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public Task<TEntity> GetById(int id)
        {
            return unitOfWork.ISession.GetAsync<TEntity>(id);
        }

        public Task<int> Save(TEntity entity)
        {
            return Task.Run(() =>
            {
                var id = unitOfWork.ISession.Save(entity);
                return (int)id;
            });
        }

        public Task Delete(int id)
        {
            return Task.Run(() =>
            {
                var entity = unitOfWork.ISession.Get<TEntity>(id);
                if (entity != null)
                    unitOfWork.ISession.Delete(entity);
            });
        }

        public Task Update(TEntity entity)
        {
            //unitOfWork.ISession.Merge(entity);
            return unitOfWork.ISession.UpdateAsync(entity);
        }
    }
}
