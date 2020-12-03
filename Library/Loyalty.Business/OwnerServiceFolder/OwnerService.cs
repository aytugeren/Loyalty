using AutoMapper;
using Loyalty.Business.DTO;
using Loyalty.Core.Domain;
using Loyalty.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.OwnerServiceFolder
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository<Owner> _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerService(IRepository<Owner> ownerRepository, IMapper mapper)
        {
            this._ownerRepository = ownerRepository;
            this._mapper = mapper;
        }

        public void DeleteOwner(OwnerDTO owner)
        {
            if (owner == null)
                throw new ArgumentNullException("Parameter is null!");
            owner.IsDeleted = true;
            owner.IsActive = false;
            UpdateOwner(owner);
        }

        public List<OwnerDTO> GetAllOwners()
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

        public OwnerDTO GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter is null");
            var owner = _ownerRepository.GetById(id);
            return _mapper.Map<OwnerDTO>(owner);
        }

        public void InsertOwner(OwnerDTO owner)
        {
            if (owner == null)
                throw new ArgumentNullException("Parameter is null");
            _ownerRepository.Insert(_mapper.Map<Owner>(owner));
        }

        public void UpdateOwner(OwnerDTO owner)
        {
            if (owner == null)
                throw new ArgumentNullException("Parameter is null");
            owner.UpdatedTime = DateTime.Now;
            _ownerRepository.Update(_mapper.Map<Owner>(owner));
        }
    }
}
