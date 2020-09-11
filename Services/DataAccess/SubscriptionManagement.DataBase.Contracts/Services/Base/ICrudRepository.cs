using SubscriptionManagement.Domains.Entities.Base;
using System;
using System.Threading.Tasks;


namespace SubscriptionManagement.DataBase.Contracts.Services.Base
{
    public interface ICrudRepository<TEntity> : IQueryRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(Guid entityId);

        Task CreateBulkAsync(TEntity[] entities);
    }
}