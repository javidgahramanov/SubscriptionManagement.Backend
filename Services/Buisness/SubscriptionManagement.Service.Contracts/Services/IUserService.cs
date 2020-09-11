using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Domains.Models.User;
using SubscriptionManagement.Service.Contracts.Services.Base;

namespace SubscriptionManagement.Service.Contracts.Services
{
    public interface IUserService : ICrudService<User>
    {
        Task<User> Register(Register register);
        Task<Claim[]> GetClaimsForUser(string userName);
        Task<bool> IsPasswordValid(string userName, string password);
        Task<User> GetUserInfo(string userName);
        Task<IEnumerable<User>> GetUsers();
    }
}
