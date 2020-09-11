using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SubscriptionManagement.Core.Configs;

namespace SubscriptionManagement.WebApi.Host.Settings
{
    public static class OptionRegister
    {
        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection<ConnectionStrings>());
            services.Configure<ApplicationInfo>(configuration.GetSection<ApplicationInfo>());
            services.Configure<IdentitySettings>(configuration.GetSection<IdentitySettings>());
        }

        private static IConfigurationSection GetSection<T>(this IConfiguration configuration)
        {
            return configuration.GetSection(GetSectionName<T>());
        }

        private static string GetSectionName<T>()
        {
            return typeof(T).Name;
        }
    }
}
