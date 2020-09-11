
using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.Core.HttpContext;
using SubscriptionManagement.DataContracts.Contracts;

namespace SubscriptionManagement.DataAccess.Services
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContextFactory _dbContextFactory;

        private readonly IRequestContextProvider _httpContextProvider;

        public UnitOfWorkFactory(IDbContextFactory dbContextFactory, IRequestContextProvider httpContextProvider)
        {
            _dbContextFactory = dbContextFactory;
            _httpContextProvider = httpContextProvider;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_dbContextFactory, _httpContextProvider);
        }

        public void Rollback()
        {
            var dbContext = _dbContextFactory.GetContext();

            foreach (var dbEntityEntry in dbContext.ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }
    }
}