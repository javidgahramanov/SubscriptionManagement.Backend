using AutoMapper;

using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.WebApi.ViewModels.Responses.Subscription;


namespace SubscriptionManagement.WebApi.Mapper
{

    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<UserBook, BookUserResponse>()
                .ForMember(t => t.BookName, opt => opt.MapFrom(s => s.Book.BookName))
                .ForMember(t => t.SubscriptionName, opt => opt.MapFrom(s => s.Subscription.SubscriptionName));

            CreateMap<Subscription, SubscriptionPlanResponse>();
        }
    }
}
