using Loyalty.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.CustomerServiceFolder
{
    public interface IAuthenticationService
    {
        string HashPassword(string password);

        void saveUser(CustomerDTO customerDTO);

        bool IsUserValid(CustomerDTO customerDTO);
    }
}
