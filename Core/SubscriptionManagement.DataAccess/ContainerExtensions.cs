using CoreFlow.Core.HttpContext;

using Microsoft.Extensions.DependencyInjection;

using SubscriptionManagement.Core.HttpContext;
using SubscriptionManagement.DataAccess.Services;
using SubscriptionManagement.DataContracts.Contracts;

namespace SubscriptionManagement.DataAccess
{
    public static class ContainerExtensions
    {
        public static IServiceCollection UseUowServices(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            service.AddScoped<IDbContextFactory, DbContextFactory>();

            service.AddScoped<IRequestContext, HttpRequestContext>();
            service.AddScoped<IRequestContextProvider, HttpRequestContextProvider>();

            return service;
        }
    }
}
