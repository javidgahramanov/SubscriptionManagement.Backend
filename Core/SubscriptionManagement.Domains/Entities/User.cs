using System;
using System.Collections.Generic;

using SubscriptionManagement.Core.Enums;
using SubscriptionManagement.Domains.Entities.Base;

namespace SubscriptionManagement.Domains.Entities
{
    public class User : AuditEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public  Guid? SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }
        public  UserRoleType UserRole { get; set; }
        public bool IsReseller { get; set; }
        public virtual ICollection<UserBook> Books { get; set; }
    }
}
