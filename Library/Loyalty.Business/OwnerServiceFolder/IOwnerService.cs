using Loyalty.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.OwnerServiceFolder
{
    public interface IOwnerService
    {
        OwnerDTO GetById(Guid id);

        int DeleteOwner(OwnerDTO owner);

        List<OwnerDTO> GetAllOwners();
        int GetOwnersCount();

        OwnerDTO GetOwnerWithEmail(string email);

        int InsertOwner(OwnerDTO owner);


        int UpdateOwner(OwnerDTO owner);
    }
}
