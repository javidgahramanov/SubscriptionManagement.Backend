using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.Core.Enums;
using SubscriptionManagement.Domains.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.DataAccess.Seeds
{
    public static class Users
    {
        public static User[] PopulateUsers(this ModelBuilder modelBuilder)
        {
            var result = new[]
            {

                new User
                {
                    Id = new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39"),  
                    Email = "javid@mail.com",
                    Password = "mFdxtcYpmVV5T/cXNFV+M7uNlRQ=", // pwd is 1234567,
                    SubscriptionId=Guid.Parse("264badb0-913a-4a83-9193-276e12e48486"),
                    UserRole=UserRoleType.Member,
                    CreatedAt = new DateTime(2020, 1, 1),
                    ModifiedAt = new DateTime(2020, 1, 1)

                },

                new User
                {
                    Id = new Guid("685b4197-c2f4-4d75-a241-b8dc204e59bc"),
                    Email = "john@mail.com",
                    Password = "mFdxtcYpmVV5T/cXNFV+M7uNlRQ=", // pwd is 1234567
                    SubscriptionId=Guid.Parse("d1c05ba7-cc98-4842-83f3-9d160a970ab4"),
                    UserRole=UserRoleType.Member,
                    CreatedAt = new DateTime(2020, 1, 1),
                    ModifiedAt = new DateTime(2020, 1, 1)
                },
                 new User
                {
                    Id = new Guid("ebf0c1b9-3210-41c4-9765-fa2b805ca0f4"),
                    Email = "amanda@mail.com",
                    Password = "mFdxtcYpmVV5T/cXNFV+M7uNlRQ=", // pwd is 1234567
                    SubscriptionId=Guid.Parse("d1c05ba7-cc98-4842-83f3-9d160a970ab4"),
                    UserRole=UserRoleType.Reseller3rd,
                    CreatedAt = new DateTime(2020, 1, 1),
                    ModifiedAt = new DateTime(2020, 1, 1)
                }
            };

            modelBuilder.Entity<User>().HasData(result);

            return result;
        }
    }
}
