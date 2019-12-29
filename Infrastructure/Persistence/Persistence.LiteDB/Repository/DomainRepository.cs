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
        protected readonly LiteCollection<TEntity> coll;

        public DomainRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            coll = unitOfWork.LiteDB.GetCollection<TEntity>();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(int id) => Task.Run(() =>
        {
            return coll.FindOne(ent => ent.Id == id);
        });

        public Task<int> Save(TEntity entity) => Task.Run(() =>
        {
            var id = coll.Insert(entity);
            
            return (int)id;
        });


        public Task Update(TEntity entity) => Task.Run(() => coll.Update(entity));
    }
}
