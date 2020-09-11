using SubscriptionManagement.Domains.Entities.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domains.Entities
{
    public class UserBook : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid? SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }

        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public bool OnSale { get; set; }
    }
}
