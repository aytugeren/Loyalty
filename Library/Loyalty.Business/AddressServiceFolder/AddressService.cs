using AutoMapper;
using Loyalty.Business.DTO;
using Loyalty.Core.Domain;
using Loyalty.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.AddressServiceFolder
{
    public class AddressService : IAddressService
    {

        private readonly IRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IRepository<Address> addressRepository, IMapper mapper)
        {
            this._addressRepository = addressRepository;
            this._mapper = mapper;
        }


        public void DeleteAddress(AddressDTO address)
        {
            if (address == null)
                throw new ArgumentNullException("Parameter is null!");
            address.IsDeleted = true;
            address.IsActive = false;
            UpdateAddress(address);
        }

        public List<AddressDTO> GetAllAddresses()
        {
            var addresses = _addressRepository.GetAll();
            if (addresses == null)
                throw new ArgumentNullException("Parameter is null!");
            List<AddressDTO> AddressDTOs = new List<AddressDTO>();
            foreach(var item in addresses)
            {
                AddressDTOs.Add(_mapper.Map<AddressDTO>(item));
            }
            return AddressDTOs;
        }

        public AddressDTO GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter is null");
            var address = _addressRepository.GetById(id);
            return _mapper.Map<AddressDTO>(address);
        }

        public void InsertAddress(AddressDTO address)
        {
            if (address == null)
                throw new ArgumentNullException("Parameter is null");
            _addressRepository.Insert(_mapper.Map<Address>(address));
        }

        public void UpdateAddress(AddressDTO address)
        {
            if (address == null)
                throw new ArgumentNullException("Parameter is null");
            address.UpdatedTime = DateTime.Now;
            _addressRepository.Update(_mapper.Map<Address>(address));
        }
    }
}
