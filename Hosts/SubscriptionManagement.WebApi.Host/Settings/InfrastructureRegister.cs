using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SubscriptionManagement.WebApi.Host.Settings
{
    public static class InfrastructureRegister
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = SetMapping();
            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(configuration);
            services.AddSingleton(mapperConfig);
            services.AddSingleton(mapper);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var serviceProvider = services.BuildServiceProvider();
        }

        private static MapperConfiguration SetMapping()
        {
            return new MapperConfiguration(UseMapping);
        }

        private static void UseMapping(IMapperConfigurationExpression config)
        {
            config.AddExpressionMapping();

            config.UseWebApiProfiles();

            config.ForAllMaps((obj, cfg) => cfg.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
        }
    }
}
