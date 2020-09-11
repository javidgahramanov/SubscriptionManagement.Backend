using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.Domains.Entities;

using System;


namespace SubscriptionManagement.DataAccess.Seeds
{
    public static class Catalogs
    {
        public static Catalog[] PopulateCatalogs(this ModelBuilder modelBuilder)
        {
            var result = new[]
            {
                new Catalog
                {
                    Id = new Guid("ac06b5ad-af65-435c-bb49-4adb5668fd67"),
                    CatalogName="Classics",
                    CreatedAt = new DateTime(2020, 1, 1),
                    ModifiedAt = new DateTime(2020, 1, 1)
                },

                 new Catalog
                {
                    Id = new Guid("35ad6824-3027-4721-8c8d-9048a5bd6ebd"),
                    CatalogName="Romance",
                    CreatedAt = new DateTime(2020, 1, 1),
                    ModifiedAt = new DateTime(2020, 1, 1)
                }
            };

            modelBuilder.Entity<Catalog>().HasData(result);

            return result;
        }
    }
}
