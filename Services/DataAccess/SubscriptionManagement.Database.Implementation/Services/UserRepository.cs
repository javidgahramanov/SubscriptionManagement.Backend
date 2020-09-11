using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.DataContracts.Contracts;
using SubscriptionManagement.DataBase.Contracts.Services;
using SubscriptionManagement.Database.Implementation.Services.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SubscriptionManagement.Database.Implementation.Services
{
    public class UserRepository : BaseCrudRepository<User>, IUserRepository
    {
        public UserRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public Task<User> GetUserByName(string username)
        {
            return DbSet.FirstAsync(t => t.Email == username);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await DbSet.ToListAsync();
        }
    }
}
