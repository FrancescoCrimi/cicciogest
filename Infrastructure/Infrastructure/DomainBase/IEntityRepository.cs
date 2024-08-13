// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.DomainBase
{
    public interface IEntityRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        Task<TEntity> GetById(TId id);
        Task<TId> Save(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TId id);
    }
}
