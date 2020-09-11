using AutoMapper;

using SubscriptionManagement.DataBase.Contracts.Services;
using SubscriptionManagement.DataContracts.Contracts;
using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Service.Contracts.Services;
using SubscriptionManagement.Service.Implementation.Services.Base;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionManagement.Service.Implementation.Services
{
    public class BookUSerSubscriptionService : BaseCrudService<UserBook, IBookUserSubscriptionRepository>, IBookUSerSubscriptionService
    {
        private readonly IMapper _mapper;
        public BookUSerSubscriptionService(IUnitOfWorkFactory unitOfWorkFactory, IBookUserSubscriptionRepository repository, IMapper mapper)
            : base(unitOfWorkFactory, repository)
        {
            _mapper = mapper;
        }
    }


    public class SubscriptionService : BaseCrudService<Subscription, ISubscriptionRepository>, ISubscriptionService
    {
        private readonly IMapper _mapper;
        public SubscriptionService(IUnitOfWorkFactory unitOfWorkFactory, ISubscriptionRepository repository, IMapper mapper)
            : base(unitOfWorkFactory, repository)
        {
            _mapper = mapper;
        }

    }
}
