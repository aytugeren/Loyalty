using Loyalty.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.OwnerServiceFolder
{
    public interface IAuthenticationOwnerService
    {
        string HashPassword(string password);

        void saveUser(OwnerDTO ownerDTO);

        bool IsUserValid(OwnerDTO ownerDTO);
    }
}
