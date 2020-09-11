using AutoMapper;

using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Domains.Models.User;

namespace SubscriptionManagement.Service.Implementation.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, Register>();
            CreateMap<Register, User>();
        }
    }
}