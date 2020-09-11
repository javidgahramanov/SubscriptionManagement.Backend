using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.Domains.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.DataAccess.Configuration
{
    public static class UserConfig
    {
        public static void ConfigureUser(this ModelBuilder builder)
        {
            builder.Entity<User>()
                 .HasOne(t => t.Subscription)
                 .WithMany(t => t.Users)
                 .HasForeignKey(t => t.SubscriptionId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserBook>()
                 .HasOne(sc => sc.User);
           
        }
    }
}
