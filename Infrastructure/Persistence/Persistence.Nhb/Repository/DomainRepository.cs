// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    internal abstract class DomainRepository<TEntity>
        : IDomainRepository<TEntity> where TEntity : DomainEntity
    {
        protected readonly ILogger _logger;
        protected readonly UnitOfWork _unitOfWork;

        protected DomainRepository(ILogger logger,
                                   UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        public async Task<TEntity> GetById(int id)
        {
            return await _unitOfWork.Session.GetAsync<TEntity>(id);
        }

        public async Task<int> Save(TEntity entity)
        {
            var id = await _unitOfWork.Session.SaveAsync(entity);
            return (int)id;
        }

        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.Session.GetAsync<TEntity>(id);
            if (entity != null)
                await _unitOfWork.Session.DeleteAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _unitOfWork.Session.UpdateAsync(entity);
        }

    }
}
