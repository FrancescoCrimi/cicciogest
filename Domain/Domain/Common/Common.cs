using CiccioGest.Infrastructure.DomainBase;
using System;

namespace CiccioGest.Domain.Common
{
    public class DomainEntity : Entity<int> { }

    public class DomainValueObject : ValueObject<int> { }

    public interface IDomainRepository<TEntity> : IEntityRepository<TEntity, int>
        where TEntity : DomainEntity
    { }
}
