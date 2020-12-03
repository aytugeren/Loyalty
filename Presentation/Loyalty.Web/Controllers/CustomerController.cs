using Loyalty.Business.CustomerServiceFolder;
using Loyalty.Business.DTO;
using Loyalty.Web.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IAuthenticationService _authenticationService;

        public CustomerController(ICustomerService customerService, IAuthenticationService authenticationService)
        {
            this._customerService = customerService;
            this._authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("GetCustomers")]
        public List<CustomerDTO> GetCustomers()
        {
            var customers = _customerService.GetAllCustomers();

            return customers;
        }

        [HttpPost]
        [Route("SignUp")]
        public bool SignUp(CustomerDTO customerDTO)
        {
            if (customerDTO == default(CustomerDTO))
                throw new ArgumentNullException("CustomerDTO");
            var IsUserValid = _authenticationService.IsUserValid(customerDTO);
            if (!IsUserValid)
            {
                _authenticationService.saveUser(customerDTO);
            }
            else
            {
                throw new Exception("Customer is Valid!");
            }

            return true;
        }

        [HttpPost]
        [Route("DeleteCustomer/{id}")]
        public bool DeleteCustomer(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Parameter is null!");
            }

            var customer = _customerService.GetById(id);
            if (customer != default(CustomerDTO))
            {
                _customerService.DeleteCustomer(customer);
                return true;
            }

            return false;
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public bool UpdateCustomer(CustomerDTO customer)
        {
            if (customer == default(CustomerDTO))
            {
                return false;
            }

            var customerInfo = _customerService.GetById(customer.Id);
            if (!String.IsNullOrEmpty(customer.Firstname))
            {
                customerInfo.Firstname = customer.Firstname;
            }
            if (!String.IsNullOrEmpty(customer.Lastname))
            {
                customerInfo.Lastname = customer.Lastname;
            }
            if (!String.IsNullOrEmpty(customer.Password))
            {
                customerInfo.Password = customer.Password;
            }
            if (customer.Point != 0)
            {
                customerInfo.Point = customer.Point;
            }
            if (!String.IsNullOrEmpty(customer.Email))
            {
                customerInfo.Email = customer.Email;
            }
            if (customer.IsActive == true)
            {
                customerInfo.IsActive = true;
            }
            if (customer.IsDeleted == false)
            {
                customerInfo.IsDeleted = false;
            }

            _customerService.UpdateCustomer(customerInfo);

            return true;
        }

        [HttpPost]
        [Route("GetCustomerById/{id}")]
        public CustomerDTO GetCustomerById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter is null");

            var customer = _customerService.GetById(id);
            return customer;
        }

        [HttpPost]
        [Route("UpdatePoint")]
        public CustomerDTO UpdatePointOfCustomer(AmountModel model)
        {
            if (model.Amount == 0 || model.CustomerId == Guid.Empty)
                throw new ArgumentNullException("Parameters are null!");

            var customer = _customerService.GetById(model.CustomerId);
            if(customer == default(CustomerDTO))
            {
                throw new ArgumentException("Wrong Id");
            }

            customer.Point += ((Math.Round(model.Amount, 2) / 100)) * model.Percent;
            UpdateCustomer(customer);
            return customer;
        }

      
    }
}
