using Loyalty.Business.AddressServiceFolder;
using Loyalty.Business.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpPost]
        [Route("GetAddressByCustomerId/{customerId}")]
        public List<AddressDTO> GetAddressByCustomerId(Guid CustomerId)
        {
            if (CustomerId == Guid.Empty)
            {
                throw new ArgumentNullException("Customer Id is null!");
            }

            var addresses = _addressService.GetAllAddresses().Where(x => x.CustomerId == CustomerId).ToList();
            return addresses;
        }

        public string DeleteAddress(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException("Parameter is null!");
            }

            var address = _addressService.GetById(id);
            if (address != default(AddressDTO))
            {
                _addressService.DeleteAddress(address);
                return "Address is Deleted successfully!";
            }
            return "Error!";
        }

        public string UpdateAddress(AddressDTO addressDTO)
        {
            if (addressDTO == default(AddressDTO))
            {
                return "Parameter is empty!";
            }

            var address = _addressService.GetById(addressDTO.Id);
            if (!String.IsNullOrEmpty(addressDTO.Country))
            {
                address.Country = addressDTO.Country;
            }
            if (!String.IsNullOrEmpty(addressDTO.County))
            {
                address.County = addressDTO.County;
            }
            if (!String.IsNullOrEmpty(addressDTO.Neighboor))
            {
                address.Neighboor = addressDTO.Neighboor;
            }
            if (!String.IsNullOrEmpty(addressDTO.Postcode))
            {
                address.Postcode = addressDTO.Postcode;
            }
            if (!String.IsNullOrEmpty(addressDTO.PhoneNumber))
            {
                address.PhoneNumber = addressDTO.PhoneNumber;
            }
            if (!String.IsNullOrEmpty(addressDTO.Name))
            {
                address.Name = addressDTO.Name;
            }
            if (!String.IsNullOrEmpty(addressDTO.Title))
            {
                address.Title = addressDTO.Title;
            }
            return "Update is done by successfully!";
        }

        public string InsertAddress(AddressDTO addressDTO)
        {
            if (addressDTO == default(AddressDTO))
            {
                return "Parameter is null!";
            }

            _addressService.InsertAddress(addressDTO);
            return "Insert Operation is Done Successfully!";
        }

    }
}
