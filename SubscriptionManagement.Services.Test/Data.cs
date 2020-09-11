using SubscriptionManagement.Core.Enums;
using SubscriptionManagement.Domains.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Services.Test
{
    class Data
    {
        public static User[] Users()
        {

            return new[]
            {

                new User
                {
                    Id = new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39"), // For a user which fulfills all system requirements
                    Email = "javid@mail.com",
                    Password = "mFdxtcYpmVV5T/cXNFV+M7uNlRQ=", 
                    SubscriptionId=Guid.Parse("264badb0-913a-4a83-9193-276e12e48486"),
                    UserRole=UserRoleType.Member,
                    CreatedAt = new DateTime(2020, 1, 1),
                    ModifiedAt = new DateTime(2020, 1, 1)
                },

                new User
                {
                    Id = new Guid("685b4197-c2f4-4d75-a241-b8dc204e59bc"), // For a user who does not hava a subscription
                    Email = "john@mail.com",
                    Password = "mFdxtcYpmVV5T/cXNFV+M7uNlRQ=", 
                    SubscriptionId=null,
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
        }

        public static Book[] Books()
        {
            return new[]
            {
               new Book
                {
                    BookName="To Kill a Mockingbird",
                    Id=new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"),
                    CatalogId=Guid.Parse("ac06b5ad-af65-435c-bb49-4adb5668fd67"),
                    Price=25
                },
                new Book
                {
                    BookName="The Boy, the Mole, the Fox and the Horse",
                    Id=new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"),
                    CatalogId=Guid.Parse("ac06b5ad-af65-435c-bb49-4adb5668fd67"),
                    Price=30
                },

                new Book
                {
                    BookName="Brazen and the Beast",
                    Id=new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"),
                    CatalogId=Guid.Parse("35ad6824-3027-4721-8c8d-9048a5bd6ebd"),
                    Price=40
                }
            };
            ;
        }

        public static UserBook[] UserBooks()
        {
            return new[]
            {
               new UserBook
                {

                    BookId=Guid.Parse("484c2b84-2644-4b55-8f64-27d643286b7a"),
                    SubscriptionId=null,
                    UserId=Guid.Parse("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39")
                },

               new UserBook
                {
                    BookId=Guid.Parse("ca55d80e-5625-4258-94b6-a79278432a5b"),
                    SubscriptionId=Guid.Parse("264badb0-913a-4a83-9193-276e12e48486"),
                    UserId=Guid.Parse("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39")
                }
            };
        }
    }
}
