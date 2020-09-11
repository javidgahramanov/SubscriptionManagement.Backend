using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

using SubscriptionManagement.Core.HttpContext;
using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Service.Contracts.Services;
using SubscriptionManagement.Services.Test;
using SubscriptionManagement.WebApi.Endpoints;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManagement.Test.Services.Presentation
{
    [TestFixture]
    class SubscriptionControllerTests
    {
        private Mock<IBookUSerSubscriptionService> _bookUSerSubscriptionService;
        private Mock<ISubscriptionService> _subscriptionService;

        private Mock<IUserService> _userService;
        private Mock<IBookService> _bookService;
        private Mock<IMapper> _mapper;
        private Mock<IRequestContextProvider> _requestContextProvider;
        private SubscriptionController _subscriptionController;
        private User CurrentUser;
        private Book[] Books;
        private UserBook[] UserBooks;

        [SetUp]
        public void Setup()
        {
            _bookUSerSubscriptionService = new Mock<IBookUSerSubscriptionService>();
            _subscriptionService = new Mock<ISubscriptionService>();
            _bookService = new Mock<IBookService>();
            _userService = new Mock<IUserService>();
            _requestContextProvider = new Mock<IRequestContextProvider>();
            _mapper = new Mock<IMapper>();

            _subscriptionController = new SubscriptionController(_mapper.Object,
                _requestContextProvider.Object,
                _bookUSerSubscriptionService.Object,
                _subscriptionService.Object, _userService.Object);

        }

        [Test]
        public async Task GetSubscribedBooks_IfUserHasNoSubscription_ShouldReturnBadRequest()
        {
            // Arrange

            var user = Data.Users()[1];

            _requestContextProvider.Setup(rq => rq.Context.SubscriptionId).Returns(user.SubscriptionId ?? null);
            // Act 
            var result = await _subscriptionController.GetSubscribedBooks(It.IsAny<Guid>()) as ObjectResult;

            // Assert

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task BuySubscription_IfUserHasSubscription_ShouldReturnBadRequest()
        {
            // Arrange
            var user = Data.Users()[0];

            _requestContextProvider.Setup(rq => rq.Context.SubscriptionId).Returns(user.SubscriptionId);
            _userService.Setup(rq => rq.GetUserInfo(user.Email)).Returns(Task.FromResult(user));
            _requestContextProvider.Setup(rq => rq.Context.UserName).Returns(user.Email);

            // Act 
            var result = await _subscriptionController.BuySubscription(It.IsAny<Guid>()) as ObjectResult;

            // Assert

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }


        [Test]
        public async Task SubscribeToBok_IfUserAlreadySubscribedToBook_ShouldReturnBadRequest()
        {
            //arrange
            var user = Data.Users()[0];

            _requestContextProvider.Setup(rq => rq.Context.SubscriptionId).Returns(user.SubscriptionId);
            _userService.Setup(rq => rq.GetUserInfo(user.Email)).Returns(Task.FromResult(user));
            _requestContextProvider.Setup(rq => rq.Context.UserName).Returns(user.Email);

            _bookUSerSubscriptionService.Setup(x => x.CountAsync(It.IsAny<Expression<Func<UserBook, bool>>>())).ReturnsAsync(1);

            // Act 
            var result = await _subscriptionController.SubscribeToBok(It.IsAny<Guid>()) as ObjectResult;

            //Assert

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task SubscribeToBok_IfUserHasNoSubscription_ShouldReturnBadRequest()
        {
            //arrange
            var user = Data.Users()[1];

            _requestContextProvider.Setup(rq => rq.Context.SubscriptionId).Returns(user.SubscriptionId);
            _userService.Setup(rq => rq.GetUserInfo(user.Email)).Returns(Task.FromResult(user));
            _requestContextProvider.Setup(rq => rq.Context.UserName).Returns(user.Email);

            _bookUSerSubscriptionService.Setup(x => x.CountAsync(It.IsAny<Expression<Func<UserBook, bool>>>())).ReturnsAsync(0);

            // Act 
            var result = await _subscriptionController.SubscribeToBok(It.IsAny<Guid>()) as ObjectResult;

            //Assert

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
    }
}
