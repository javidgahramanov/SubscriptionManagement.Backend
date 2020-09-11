using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SubscriptionManagement.Core.HttpContext;
using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Service.Contracts.Services;
using SubscriptionManagement.WebApi.Endpoints.Base;
using SubscriptionManagement.WebApi.ViewModels.Requests.Book;
using SubscriptionManagement.WebApi.ViewModels.Responses.Book;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManagement.WebApi.Endpoints
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class BookController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IBookUSerSubscriptionService _bookUSerSubscriptionService;

        public BookController(IMapper mapper, IRequestContextProvider requestContextProvider, IBookService bookService, IBookUSerSubscriptionService bookUSerSubscriptionService,
           IUserService userSerice) : base(mapper, requestContextProvider)
        {
            _userService = userSerice;
            _bookService = bookService;
            _bookUSerSubscriptionService = bookUSerSubscriptionService;
        }

        [HttpPost]
        public virtual async Task<IActionResult> AddBook([FromBody] CreateBookRequest createBookRequest)
        {

            var user = await _userService.GetUserInfo(RequestContextProvider.Context.UserName);

            var book = Mapper.Map<CreateBookResponse>(await _bookService.CreateAsync(Mapper.Map<Book>(createBookRequest)));


            await _bookUSerSubscriptionService.CreateAsync(new UserBook
            {
                BookId = book.Id,
                UserId = user.Id,
                OnSale = createBookRequest.OnSale,
                SubscriptionId = null
            });

            return Ok(book);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetBooks()
        {

            var user = await _userService.GetUserInfo(RequestContextProvider.Context.UserName);

            var result = await _bookUSerSubscriptionService.QueryAsync(c => c.UserId == user.Id, new[] { "Book" });
            var books = Mapper.Map<IEnumerable<GetUserBookResponse>>(result);

            return Ok(books);
        }

        [HttpGet("all")]
        public virtual async Task<IActionResult> GetAllBooks()
        {

            var result = await _bookService.QueryAsync(c => 1 == 1, new[] { "UserBook" });

            var books = Mapper.Map<IEnumerable<GetBookResponse>>(result);

            return Ok(books);
        }

        [HttpPost("remove-sale/{bookId}")]
        public virtual async Task<IActionResult> RemoveFromSale(Guid bookid)
        {
            var user = await _userService.GetUserInfo(RequestContextProvider.Context.UserName);
            var book = (await _bookUSerSubscriptionService.QueryAsync(c => c.BookId == bookid && c.UserId == user.Id)).FirstOrDefault();

            book.OnSale = false;
            await _bookUSerSubscriptionService.UpdateAsync(book);
            return Ok(Mapper.Map<GetUserBookResponse>(book));
        }

        [HttpPost("resale/{bookId}")]
        public virtual async Task<IActionResult> Resale(Guid bookid)
        {
            var user = await _userService.GetUserInfo(RequestContextProvider.Context.UserName);
            var book = (await _bookUSerSubscriptionService.QueryAsync(c => c.BookId == bookid && c.UserId == user.Id)).FirstOrDefault();

            book.OnSale = true;


            await _bookUSerSubscriptionService.UpdateAsync(book);

            return Ok(Mapper.Map<GetUserBookResponse>(book));
        }

        [HttpGet("checkowner/{bookId}")]
        public virtual async Task<IActionResult> CheckIfOwnerOfBook(Guid bookId)
        {
            var user = await _userService.GetUserInfo(RequestContextProvider.Context.UserName);

            var isOwnBook = await _bookUSerSubscriptionService.QueryAsync(c => c.BookId == bookId
            && c.UserId == user.Id
            && c.SubscriptionId == null);


            return Ok(isOwnBook.Count() > 0);
        }
        
    }
}
