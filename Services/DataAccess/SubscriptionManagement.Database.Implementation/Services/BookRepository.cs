using SubscriptionManagement.Database.Implementation.Services.Base;
using SubscriptionManagement.DataBase.Contracts.Services;
using SubscriptionManagement.DataContracts.Contracts;
using SubscriptionManagement.Domains.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Database.Implementation.Services
{
    public class BookRepository : BaseCrudRepository<Book>, IBookRepository
    {
        public BookRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }
    }
}
