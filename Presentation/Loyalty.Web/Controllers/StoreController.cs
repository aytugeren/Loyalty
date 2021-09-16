using Loyalty.Business.DTO;
using Loyalty.Business.StoreServiceFolder;
using Loyalty.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            this._storeService = storeService;
        }

        [HttpPost]
        [Route("GetStores")]
        public MVCResultModel<List<StoreDTO>> GetStores()
        {
            var result = new MVCResultModel<List<StoreDTO>>();
            var stores = _storeService.GetAllStores();
            var storeCount = _storeService.StoresCount();
            result.SetData(stores);
            result.SetCount(storeCount);
            return result;
        }

        [HttpPost]
        [Route("InsertStore")]
        public MVCResultModel<int> InsertStore(StoreDTO store)
        {
            var result = new MVCResultModel<int>();
            if (store == default(StoreDTO))
                result.SetException(new ArgumentNullException());
            int data = _storeService.InsertStore(store);
            if (data == 1)
            {
                result.SetData(data);

            }
            else
            {
                result.SetException(new ArgumentNullException());
            }
            return result;
        }

        [HttpPost]
        [Route("UpdateStore")]
        public MVCResultModel<string> UpdateStore(StoreDTO storeDTO)
        {
            var result = new MVCResultModel<string>();
            if (storeDTO == default(StoreDTO))
            {
                result.SetException(new ArgumentNullException());
            }

            var storeInfo = _storeService.GetById(storeDTO.Id);
            if (!String.IsNullOrEmpty(storeDTO.Name))
            {
                storeInfo.Name = storeDTO.Name;
            }
            if (!String.IsNullOrEmpty(storeDTO.Address))
            {
                storeInfo.Address = storeDTO.Address;
            }
            if (!String.IsNullOrEmpty(storeDTO.Postcode))
            {
                storeInfo.Postcode = storeDTO.Postcode;
            }
            if (!String.IsNullOrEmpty(storeDTO.Country))
            {
                storeInfo.Country = storeDTO.Country;
            }
            if (!String.IsNullOrEmpty(storeDTO.County))
            {
                storeInfo.County = storeDTO.County;
            }
            if (!String.IsNullOrEmpty(storeDTO.Phone))
            {
                storeInfo.Phone = storeDTO.Phone;
            }
            if (storeDTO.Point != 0)
            {
                storeInfo.Point = storeDTO.Point;
            }
            if (storeDTO.IsActive && !storeInfo.IsActive)
            {
                storeInfo.IsActive = true;
            }
            if (!storeDTO.IsActive && storeInfo.IsActive)
            {
                storeInfo.IsActive = false;
            }
            if (storeDTO.IsDeleted && !storeInfo.IsDeleted)
            {
                storeInfo.IsDeleted = true;
            }
            if (!storeDTO.IsDeleted && storeInfo.IsDeleted)
            {
                storeInfo   .IsDeleted = false;
            }

            _storeService.UpdateStore(storeInfo);

            result.SetData("Updated process is done by successfully!");
            return result;
        }

        [HttpPost]
        [Route("DeleteStore/{id}")]
        public MVCResultModel<string> DeleteStore(Guid id)
        {
            var result = new MVCResultModel<string>();
            if (id == Guid.Empty)
            {
                result.SetException(new ArgumentNullException());
            }
            var store = _storeService.GetById(id);
            _storeService.DeleteStore(store);

            result.SetData("Delete process is done by successfully!");
            return result;
        }

        [HttpPost]
        [Route("UpdateThreshHold")]
        public MVCResultModel<int> UpdateThreshold(StoreDTO store)
        {
            var result = new MVCResultModel<int>();

            if (store.Threshold == 0 || store.Id == Guid.Empty)
            {
                result.SetException(new ArgumentNullException());
            }

            var resultStore = _storeService.UpdateThreshHold(store.Threshold, store.Id);
            if (resultStore != 1)
            {
                result.SetMessage("You cannot change the threshold yet.");
                result.SetData(resultStore);
            }
            else
            {
                result.SetMessage("Your threshold is changed. Another changing time will be available after 30 days!");
                result.SetData(resultStore);
            }
            return result;
        }
    }
}
