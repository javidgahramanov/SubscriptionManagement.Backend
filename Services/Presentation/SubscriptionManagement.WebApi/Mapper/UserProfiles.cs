using System;
using AutoMapper;

using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.Domains.Models.User;
using SubscriptionManagement.WebApi.ViewModels.Requests.Users;

namespace SubscriptionManagement.WebApi.Mapper
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<RegisterUserView, Register>();
            CreateMap<User, UserInfoView>();
             
        }
    }
}
