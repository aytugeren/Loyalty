using Loyalty.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.CustomerServiceFolder
{
    public interface ICustomerService
    {
        CustomerDTO GetById(Guid id);

        void DeleteCustomer(CustomerDTO customer);

        List<CustomerDTO> GetAllCustomers();

        int GetCustomersCount();
        void InsertCustomer(CustomerDTO customer);

        void UpdateCustomer(CustomerDTO customer);
    }
}
