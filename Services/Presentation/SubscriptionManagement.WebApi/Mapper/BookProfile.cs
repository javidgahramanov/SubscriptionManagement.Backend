using AutoMapper;

using SubscriptionManagement.Domains.Entities;
using SubscriptionManagement.WebApi.ViewModels.Requests.Book;
using SubscriptionManagement.WebApi.ViewModels.Responses.Book;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.WebApi.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookRequest, Book>()
                 .ForMember(t => t.BookName, opt => opt.MapFrom(s => s.BookName))
                 .ForMember(t => t.Price, opt => opt.MapFrom(s => s.Price))
                 .ForMember(t => t.CatalogId, opt => opt.MapFrom(s => s.CatalogId));

            CreateMap<Book, CreateBookResponse>();

            CreateMap<UserBook, GetUserBookResponse>()
                 .ForMember(t => t.BookName, opt => opt.MapFrom(s => s.Book.BookName))
                 .ForMember(t => t.SubscriptionId, opt => opt.MapFrom(s => s.SubscriptionId))
                 .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Book.Id))
                 .ForMember(t => t.Price, opt => opt.MapFrom(s => s.Book.Price))
                 .ForMember(t => t.BookUserId, opt => opt.MapFrom(s => s.Id))
                 .ForMember(t => t.CatalogId, opt => opt.MapFrom(s => s.Book.CatalogId))
                 .ForMember(t => t.OnSale, opt => opt.MapFrom(s => s.OnSale)).ForAllOtherMembers(i => i.Ignore());


            CreateMap<Book, GetBookResponse>().ForMember(t => t.BookName, opt => opt.MapFrom(s => s.BookName))
                
                 .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                 .ForMember(t => t.Price, opt => opt.MapFrom(s => s.Price))
                 .ForMember(t => t.OnSale, opt => opt.MapFrom(s => s.UserBook.OnSale))
                 .ForMember(t => t.UserId, opt => opt.MapFrom(s => s.UserBook.UserId))
                 .ForMember(t => t.CatalogId, opt => opt.MapFrom(s => s.CatalogId)).ForAllOtherMembers(i => i.Ignore());

        }
    }
}
