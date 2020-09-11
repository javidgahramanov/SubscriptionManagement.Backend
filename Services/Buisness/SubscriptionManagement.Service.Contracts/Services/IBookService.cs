using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Service.Contracts.Services.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Service.Contracts.Services
{
    public interface IBookService : ICrudService<Book>
    {
    }
}
