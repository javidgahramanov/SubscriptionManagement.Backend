using AutoMapper;

using SubscriptionManagement.Service.Implementation.Mapper;

namespace SubscriptionManagement.Service.Implementation
{
    public static class MapperProfiles
    {
        public static void UseServiceProfiles(this IMapperConfigurationExpression config)
        {
            config.AddProfile<UserProfile>();
        }
    }
}