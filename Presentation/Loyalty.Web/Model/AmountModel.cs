using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.Web.Model
{
    public class AmountModel
    {
        public decimal Amount { get; set; }
        public int Percent { get; set; }
        public Guid CustomerId { get; set; }
    }
}
