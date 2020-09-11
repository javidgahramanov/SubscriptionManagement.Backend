using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SubscriptionManagement.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SubscriptionManagementDbContext>
    {
        public SubscriptionManagementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SubscriptionManagementDbContext>();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
#if DEBUG
            configuration.AddJsonFile($"appsettings.{environment}.json", optional: true);
#endif
            var config = configuration.Build();

            builder.UseSqlServer(config["ConnectionStrings:SubscriptionManagementDb"]);
            builder.EnableSensitiveDataLogging();

            return new SubscriptionManagementDbContext(builder.Options);
        }
    }
}