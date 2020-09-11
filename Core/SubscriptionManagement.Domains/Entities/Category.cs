using SubscriptionManagement.Domains.Entities.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domains.Entities
{
    public class Catalog : AuditEntity
    {
        public string CatalogName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
