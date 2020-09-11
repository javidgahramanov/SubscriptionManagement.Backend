using Microsoft.EntityFrameworkCore;
using SubscriptionManagement.Domains.Entities;
using System;


namespace SubscriptionManagement.DataAccess.Seeds
{
    public static class Books
    {
        public static Book[] PopulateBooks(this ModelBuilder modelBuilder)
        {
            var result = new[]
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

            modelBuilder.Entity<Book>().HasData(result);

            return result;
        }
    }
}
