using Loyalty.Business.CustomerServiceFolder;
using Loyalty.Business.DTO;
using Loyalty.Core;
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
        public MVCResultModel<List<CustomerDTO>> GetCustomers()
        {
            var result = new MVCResultModel<List<CustomerDTO>>();
            var customers = _customerService.GetAllCustomers();
            int count = _customerService.GetCustomersCount();

            result.SetData(customers);
            result.SetCount(count);
            return result;
        }

        [HttpPost]
        [Route("SignUp")]
        public MVCResultModel<bool> SignUp(CustomerDTO customerDTO)
        {
            var result = new MVCResultModel<bool>();

            if (customerDTO == default(CustomerDTO))
                result.SetException(new ArgumentNullException());
            var IsUserValid = _authenticationService.IsUserValid(customerDTO);
            if (!IsUserValid)
            {
                _authenticationService.saveUser(customerDTO);
                result.SetData(true);
            }
            else
            {
                result.SetException(new Exception());
            }

            return result;
        }

        [HttpPost]
        [Route("DeleteCustomer/{id}")]
        public MVCResultModel<bool> DeleteCustomer(Guid id)
        {
            var result = new MVCResultModel<bool>();

            if (id == Guid.Empty)
            {
                result.SetException(new ArgumentNullException());
            }

            var customer = _customerService.GetById(id);
            if (customer != default(CustomerDTO))
            {
                _customerService.DeleteCustomer(customer);
                result.SetData(true);
            }
            else
            {
                result.SetException(new Exception());
            }

            return result;
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public MVCResultModel<bool> UpdateCustomer(CustomerDTO customer)
        {
            var result = new MVCResultModel<bool>();

            if (customer == default(CustomerDTO))
            {
                result.SetException(new ArgumentNullException());
            }
            try
            {
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
                result.SetData(true);
            }
            catch (Exception)
            {
                result.SetData(false);
                result.SetException(new Exception());
            }
            

            return result;
        }

        [HttpPost]
        [Route("GetCustomerById/{id}")]
        public MVCResultModel<CustomerDTO> GetCustomerById(Guid id)
        {
            var result = new MVCResultModel<CustomerDTO>();
            if (id == Guid.Empty)
            {
                result.SetException(new ArgumentNullException());
                return result;
            }
            try
            {
                var customer = _customerService.GetById(id);
                result.SetData(customer);
            }
            catch (Exception)
            {
                result.SetException(new Exception());
            }
            return result;
        }

        [HttpPost]
        [Route("UpdatePoint")]
        public MVCResultModel<CustomerDTO> UpdatePointOfCustomer(AmountModel model)
        {
            var result = new MVCResultModel<CustomerDTO>();
            if (model.Amount == 0 || model.CustomerId == Guid.Empty)
            {
                result.SetException(new ArgumentNullException());
                return result;
            }
            try
            {
                var customer = _customerService.GetById(model.CustomerId);
                if (customer == default(CustomerDTO))
                {
                    result.SetException(new NullReferenceException());
                    return result;
                }

                customer.Point += ((Math.Round(model.Amount, 2))) * model.Percent;
                UpdateCustomer(customer);
            }
            catch (Exception)
            {
                result.SetException(new Exception());
            }

            return result;
        }

      
    }
}
