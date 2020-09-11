using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SubscriptionManagement.Core.HttpContext;
using SubscriptionManagement.Service.Contracts.Services;
using SubscriptionManagement.WebApi.Endpoints.Base;
using SubscriptionManagement.Domains.Models.User;
using SubscriptionManagement.WebApi.ViewModels.Requests.Users;
using System.Collections.Generic;

namespace SubscriptionManagement.WebApi.Endpoints
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        public UsersController(IMapper mapper, IRequestContextProvider requestContextProvider,
            IUserService userService) : base(mapper, requestContextProvider)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public virtual async Task<IActionResult> Register([FromBody] RegisterUserView request)
        {
            var mappedRequest = Mapper.Map<Register>(request);

            var query = await _userService.Register(mappedRequest);
            return Ok(query);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetUsers()
        {
            var query = await _userService.GetUsers();
            var result = Mapper.Map<IEnumerable<UserInfoView>>(query);
            return Ok(result);
        }

        [HttpGet("{userName}")]
        public virtual async Task<IActionResult> GetUser([FromRoute] string userName)
        {
            var result = await _userService.GetUserInfo(userName);
            return Ok(result);
        }
    }
}
