using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Core.Domain
{
    public class Address : BaseEntity
    {
        public string Country { get; set; }
        public string County { get; set; }
        public string Neighboor { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
