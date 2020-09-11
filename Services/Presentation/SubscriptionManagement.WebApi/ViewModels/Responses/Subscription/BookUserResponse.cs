using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.WebApi.ViewModels.Responses.Subscription
{
    public class BookUserResponse
    {
        public Guid SubscriptionId { get; set; }
        public string BookName { get; set; }
        public string SubscriptionName { get; set; }
    }
}
