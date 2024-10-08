﻿// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;
using System;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal abstract class DomainRepository<TEntity>
        : IDomainRepository<TEntity> where TEntity : DomainEntity
    {
        protected readonly ILogger logger;
        protected readonly UnitOfWork unitOfWork;
        protected readonly ILiteCollection<TEntity> coll;

        public DomainRepository(ILogger logger, 
                                UnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            coll = unitOfWork.LiteDB.GetCollection<TEntity>();
        }

        public Task Delete(int id)
        {
            return Task.Run(() =>
            {
                coll.Delete(id);
            });
        }

        public Task<TEntity> GetById(int id)
        {
            return Task.Run(() =>
            {
                return coll.FindOne(ent => ent.Id == id);
            });
        }

        public Task<int> Save(TEntity entity)
        {
            return Task.Run(() =>
            {
                var id = coll.Insert(entity);
                return (int)id;
            });
        }

        public Task Update(TEntity entity)
        {
            return Task.Run(() =>
            {
                coll.Update(entity);
            });
        }
    }
}
