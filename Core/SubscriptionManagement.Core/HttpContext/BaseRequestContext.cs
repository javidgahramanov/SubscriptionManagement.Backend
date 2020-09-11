using System;

using SubscriptionManagement.Core.Enums;


namespace SubscriptionManagement.Core.HttpContext
{
    public abstract class BaseRequestContext : IRequestContext
    {
        public Guid RequestId { get; protected set; }

        public string UserName { get; protected set; }
        public Guid? SubscriptionId { get; protected set; }
        public UserRoleType Role { get; set; }
    }
}