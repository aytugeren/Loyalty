using Loyalty.Business.DTO;
using Loyalty.Business.StoreServiceFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.Web.Controllers
{
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            this._storeService = storeService;
        }

        [HttpPost]
        [Route("GetStores")]
        public List<StoreDTO> GetStores()
        {
            var stores = _storeService.GetAllStores();
            return stores;
        }

        [HttpPost]
        [Route("InsertStore")]
        public string InsertStore(StoreDTO store)
        {
            if (store == default(StoreDTO))
                return "Parameter is null!";

            _storeService.InsertStore(store);
            return "Insert Operation is done by successfully!";
        }

        public string UpdateStore(StoreDTO storeDTO)
        {
            if (storeDTO == default(StoreDTO))
            {
                return "Parameter is null!";
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

            return "Updated process is done by successfully!";
        }

        public string DeleteStore(Guid id)
        {
            if (id == Guid.Empty)
            {
                return "Parameter is null!";
            }
            var store = _storeService.GetById(id);
            _storeService.DeleteStore(store);

            return "Delete process is done by successfully!";
        }
    }
}
