using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

using SubscriptionManagement.Core.HttpContext;
using SubscriptionManagement.DataBase.Contracts.Services;
using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Service.Contracts.Services;
using SubscriptionManagement.Service.Contracts.Services.Base;
using SubscriptionManagement.Services.Test;
using SubscriptionManagement.WebApi.Endpoints;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManagement.Test.Services.Presentation
{
    [TestFixture]
    class BookService
    {
        private Mock<IBookUSerSubscriptionService> _bookUSerSubscriptionService;
        private Mock<ISubscriptionService> _subscriptionService;

        private Mock<IUserService> _userService;
        private Mock<IBookService> _bookService;
        private Mock<IMapper> _mapper;
        private Mock<IRequestContextProvider> _requestContextProvider;
        private BookController _bookController;
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

            _bookController = new BookController(_mapper.Object, _requestContextProvider.Object, _bookService.Object, _bookUSerSubscriptionService.Object, _userService.Object);

            CurrentUser = Data.Users()[0];
            Books = Data.Books();
            UserBooks = Data.UserBooks();


            _requestContextProvider.Setup(rq => rq.Context.UserName).Returns(CurrentUser.Email);
            _userService.Setup(rq => rq.GetUserInfo(CurrentUser.Email)).Returns(Task.FromResult(CurrentUser));



            _requestContextProvider.SetupGet(rq => rq.Context.SubscriptionId).Returns(CurrentUser.SubscriptionId.Value);
        }


        [Test]
        public async Task CheckIfOwnerOfBook_WhenBookIdHasValueAndSubscriptionIdIsNull_ShouldReturnTrue()
        {
            //arrange
            var expectedData = new List<UserBook>
            {
               new UserBook
                {

                    BookId=Guid.Parse("484c2b84-2644-4b55-8f64-27d643286b7a"),
                    SubscriptionId=null,
                    UserId=Guid.Parse("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39")
                }
            };

            _bookUSerSubscriptionService.Setup(x => x.QueryAsync(It.IsAny<Expression<Func<UserBook, bool>>>(), It.IsAny<string[]>())).ReturnsAsync(expectedData);

            // Act 
            var result = await _bookController.CheckIfOwnerOfBook(It.IsAny<Guid>()) as ObjectResult;

            //assert
            Assert.That(result.Value, Is.True);
        }


        [Test]
        public async Task CheckIfOwnerOfBook_When_ResultIsNull_ShouldReturnFalse()
        {
            //Arrange
            var expectedData = new List<UserBook> { };


            _bookUSerSubscriptionService.Setup(x => x.QueryAsync(It.IsAny<Expression<Func<UserBook, bool>>>(), It.IsAny<string[]>())).ReturnsAsync(expectedData);

            // Act 
            var result = await _bookController.CheckIfOwnerOfBook(It.IsAny<Guid>()) as ObjectResult;

            //assert
            Assert.That(result.Value, Is.False);

        }
    }
}
