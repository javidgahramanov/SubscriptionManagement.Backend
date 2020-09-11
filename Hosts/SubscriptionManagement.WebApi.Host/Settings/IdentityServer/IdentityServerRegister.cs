using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Options;

using SubscriptionManagement.Core.Configs;
using SubscriptionManagement.WebApi.Host.Settings.IdentityServer;

namespace SubscriptionManagement.WebApi.Host.Settings.IdentityServer
{
    public static class IdentityServerRegister
    {
        public static void ConfigureIdentityServer(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var settings = serviceProvider.GetRequiredService<IOptions<IdentitySettings>>();
            var config = new Config(settings.Value);

            services
                .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(config.Ids)
                .AddInMemoryApiResources(config.Apis)
                .AddInMemoryClients(config.Clients);

            var cors = new DefaultCorsPolicyService(new LoggerFactory(new []{new EventLogLoggerProvider() }).CreateLogger<DefaultCorsPolicyService>())
            {
                AllowAll = true
            };

            services.AddSingleton<ICorsPolicyService>(cors);
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();


            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.JwtBearerEvents = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        },
                    };

                    options.Authority = settings.Value.Authority;
                    options.ApiName = settings.Value.Audience;
                    options.RequireHttpsMetadata = false;
    
                });
        }
    }
}
