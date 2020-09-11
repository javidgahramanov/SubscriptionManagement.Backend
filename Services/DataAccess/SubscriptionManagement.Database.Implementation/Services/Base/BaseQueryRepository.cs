using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.Core.Extensions;
using SubscriptionManagement.DataContracts.Contracts;
using SubscriptionManagement.Domains.Entities.Base;

namespace SubscriptionManagement.Database.Implementation.Services.Base
{
    public abstract class BaseQueryRepository<TEntity> : BaseRepository<TEntity> where TEntity : class, IEntity
    {
        protected BaseQueryRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }

        public virtual Task<TEntity[]> QueryAsync(Expression<Func<TEntity, bool>> filter = null, IEnumerable<string> includes = null)
        {
            return Task.FromResult(filter != null ? DbSetAsNoTracking.AddIncludes(includes).Where(filter).ToArray() : DbSetAsNoTracking.AddIncludes(includes).ToArray());
        }

        public virtual Task<int> QueryCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return Task.FromResult(filter != null ? DbSetAsNoTracking.Where(filter).Count() : 0);
        }

        public virtual ValueTask<TEntity> GetAsync(Guid entityId, IEnumerable<string> includes = null)
        {
            return DbSet.AddIncludes(includes).FindAsync(entityId);
        }

        public virtual Task<TEntity> FindAsync(Guid entityId, IEnumerable<string> includes = null)
        {
            return DbSet.AddIncludes(includes).AsNoTracking().FirstOrDefaultAsync(t=>t.Id == entityId);
        }
    }
}