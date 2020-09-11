
using SubscriptionManagement.DataBase.Contracts.Services.Base;
using SubscriptionManagement.Domains.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SubscriptionManagement.DataBase.Contracts.Services
{
    public interface IUserRepository : ICrudRepository<User>
    {
        Task<User> GetUserByName(string username);
        Task<IEnumerable<User>> GetUsers();
    }
}
