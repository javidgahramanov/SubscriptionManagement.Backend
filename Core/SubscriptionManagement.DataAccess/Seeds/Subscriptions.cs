using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.Domains.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.DataAccess.Seeds
{
    public static class Subscriptions
    {
        public static Subscription[] PopulateSubscriptions(this ModelBuilder modelBuilder)
        {
            var result = new[]
            {
                new Subscription
                {
                    Id = new Guid("264badb0-913a-4a83-9193-276e12e48486"),
                    SubscriptionName="Standart",
                    CreatedAt = new DateTime(2020, 1, 1),
                    ModifiedAt = new DateTime(2020, 1, 1)
                },
                 new Subscription
                {
                    Id = new Guid("d1c05ba7-cc98-4842-83f3-9d160a970ab4"),
                    SubscriptionName="Silver",
                    CreatedAt = new DateTime(2020, 1, 1),
                    ModifiedAt = new DateTime(2020, 1, 1)
                },

                  new Subscription
                {
                    Id = new Guid("5fd8c947-ef44-4bec-a38d-72fef313394a"),
                    SubscriptionName="Gold",
                    CreatedAt = new DateTime(2020, 1, 1),
                    ModifiedAt = new DateTime(2020, 1, 1)
                }
            };

            modelBuilder.Entity<Subscription>().HasData(result);

            return result;
        }
    }
}