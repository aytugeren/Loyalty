using AutoMapper;
using Loyalty.Business.DTO;
using Loyalty.Core.Domain;
using Loyalty.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loyalty.Business.CustomerServiceFolder
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private LoyaltyDbContext _loyaltyDbContext;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> customerRepository, IMapper mapper, LoyaltyDbContext loyaltyDbContext)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
            this._loyaltyDbContext = loyaltyDbContext;
        }

        public void DeleteCustomer(CustomerDTO customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Parameter is null!");
            customer.IsDeleted = true;
            customer.IsActive = false;
            UpdateCustomer(customer);
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            var customeres = _customerRepository.GetAll();
            if (customeres == null)
                throw new ArgumentNullException("Parameter is null!");
            List<CustomerDTO> CustomerDTOs = new List<CustomerDTO>();
            foreach (var item in customeres)
            {
                CustomerDTOs.Add(_mapper.Map<CustomerDTO>(item));
            }
            return CustomerDTOs;
        }

        public CustomerDTO GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter is null");
            var customer = _customerRepository.GetById(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public void InsertCustomer(CustomerDTO customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Parameter is null");
            customer.Id = Guid.NewGuid();
            customer.CreatedTime = DateTime.Now;
            _customerRepository.Insert(_mapper.Map<Customer>(customer));
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Parameter is null");

            Customer c = new Customer();
            c.Id = customer.Id;
            c.Firstname = customer.Firstname;
            c.Surname = customer.Surname;
            c.Email = customer.Email;
            c.Age = customer.Age;
            c.Password = customer.Password;
            c.Point = customer.Point;
            c.UpdatedTime = DateTime.Now;
            c.CreatedTime = customer.CreatedTime;
            c.IsActive = customer.IsActive;
            c.IsDeleted = customer.IsDeleted;
            _loyaltyDbContext.tblCustomer.Update(c);
            _loyaltyDbContext.SaveChanges();
        }
    }
}
