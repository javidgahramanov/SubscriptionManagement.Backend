using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.WebApi.ViewModels.Requests.Book
{
    public class CreateBookRequest
    {
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public Guid CatalogId { get; set; }
    }
}
