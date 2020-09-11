using SubscriptionManagement.Core.Enums;

using System;


namespace SubscriptionManagement.Core.HttpContext
{
    public interface IRequestContext
    {
        Guid RequestId { get; }

        string UserName { get; }

        Guid? SubscriptionId { get; }

        UserRoleType Role { get; set; }
    }
}