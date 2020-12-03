using AutoMapper;
using Loyalty.Business.DTO;
using Loyalty.Core.Domain;
using Loyalty.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Loyalty.Business.CustomerServiceFolder
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string saltPassword = "encryptKey";
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IRepository<Customer> customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public string HashPassword(string password)
        {
            SHA1 encrypt = new SHA1CryptoServiceProvider();
            var encrypted = encrypt.ComputeHash(Encoding.UTF8.GetBytes(password + saltPassword));
            var sb = new StringBuilder(encrypted.Length * 2);
            foreach (byte b in encrypted)
            {
                sb.Append(b.ToString("x2"));
            }
            string encryptedPassword = sb.ToString();
            return encryptedPassword;
        }

        public bool IsUserValid(CustomerDTO customerDTO)
        {
            bool isValid = false;
            customerDTO.Password = HashPassword(customerDTO.Password);
            var result = _customerRepository.GetAll().FirstOrDefault(x => (x.Email.ToLower() == customerDTO.Email.ToLower()));
            if (result != null)
            {
                if (customerDTO.Email.Contains("@"))
                {
                    var customers = _customerRepository.GetById(customerDTO.Id);
                    isValid = true;
                }
                else
                {
                    throw new ArgumentNullException("CustomerDTO");
                }
            }
            return isValid;
        }

        public void saveUser(CustomerDTO customerDTO)
        {
            customerDTO.Password = HashPassword(customerDTO.Password);
            _customerRepository.Insert(_mapper.Map<Customer>(customerDTO));
        }
    }
}
