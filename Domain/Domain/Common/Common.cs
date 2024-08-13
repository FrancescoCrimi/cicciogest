// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

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
