﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.DTO
{
    public class StoreDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string Phone { get; set; }
        public int Point { get; set; }
        public decimal Threshold { get; set; }
        public Guid OwnerId { get; set; }

        public OwnerDTO Owner { get; set; }
        public virtual ICollection<CustomerStoreDTO> CustomerStores { get; set; }
    }
}
