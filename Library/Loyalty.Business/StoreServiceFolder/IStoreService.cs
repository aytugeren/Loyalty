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

        int InsertStore(StoreDTO store);

        void UpdateStore(StoreDTO store);

        int UpdateThreshHold(decimal threshHold, Guid storeId);

        int StoresCount();
    }
}
