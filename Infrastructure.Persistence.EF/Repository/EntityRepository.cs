using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Infrastructure.Persistence.EF.Repository
{
    abstract class EntityRepository<TEntity, TId> 
        : IEntityRepository<TEntity, TId> where TEntity : Entity<TEntity, TId>
    {
        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TId id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
