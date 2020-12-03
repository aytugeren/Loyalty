using Loyalty.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.AddressServiceFolder
{
    public interface IAddressService
    {
        AddressDTO GetById(Guid id);

        void DeleteAddress(AddressDTO address);

        List<AddressDTO> GetAllAddresses();

        void InsertAddress(AddressDTO address);

        void UpdateAddress(AddressDTO address);
    }
}
