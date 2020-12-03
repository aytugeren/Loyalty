using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.DTO
{
    public class AddressDTO : BaseEntityDTO
    {
        public string Country { get; set; }
        public string County { get; set; }
        public string Neighboor { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public Guid CustomerId { get; set; }

        public CustomerDTO customers { get; set; }
    }
}
