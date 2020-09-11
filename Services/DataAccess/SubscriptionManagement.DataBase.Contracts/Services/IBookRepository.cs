using SubscriptionManagement.DataBase.Contracts.Services.Base;
using SubscriptionManagement.Domains.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.DataBase.Contracts.Services
{
    public interface IBookRepository : ICrudRepository<Book>
    {
    }
}
