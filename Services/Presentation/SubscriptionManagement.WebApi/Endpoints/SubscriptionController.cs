using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SubscriptionManagement.Core.HttpContext;
using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Service.Contracts.Services;
using SubscriptionManagement.WebApi.Endpoints.Base;
using SubscriptionManagement.WebApi.ViewModels.Responses.Subscription;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManagement.WebApi.Endpoints
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class SubscriptionController : BaseController
    {
        private readonly IBookUSerSubscriptionService _bookUSerSubscriptionService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IUserService _userService;
        public SubscriptionController(IMapper mapper, IRequestContextProvider requestContextProvider,
            IBookUSerSubscriptionService bookUSerSubscriptionService, ISubscriptionService subscriptionService,
            IUserService userService) : base(mapper, requestContextProvider)
        {
            _bookUSerSubscriptionService = bookUSerSubscriptionService;
            _subscriptionService = subscriptionService;
            _userService = userService;
        }

        [HttpGet("books/{userId}")]
        public virtual async Task<IActionResult> GetSubscribedBooks(Guid userId)
        {
            var subscriptionId = RequestContextProvider.Context.SubscriptionId ?? null;

            if (subscriptionId == null)
            {
                return BadRequest("You don't have a subscription.");
            }

            var result = await _bookUSerSubscriptionService.QueryAsync(x => x.UserId == userId, new[] { "User", "Book", "Subscription" });
            var mapped = Mapper.Map<IEnumerable<BookUserResponse>>(result);

            return Ok(mapped);
        }

        [HttpPut("purchase/{subscriptionId}")]
        public virtual async Task<IActionResult> BuySubscription(Guid subscriptionId)
        {

            var user = await _userService.GetUserInfo(RequestContextProvider.Context.UserName);

            var userSubscriptionId = RequestContextProvider.Context.SubscriptionId;

            if (userSubscriptionId.HasValue && userSubscriptionId.Value == user.SubscriptionId)
            {
                return BadRequest("You have an active subscription.");
            }


            user.Id = user.Id;
            user.SubscriptionId = subscriptionId;

            await _userService.UpdateAsync(user);
            return Ok();
        }

        public async Task<bool> IsAlreadySubscribed(Guid bookId, Guid userId, Guid subscriptionId)
        {
            var checkSubscriptionOfBook = await _bookUSerSubscriptionService.CountAsync(c => c.BookId == bookId &&
             c.UserId == userId && c.SubscriptionId == subscriptionId);
            return checkSubscriptionOfBook > 0;
        }


        [HttpPost("subscribe/{bookId}")]
        public virtual async Task<IActionResult> SubscribeToBok(Guid bookId)
        {
            var subscriptionId = RequestContextProvider.Context.SubscriptionId ?? null;

            if (subscriptionId == null)
            {
                return BadRequest("You don't have a subscription.");
            }

            var user = await _userService.GetUserInfo(RequestContextProvider.Context.UserName);

            var isAlreadySubscribed = await IsAlreadySubscribed(bookId, user.Id, subscriptionId.Value);

            if (isAlreadySubscribed)
            {
                return BadRequest("You have already subscribed to this book.");
            }

            var result = await _bookUSerSubscriptionService.CreateAsync(new UserBook
            {
                BookId = bookId,
                UserId = user.Id,
                OnSale = false,
                SubscriptionId = Guid.Parse(RequestContextProvider.Context.SubscriptionId.ToString())
            });

            return Ok(result);
        }

        [HttpDelete("unsubscribe/{bookId}")]
        public virtual async Task<IActionResult> UnSubscribeFromBook(Guid bookId)
        {
            if (string.IsNullOrEmpty(RequestContextProvider.Context.SubscriptionId.ToString()))
            {
                return BadRequest("You don't have a subscription.");
            }

            var user = await _userService.GetUserInfo(RequestContextProvider.Context.UserName);

            var subscriptionToBook = (await _bookUSerSubscriptionService.QueryAsync(x => x.BookId == bookId && x.UserId == user.Id)).FirstOrDefault();

            await _bookUSerSubscriptionService.DeleteAsync(subscriptionToBook.Id);
            return NoContent();
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetSubscriptionPlans()
        {
            var user = await _userService.GetUserInfo(RequestContextProvider.Context.UserName);
            var result = Mapper.Map<IEnumerable<SubscriptionPlanResponse>>(await _subscriptionService.QueryAsync(c => 1 == 1));
            return Ok(result);
        }

    }
}
