using SubscriptionManagement.DataBase.Contracts.Services.Base;
using SubscriptionManagement.Domains.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManagement.DataBase.Contracts.Services
{
    public interface ISubscriptionRepository : ICrudRepository<Subscription>
    {
      
    }
}
