using CiccioGest.Domain.Common;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal abstract class DomainRepository<TEntity>
        : IDomainRepository<TEntity> where TEntity : DomainEntity
    {
        private readonly ILogger logger;
        protected readonly UnitOfWork unitOfWork;

        protected DomainRepository(ILogger logger,
                                   IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }


        public async Task<TEntity> GetById(int id)
        {
            return await unitOfWork.ISession.GetAsync<TEntity>(id);
        }

        public async Task<int> Save(TEntity entity)
        {
            var id = await unitOfWork.ISession.SaveAsync(entity);
            return (int)id;
        }

        public async Task Delete(int id)
        {
            var entity = await unitOfWork.ISession.GetAsync<TEntity>(id);
            if (entity != null)
                await unitOfWork.ISession.DeleteAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await unitOfWork.ISession.UpdateAsync(entity);
        }
    }
}
