using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using SubscriptionManagement.Core.Configs;
using SubscriptionManagement.DataAccess;

namespace SubscriptionManagement.WebApi.Host.Settings
{
    public static class DbContextRegister
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbConnection = serviceProvider.GetRequiredService<IOptions<ConnectionStrings>>();

            services.AddDbContext<SubscriptionManagementDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(dbConnection.Value.SubscriptionManagementDb));

            services.UseUowServices();

            return services;
        }
    }
}
