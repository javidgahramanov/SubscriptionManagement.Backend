using AutoMapper;

using SubscriptionManagement.Service.Implementation;
using SubscriptionManagement.WebApi.Mapper;

namespace SubscriptionManagement.WebApi
{
    public static class MapperProfiles
    {
        public static void UseWebApiProfiles(this IMapperConfigurationExpression config)
        {
            config.AddProfile<UserProfiles>();
            config.AddProfile<SubscriptionProfile>();
            config.AddProfile<BookProfile>();
            config.UseServiceProfiles();
        }
    }
}