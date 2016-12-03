using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciccio1.Infrastructure.DomainBase
{
    public interface IEntityRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        IList<TEntity> GetAll();
        TEntity Get(TId id);
        int Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
