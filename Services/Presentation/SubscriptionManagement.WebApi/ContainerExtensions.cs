using Microsoft.Extensions.DependencyInjection;

using SubscriptionManagement.Service.Implementation;

namespace SubscriptionManagement.WebApi
{
    public static class ContainerExtensions
    {
        public static IServiceCollection UseWebApiServices(this IServiceCollection service)
        {
            service.UseServices();

            return service;
        }
    }
}
