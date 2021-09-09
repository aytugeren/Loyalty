using Loyalty.Business.DTO;
using Loyalty.Business.OwnerServiceFolder;
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
        public MVCResultModel<List<OwnerDTO>> GetOwners()
        {
            var result = new MVCResultModel<List<OwnerDTO>>();
            result.SetData(_ownerService.GetAllOwners());
            result.SetCount(_ownerService.GetOwnersCount());
            return result;
        }

        [HttpPost]
        [Route("SignUp")]
        public MVCResultModel<bool> SignUp(OwnerDTO ownerDTO)
        {
            var result = new MVCResultModel<bool>();
            if (ownerDTO == default(OwnerDTO))
                result.SetException(new ArgumentNullException());
            var isUserValid = _authenticationOwnerService.IsUserValid(ownerDTO);
            if (!isUserValid)
            {
                _ownerService.InsertOwner(ownerDTO);
                result.SetData(true);
            }
            else
            {
                result.SetException(new Exception());
                result.SetData(false);
            }

            return result;
        }

        [HttpPost]
        [Route("IsOwnerValid")]
        public MVCResultModel<OwnerDTO> IsOwnerValid(OwnerDTO ownerDTO)
        {
            var result = new MVCResultModel<OwnerDTO>();
            if (ownerDTO == default(OwnerDTO))
                result.SetException(new ArgumentNullException());

            var isUserValid = _authenticationOwnerService.IsUserValid(ownerDTO);
            var owner = _ownerService.GetOwnerWithEmail(ownerDTO.Email);
            if (isUserValid)
            {
                result.SetData(owner);
                result.SetCount(1);
            }
            else
            {
                result.SetException(new Exception());
            }

            return result;
        }

        [HttpPost]
        [Route("DeleteOwner/{id}")]
        public MVCResultModel<int> DeleteOwner(Guid id)
        {
            var result = new MVCResultModel<int>();
            if (id == Guid.Empty)
            {
                result.SetException(new ArgumentNullException());
            }
            var owner = _ownerService.GetById(id);
            if (owner != default(OwnerDTO))
            {
                result.SetData(_ownerService.DeleteOwner(owner));
            }
            else
            {
                result.SetException(new Exception());
            }

            return result;

        }

        [HttpPost]
        [Route("UpdateOwner")]
        public MVCResultModel<int> UpdateOwner(OwnerDTO owner)
        {
            var result = new MVCResultModel<int>();

            if (owner == default(OwnerDTO))
            {
                result.SetException(new ArgumentNullException());
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

            result.SetData(_ownerService.UpdateOwner(ownerInfo));
            return result;
        }

        [HttpPost]
        [Route("GetOwnerById/{id}")]
        public MVCResultModel<OwnerDTO> GetOwnerById(Guid id)
        {
            var result = new MVCResultModel<OwnerDTO>();

            if (id == Guid.Empty)
                result.SetException(new ArgumentNullException());
            var owner = _ownerService.GetById(id);
            result.SetData(owner);

            return result;
        }

        [HttpPost]
        [Route("UpdatePoint")]
        [Obsolete("Feature, maybe it can be added!")]
        public MVCResultModel<OwnerDTO> UpdatePointOfOwner(AmountModel model)
        {

            var result = new MVCResultModel<OwnerDTO>();
            if (model.Amount == 0 || model.CustomerId == Guid.Empty)
                throw new ArgumentNullException("Parameters are null!");

            var owner = _ownerService.GetById(model.CustomerId);
            if (owner == default(OwnerDTO))
            {
                throw new ArgumentException("Wrong Id");
            }

            //owner.Point += ((Math.Round(model.Amount, 2) / 100)) * model.Percent;
            //UpdateOwner(owner);
            result.SetData(owner);

            return result;
        }

    }
}
