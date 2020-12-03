using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Core
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
