using AutoMapper;
using Loyalty.Business.DTO;
using Loyalty.Core.Domain;
using Loyalty.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.StoreServiceFolder
{
    public class StoreService : IStoreService
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IMapper _mapper;

        public StoreService(IRepository<Store> storeRepository, IMapper mapper)
        {
            this._storeRepository = storeRepository;
            this._mapper = mapper;
        }

        public void DeleteStore(StoreDTO store)
        {
            if (store == null)
                throw new ArgumentNullException("Parameter is null!");
            store.IsDeleted = true;
            store.IsActive = false;
            UpdateStore(store);
        }

        public List<StoreDTO> GetAllStores()
        {
            var storees = _storeRepository.GetAll();
            if (storees == null)
                throw new ArgumentNullException("Parameter is null!");
            List<StoreDTO> StoreDTOs = new List<StoreDTO>();
            foreach (var item in storees)
            {
                StoreDTOs.Add(_mapper.Map<StoreDTO>(item));
            }
            return StoreDTOs;
        }

        public StoreDTO GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter is null");
            var store = _storeRepository.GetById(id);
            return _mapper.Map<StoreDTO>(store);
        }

        public void InsertStore(StoreDTO store)
        {
            if (store == null)
                throw new ArgumentNullException("Parameter is null");
            _storeRepository.Insert(_mapper.Map<Store>(store));
        }

        public void UpdateStore(StoreDTO store)
        {
            if (store == null)
                throw new ArgumentNullException("Parameter is null");
            store.UpdatedTime = DateTime.Now;
            _storeRepository.Update(_mapper.Map<Store>(store));
        }
    }
}
