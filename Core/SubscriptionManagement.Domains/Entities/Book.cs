using SubscriptionManagement.Domains.Entities.Base;

using System;
using System.Collections.Generic;

namespace SubscriptionManagement.Domains.Entities
{
    public class Book : AuditEntity
    {
        public string BookName { get; set; }
        public Guid CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }
        public decimal Price { get; set; }
        public virtual UserBook UserBook { get; set; }
    }
}
