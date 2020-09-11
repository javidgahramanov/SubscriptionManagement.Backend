using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.WebApi.ViewModels.Responses.Subscription
{
    public class SubscriptionPlanResponse
    {
        public Guid Id { get; set; }
        public string SubscriptionName { get; set; }
    }
}
