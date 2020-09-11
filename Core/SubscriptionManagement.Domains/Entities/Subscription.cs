using SubscriptionManagement.Domains.Entities.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domains.Entities
{
    public class Subscription : AuditEntity
    {
        public string SubscriptionName { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
