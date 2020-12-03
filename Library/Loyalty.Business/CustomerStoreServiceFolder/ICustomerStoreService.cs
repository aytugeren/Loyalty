using Loyalty.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.CustomerStoreServiceFolder
{
    public interface ICustomerStoreService
    {
        CustomerStoreDTO GetById(Guid id);

        void DeleteCustomerStore(CustomerStoreDTO customerStore);

        List<CustomerStoreDTO> GetAllCustomerStores();

        void InsertCustomerStore(CustomerStoreDTO customerStore);

        void UpdateCustomerStore(CustomerStoreDTO customerStore);
    }
}
