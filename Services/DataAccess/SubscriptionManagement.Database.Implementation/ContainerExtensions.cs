using Microsoft.Extensions.DependencyInjection;

using SubscriptionManagement.Database.Implementation.Services;
using SubscriptionManagement.DataBase.Contracts.Services;

namespace SubscriptionManagement.Database.Implementation
{
    public static class ContainerExtensions
    {
        public static IServiceCollection UseDatabase(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IBookUserSubscriptionRepository, BookUserSubscriptionRepository>();
            service.AddScoped<ISubscriptionRepository, SubScriptionRepository>();
            service.AddScoped<IBookRepository, BookRepository>();
            return service;
        }
    }
}
