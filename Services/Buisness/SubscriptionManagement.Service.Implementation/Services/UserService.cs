using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.DataBase.Contracts.Services;
using SubscriptionManagement.Service.Contracts.Services;
using SubscriptionManagement.Core.Configs;
using SubscriptionManagement.DataContracts.Contracts;
using SubscriptionManagement.Domains.Models.User;
using SubscriptionManagement.Service.Implementation.Services.Base;
using SubscriptionManagement.Core.Constants;
using Newtonsoft.Json;

namespace SubscriptionManagement.Service.Implementation.Services
{
    public class UserService : BaseCrudService<User, IUserRepository>, IUserService
    {

        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IOptions<ApplicationInfo> _applicationInfo;
        public UserService(IUnitOfWorkFactory unitOfWorkFactory, IUserRepository repository,
            IConfiguration configuration, IPasswordService passwordService, IMapper mapper, IOptions<ApplicationInfo> applicationInfo) : base(unitOfWorkFactory, repository)
        {
            _passwordService = passwordService;

            _mapper = mapper;
            _applicationInfo = applicationInfo;

        }

        public async Task<User> Register(Register register)
        {
            using var uow = UnitOfWorkFactory.Create();
            register.Password = _passwordService.GeneratePassword(register.Password).hash;
            var mapping = _mapper.Map<User>(register);
            var createdUser = await Repository.CreateAsync(mapping);
            await uow.CommitAsync();
            return createdUser;
        }


        public async Task<bool> IsPasswordValid(string userName, string password)
        {
            var user = (await Repository.QueryAsync(t => t.Email == userName)).FirstOrDefault();

            if (user == null)
                return false;

            var result = _passwordService.IsHashValid(password, user.Password);

            return result;
        }

        public async Task<User> GetUserInfo(string userName)
        {
            var user = (await Repository.QueryAsync(t => t.Email == userName)).FirstOrDefault();
            return user;
        }


        public async Task<Claim[]> GetClaimsForUser(string userName)
        {
            var user = await Repository.GetUserByName(userName);

            return new[]
            {
                new Claim(JwtClaimTypes.Name, userName),
                new Claim(AppClaimTypes.SubscriptionId, user.SubscriptionId.ToString()),
                new Claim(JwtClaimTypes.Role, JsonConvert.SerializeObject(user.UserRole))

            };
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await Repository.GetUsers();
            return result;
        }
    }
}
