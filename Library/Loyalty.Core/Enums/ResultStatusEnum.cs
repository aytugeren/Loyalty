using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Core.Enums
{
    public enum ResultStatusEnum
    {
        Success = 1,
        UnSuccess = 2,
        ReturnToUrl = 6,
        Error = 3,
        Exception = 4,
        NoData = 5,
        Locked = 7,
        UnAuthorized = 99
    }
}
