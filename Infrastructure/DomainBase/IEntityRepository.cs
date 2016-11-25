using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciccio1.Infrastructure.DomainBase
{
    public interface IEntityRepository<TEntity> where TEntity : Entity<TEntity>
    {
        IList<TEntity> GetAll();
        TEntity Get(Guid id);
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
