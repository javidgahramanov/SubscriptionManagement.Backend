using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.WebApi.ViewModels.Responses.Book
{
    public class GetUserBookResponse
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public Guid CatalogId { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public Guid BookUserId { get; set; }
        public Guid SubscriptionId { get; set; }
    }
}
