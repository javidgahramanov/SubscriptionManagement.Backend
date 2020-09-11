using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace SubscriptionManagement.WebApi.Host.Settings
{
    public static class SwaggerConfigure
    {
        private const string ApplicationName = "SubscriptionManagement.WebApi";

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(t => t.FullName);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ApplicationName, Version = "v1" });

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Add 'Bearer' prefix to the token",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });

                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.DescribeAllParametersInCamelCase();

            });
        }

        public static void InitSwagger(this IApplicationBuilder builder)
        {
            builder.UseSwagger();

            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
