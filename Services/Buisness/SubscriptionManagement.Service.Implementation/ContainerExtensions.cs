using Microsoft.Extensions.DependencyInjection;
using SubscriptionManagement.Database.Implementation;
using SubscriptionManagement.Service.Contracts.Services;
using SubscriptionManagement.Service.Implementation.Services;

namespace SubscriptionManagement.Service.Implementation
{
    public static class ContainerExtensions
    {
        public static IServiceCollection UseServices(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IPasswordService, PasswordService>();
            service.AddScoped<IBookUSerSubscriptionService, BookUSerSubscriptionService>();
            service.AddScoped<ISubscriptionService, SubscriptionService>();
            service.AddScoped<IBookService, BookService>();
            service.UseDatabase();

            return service;
        }
    }
}
