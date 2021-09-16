using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Core.Domain
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string Phone { get; set; }
        public int Point { get; set; }
        public decimal Threshold { get; set; }
        public DateTime? ThresholdEndDate { get; set; }

        public Guid OwnerId { get; set; }

        public Owner Owner { get; set; }
        public virtual ICollection<CustomerStore> CustomerStores { get; set; }
    }
}
