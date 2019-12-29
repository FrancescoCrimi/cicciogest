using CiccioGest.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Memory.Repository
{
    internal abstract class DomainRepository<TEntity>
        : IDomainRepository<TEntity> where TEntity : DomainEntity
    {
        protected static IList<TEntity> entities = new List<TEntity>();

        public DomainRepository()
        {
        }

        public Task Delete(int id)
        {
            return Task.Run(() =>
            {
                var asd = entities.First(fa => fa.Id == id);
                if (asd != null) entities.Remove(asd);
            });
        }

        public Task<TEntity> GetById(int id)
        {
            return Task.Run(() => entities.First(fa => fa.Id == id));
        }

        public Task<int> Save(TEntity entity)
        {
            return Task.Run(() =>
            {
                entity = AddId(entity);
                entities.Add(entity);
                return entity.Id;
            });
        }

        public Task Update(TEntity entity)
        {
            return Task.Run(() =>
            {
                var old = entities.First(fa => fa.Id == entity.Id);
            });
        }

        protected TEntity AddId(TEntity entity)
        {
            entity.GetType().GetProperty("Id").SetValue(entity, entities.Count + 1);
            return entity;
        }
    }
}
