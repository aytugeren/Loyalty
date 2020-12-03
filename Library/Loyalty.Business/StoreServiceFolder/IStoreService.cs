using Loyalty.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.StoreServiceFolder
{
    public interface IStoreService
    {
        StoreDTO GetById(Guid id);

        void DeleteStore(StoreDTO store);

        List<StoreDTO> GetAllStores();

        void InsertStore(StoreDTO store);

        void UpdateStore(StoreDTO store);
    }
}
