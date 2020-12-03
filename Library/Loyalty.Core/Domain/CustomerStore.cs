using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Core.Domain
{
    public class CustomerStore : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid StoreId { get; set; }

        public Store Store { get; set; }
        public Customer Customer { get; set; }
    }
}
