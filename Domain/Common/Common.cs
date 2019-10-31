using CiccioGest.Infrastructure.DomainBase;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.Common
{
    [Serializable]
    [DataContract(Name = "DomainEntity", Namespace = "http://gest.cicciosoft.tk")]
    public class DomainEntity : Entity<int> { }

    [Serializable]
    [DataContract(Name = "DomainValueObject", Namespace = "http://gest.cicciosoft.tk")]
    public class DomainValueObject : ValueObject<int> { }

    public interface IDomainRepository<TEntity> : IEntityRepository<TEntity, int>
        where TEntity : DomainEntity
    { }
}
