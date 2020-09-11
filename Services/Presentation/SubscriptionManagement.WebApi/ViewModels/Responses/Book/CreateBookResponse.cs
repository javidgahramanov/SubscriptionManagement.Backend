using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.WebApi.ViewModels.Responses.Book
{
    public class CreateBookResponse
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public Guid CatalogId { get; set; }
        public decimal Price { get; set; }
    }
}
