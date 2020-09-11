using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Service.Contracts.Services.Base;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManagement.Service.Contracts.Services
{
    public interface IBookUSerSubscriptionService : ICrudService<UserBook>
    {
    }

    public interface ISubscriptionService : ICrudService<Subscription>
    {
    }

}
