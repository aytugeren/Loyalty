using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.DTO
{
    public class CustomerDTO : BaseEntityDTO
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public decimal Point { get; set; }

        public virtual ICollection<AddressDTO> Addresses { get; set; }
        public virtual List<CustomerStoreDTO> CustomerStores { get; set; }
    }
}
