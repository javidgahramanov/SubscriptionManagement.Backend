using System;

namespace SubscriptionManagement.Domains.Entities.Base
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}