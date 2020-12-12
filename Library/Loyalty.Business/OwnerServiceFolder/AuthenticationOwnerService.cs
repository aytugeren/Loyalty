using AutoMapper;
using Loyalty.Business.DTO;
using Loyalty.Core.Domain;
using Loyalty.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Loyalty.Business.OwnerServiceFolder
{
    public class AuthenticationOwnerService : IAuthenticationOwnerService
    {
        private readonly string saltPassword = "encrpytKey";
        private readonly IRepository<Owner> _ownerRepository;
        private readonly IMapper _mapper;

        public AuthenticationOwnerService(IRepository<Owner> ownerRepository, IMapper mapper)
        {
            this._ownerRepository = ownerRepository;
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

        public bool IsUserValid(OwnerDTO ownerDTO)
        {
            bool isValid = false;
            ownerDTO.Password = HashPassword(ownerDTO.Password);
            var result = _ownerRepository.GetAll().FirstOrDefault(x => (x.Email.ToLower() == ownerDTO.Email.ToLower()));
            if (result != null)
            {
                if (ownerDTO.Email.Contains("@"))
                {
                    var customers = _ownerRepository.GetById(ownerDTO.Id);
                    isValid = true;
                }
                else
                {
                    throw new ArgumentNullException("CustomerDTO");
                }
            }
            return isValid;
        }

        public void saveUser(OwnerDTO ownerDTO)
        {
            ownerDTO.Password = HashPassword(ownerDTO.Password);
            _ownerRepository.Insert(_mapper.Map<Owner>(ownerDTO));
        }
    }
}
