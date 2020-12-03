using Loyalty.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.OwnerServiceFolder
{
    public interface IOwnerService
    {
        OwnerDTO GetById(Guid id);

        void DeleteOwner(OwnerDTO owner);

        List<OwnerDTO> GetAllOwners();

        void InsertOwner(OwnerDTO owner);

        void UpdateOwner(OwnerDTO owner);
    }
}
