using CiccioGest.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Infrastructure.DomainBase
{
    public interface IEntityRepository<TEntity, TId> where TEntity : Entity<TEntity, TId>
    {
        TEntity Get(TId id);
        int Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TId id);
    }
}
