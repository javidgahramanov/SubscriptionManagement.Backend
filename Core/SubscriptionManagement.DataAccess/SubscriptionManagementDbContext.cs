using System.Linq;

using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.DataAccess.Configuration;
using SubscriptionManagement.DataAccess.Seeds;
using SubscriptionManagement.Domains.Entities;

namespace SubscriptionManagement.DataAccess
{
    public class SubscriptionManagementDbContext : DbContext
    {
        public SubscriptionManagementDbContext(DbContextOptions<SubscriptionManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent Configuration
            modelBuilder.ConfigureUser();

            // SEEDS
            modelBuilder.PopulateUsers();
            modelBuilder.PopulateSubscriptions();
            modelBuilder.PopulateCatalogs();
            modelBuilder.PopulateBooks();
            modelBuilder.PopulateBookUserSubscriptions();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

    }
}
