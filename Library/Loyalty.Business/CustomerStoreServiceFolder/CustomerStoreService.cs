using AutoMapper;
using Loyalty.Business.DTO;
using Loyalty.Core.Domain;
using Loyalty.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.CustomerStoreServiceFolder
{
    public class CustomerStoreService : ICustomerStoreService
    {
        private readonly IRepository<CustomerStore> _customerStoreRepository;
        private readonly IMapper _mapper;

        public CustomerStoreService(IRepository<CustomerStore> customerStoreRepository, IMapper mapper)
        {
            this._customerStoreRepository = customerStoreRepository;
            this._mapper = mapper;
        }

        public void DeleteCustomerStore(CustomerStoreDTO customerStore)
        {
            if (customerStore == null)
                throw new ArgumentNullException("Parameter is null!");
            customerStore.IsDeleted = true;
            customerStore.IsActive = false;
            UpdateCustomerStore(customerStore);
        }

        public List<CustomerStoreDTO> GetAllCustomerStores()
        {
            var customerStorees = _customerStoreRepository.GetAll();
            if (customerStorees == null)
                throw new ArgumentNullException("Parameter is null!");
            List<CustomerStoreDTO> CustomerStoreDTOs = new List<CustomerStoreDTO>();
            foreach (var item in customerStorees)
            {
                CustomerStoreDTOs.Add(_mapper.Map<CustomerStoreDTO>(item));
            }
            return CustomerStoreDTOs;
        }

        public CustomerStoreDTO GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter is null");
            var customerStore = _customerStoreRepository.GetById(id);
            return _mapper.Map<CustomerStoreDTO>(customerStore);
        }

        public void InsertCustomerStore(CustomerStoreDTO customerStore)
        {
            if (customerStore == null)
                throw new ArgumentNullException("Parameter is null");
            _customerStoreRepository.Insert(_mapper.Map<CustomerStore>(customerStore));
        }

        public void UpdateCustomerStore(CustomerStoreDTO customerStore)
        {
            if (customerStore == null)
                throw new ArgumentNullException("Parameter is null");
            customerStore.UpdatedTime = DateTime.Now;
            _customerStoreRepository.Update(_mapper.Map<CustomerStore>(customerStore));
        }
    }
}
