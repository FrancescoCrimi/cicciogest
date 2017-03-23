using CiccioGest.Domain.Model;
using CiccioGest.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Repository
{
    public interface IDomainRepository<TEntity> : IEntityRepository<TEntity, int>
    where TEntity : DomainEntity<TEntity>
    {
    }
}
