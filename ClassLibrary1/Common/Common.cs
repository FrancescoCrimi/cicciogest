using CiccioGest.Infrastructure.DomainBase;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.Common
{
    [Serializable]
    public class DomainEntity : Entity<int> { }

    [Serializable]
    public class DomainValueObject : ValueObject<int> { }

    public interface IDomainRepository<TEntity> : IEntityRepository<TEntity, int>
        where TEntity : DomainEntity
    { }
}
