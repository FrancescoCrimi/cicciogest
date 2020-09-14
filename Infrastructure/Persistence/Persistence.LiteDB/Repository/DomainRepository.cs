using CiccioGest.Domain.Common;
using System;
using System.Threading.Tasks;
using LiteDB;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal abstract class DomainRepository<TEntity>
        : IDomainRepository<TEntity> where TEntity : DomainEntity
    {
        private readonly UnitOfWork unitOfWork;
        protected readonly ILiteCollection<TEntity> coll;

        public DomainRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            coll = unitOfWork.LiteDB.GetCollection<TEntity>();
        }

        public Task Delete(int id)
        {
            return Task.Run(() =>
            {
                coll.Delete(id);
            });
        }

        public Task<TEntity> GetById(int id)
        {
            return Task.Run(() =>
            {
                return coll.FindOne(ent => ent.Id == id);
            });
        }

        public Task<int> Save(TEntity entity)
        {
            return Task.Run(() =>
            {
                var id = coll.Insert(entity);
                return (int)id;
            });
        }

        public Task Update(TEntity entity)
        {
            return Task.Run(() =>
            {
                coll.Update(entity);
            });
        }
    }
}
