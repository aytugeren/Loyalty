using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.DTO
{
    public class CustomerStoreDTO : BaseEntityDTO
    {
        public Guid CustomerId { get; set; }
        public Guid StoreId { get; set; }

        public StoreDTO Store { get; set; }
        public AddressDTO Customer { get; set; }
    }
}
