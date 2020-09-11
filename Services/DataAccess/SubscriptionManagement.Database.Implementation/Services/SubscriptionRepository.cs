using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.Database.Implementation.Services.Base;
using SubscriptionManagement.DataBase.Contracts.Services;
using SubscriptionManagement.DataContracts.Contracts;
using SubscriptionManagement.Domains.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManagement.Database.Implementation.Services
{
    public class SubScriptionRepository : BaseCrudRepository<Subscription>, ISubscriptionRepository
    {
        public SubScriptionRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }
       
    }
}
