using Microsoft.EntityFrameworkCore;
using SubscriptionManagement.Domains.Entities;
using System;

namespace SubscriptionManagement.DataAccess.Seeds
{
    public static class UserBooks
    {
        public static UserBook[] PopulateBookUserSubscriptions(this ModelBuilder modelBuilder)
        {
            var result = new[]
           {
               new UserBook
                {
                    BookId=Guid.Parse("484c2b84-2644-4b55-8f64-27d643286b7a"),
                    SubscriptionId=Guid.Parse("264badb0-913a-4a83-9193-276e12e48486"),
                    UserId=Guid.Parse("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39")
                }
            };

            modelBuilder.Entity<UserBook>().HasData(result);
            return result;
        }
    }
}
