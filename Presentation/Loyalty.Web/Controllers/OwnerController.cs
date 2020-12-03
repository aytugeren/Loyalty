using Loyalty.Business.OwnerServiceFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.Web.Controllers
{
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
    }
}
