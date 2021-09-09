using AutoMapper;
using Loyalty.Business.DTO;
using Loyalty.Core.Domain;
using Loyalty.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loyalty.Business.OwnerServiceFolder
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository<Owner> _ownerRepository;
        private readonly IMapper _mapper;
        private LoyaltyDbContext _loyaltyDbContext;

        public OwnerService(IRepository<Owner> ownerRepository, IMapper mapper, LoyaltyDbContext loyaltyDbContext)
        {
            this._ownerRepository = ownerRepository;
            this._mapper = mapper;
            this._loyaltyDbContext = loyaltyDbContext;
        }

        public int DeleteOwner(OwnerDTO owner)
        {
            if (owner == null)
                return 0;
            owner.IsDeleted = true;
            owner.IsActive = false;
            int result = UpdateOwner(owner);
            if (result == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<OwnerDTO> GetAllOwners()
        {
            try
            {
                var owneres = _ownerRepository.GetAll();
                if (owneres == null)
                    throw new ArgumentNullException("Parameter is null!");
                List<OwnerDTO> OwnerDTOs = new List<OwnerDTO>();
                foreach (var item in owneres)
                {
                    OwnerDTOs.Add(_mapper.Map<OwnerDTO>(item));
                }
                return OwnerDTOs;
            }
            catch (Exception)
            {
                return default(List<OwnerDTO>);
            }
;
        }

        public int GetOwnersCount()
        {
            return _ownerRepository.GetAll().Count;
        }

        public OwnerDTO GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentNullException("Parameter is null");
                var owner = _ownerRepository.GetById(id);
                return _mapper.Map<OwnerDTO>(owner);
            }
            catch (Exception)
            {
                return default(OwnerDTO);
            }

        }

        public OwnerDTO GetOwnerWithEmail(string email)
        {
            try
            {
                if (email == null)
                {
                    throw new ArgumentNullException("Parameter is null");
                }
                var owner = _ownerRepository.GetAll().FirstOrDefault(x => x.Email == email);

                return _mapper.Map<OwnerDTO>(owner);
            }
            catch (Exception)
            {
                return default(OwnerDTO);
            }

        }

        public int InsertOwner(OwnerDTO owner)
        {
            if (owner == null)
                return 0;
            try
            {
                _ownerRepository.Insert(_mapper.Map<Owner>(owner));
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int UpdateOwner(OwnerDTO ownerDTO)
        {
            if (ownerDTO == null)
                return 0;

            try
            {
                Owner owner = new Owner();
                owner = _mapper.Map<Owner>(ownerDTO);
                owner.UpdatedTime = DateTime.Now;
                _loyaltyDbContext.tblOwner.Update(owner);
                _loyaltyDbContext.SaveChanges();

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
