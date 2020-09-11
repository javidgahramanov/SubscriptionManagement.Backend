
using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.DataContracts.Contracts;

namespace SubscriptionManagement.DataAccess.Services
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly SubscriptionManagementDbContext _dbContext;

        public DbContextFactory(SubscriptionManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext GetContext()
        {
            return _dbContext;
        }
    }
}
