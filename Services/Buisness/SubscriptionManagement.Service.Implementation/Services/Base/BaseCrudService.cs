﻿using System;
using System.Threading.Tasks;
using SubscriptionManagement.DataBase.Contracts.Services.Base;
using SubscriptionManagement.DataContracts.Contracts;
using SubscriptionManagement.Domains.Entities.Base;
using SubscriptionManagement.Service.Contracts.Services.Base;

namespace SubscriptionManagement.Service.Implementation.Services.Base
{
    public abstract class BaseCrudService<TEntity, TRepository> : BaseQueryService<TEntity, TRepository>, ICrudService<TEntity>
        where TEntity : class, IEntity
        where TRepository : ICrudRepository<TEntity>
    {
        public IUnitOfWorkFactory UnitOfWorkFactory { get; }

        protected BaseCrudService(IUnitOfWorkFactory unitOfWorkFactory, TRepository repository)
            : base(repository)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var dbEntity = await Repository.CreateAsync(entity);
                await uow.CommitAsync();
            }

            var result = await GetAsync(entity.Id);

            return result;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                await Repository.UpdateAsync(entity);
                await uow.CommitAsync();
            }

            return entity;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                await Repository.DeleteAsync(id);

                await uow.CommitAsync();
            }

            return await Task.Run(() => true);
        }
    }
}