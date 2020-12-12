using Loyalty.Business.DTO;
using Loyalty.Business.OwnerServiceFolder;
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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        private readonly IAuthenticationOwnerService _authenticationOwnerService;

        public OwnerController(IOwnerService ownerService, IAuthenticationOwnerService authenticationOwnerService)
        {
            this._authenticationOwnerService = authenticationOwnerService;
            this._ownerService = ownerService;
        }

        [HttpPost]
        [Route("GetOwners")]
        public List<OwnerDTO> GetOwners()
        {
            var owners = _ownerService.GetAllOwners();
            return owners;
        }

        [HttpPost]
        [Route("SignUp")]
        public bool SignUp(OwnerDTO ownerDTO)
        {
            if (ownerDTO == default(OwnerDTO))
                throw new ArgumentNullException("OwnerDTO");
            var isUserValid = _authenticationOwnerService.IsUserValid(ownerDTO);
            if (!isUserValid)
            {
                _authenticationOwnerService.saveUser(ownerDTO);
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        [Route("IsOwnerValid")]
        public bool IsOwnerValid(OwnerDTO ownerDTO)
        {
            if (ownerDTO == default(OwnerDTO))
                return false;

            var isUserValid = _authenticationOwnerService.IsUserValid(ownerDTO);
            if (isUserValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteOwner/{id}")]
        public string DeleteOwner(Guid id)
        {
            if (id == Guid.Empty)
            {
                return "Id Bos Geliyor!";
            }
            var owner = _ownerService.GetById(id);
            if (owner != default(OwnerDTO))
            {
                _ownerService.DeleteOwner(owner);
                return "Deleted Process is done with successfuly!";
            }

            return "Error!";
        }

        [HttpPost]
        [Route("UpdateOwner")]
        public bool UpdateOwner(OwnerDTO owner)
        {
            if (owner == default(OwnerDTO))
            {
                return false;
            }

            var ownerInfo = _ownerService.GetById(owner.Id);
            if (!String.IsNullOrEmpty(owner.Firstname))
            {
                ownerInfo.Firstname = owner.Firstname;
            }
            if (!String.IsNullOrEmpty(owner.Surname))
            {
                ownerInfo.Surname = owner.Surname;
            }
            if (!String.IsNullOrEmpty(owner.Password))
            {
                ownerInfo.Password = owner.Password;
            }
            if (owner.Point != 0)
            {
                ownerInfo.Point = owner.Point;
            }
            if (!String.IsNullOrEmpty(owner.Email))
            {
                ownerInfo.Email = owner.Email;
            }
            if (owner.IsActive == true)
            {
                ownerInfo.IsActive = true;
            }
            if (owner.IsDeleted == false)
            {
                ownerInfo.IsDeleted = false;
            }

            _ownerService.UpdateOwner(ownerInfo);

            return true;
        }

        [HttpPost]
        [Route("GetOwnerById/{id}")]
        public OwnerDTO GetOwnerById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter is null");

            var owner = _ownerService.GetById(id);
            return owner;
        }

        [HttpPost]
        [Route("UpdatePoint")]
        public OwnerDTO UpdatePointOfOwner(AmountModel model)
        {
            if (model.Amount == 0 || model.CustomerId == Guid.Empty)
                throw new ArgumentNullException("Parameters are null!");

            var owner = _ownerService.GetById(model.CustomerId);
            if (owner == default(OwnerDTO))
            {
                throw new ArgumentException("Wrong Id");
            }

            //owner.Point += ((Math.Round(model.Amount, 2) / 100)) * model.Percent;
            //UpdateOwner(owner);
            return owner;
        }

    }
}
