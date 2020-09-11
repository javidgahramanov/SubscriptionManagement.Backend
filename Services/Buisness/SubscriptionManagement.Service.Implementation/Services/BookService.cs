using AutoMapper;
using SubscriptionManagement.DataBase.Contracts.Services;
using SubscriptionManagement.DataContracts.Contracts;
using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Service.Contracts.Services;
using SubscriptionManagement.Service.Implementation.Services.Base;


namespace SubscriptionManagement.Service.Implementation.Services
{
    public class BookService : BaseCrudService<Book, IBookRepository>, IBookService
    {
        private readonly IMapper _mapper;
        public BookService(IUnitOfWorkFactory unitOfWorkFactory, IBookRepository repository, IMapper mapper)
            : base(unitOfWorkFactory, repository)
        {
            _mapper = mapper;
        }
    }
}
