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
        private readonly IRepository<Owner> _ownerRepository;
        private LoyaltyDbContext _loyaltyDbContext;
        private readonly IMapper _mapper;

        public StoreService(IRepository<Store> storeRepository, IRepository<Owner> ownerRepository ,IMapper mapper, LoyaltyDbContext loyaltyDbContext)
        {
            this._storeRepository = storeRepository;
            this._ownerRepository = ownerRepository;
            this._loyaltyDbContext = loyaltyDbContext;
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

        public int StoresCount()
        {
            var stores = _storeRepository.GetAll().Count;
            return stores;
        }

        public StoreDTO GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter is null");
            var store = _storeRepository.GetById(id);
            return _mapper.Map<StoreDTO>(store);
        }

        public int InsertStore(StoreDTO store)
        {
            if (store == null)
                return 0;
            var isOwnerIsValid = _ownerRepository.GetById(store.OwnerId);
            if (isOwnerIsValid != null)
            {
                store.CreatedTime = DateTime.Now;
                _storeRepository.Insert(_mapper.Map<Store>(store));
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public void UpdateStore(StoreDTO store)
        {
            if (store == null)
                throw new ArgumentNullException("Parameter is null");
            store.UpdatedTime = DateTime.Now;
            var storeDB = _mapper.Map<Store>(store);
            _loyaltyDbContext.tblStore.Update(storeDB);
            _loyaltyDbContext.SaveChanges();
        }

        public int UpdateThreshHold(decimal threshold, Guid storeId)
        {
            var store = _storeRepository.GetById(storeId);

            if (store.ThresholdEndDate > DateTime.Now)
            {
                return 0;
            }

            store.Threshold = threshold;
            store.ThresholdEndDate = DateTime.Now.AddDays(30);

            var result = _storeRepository.Update(store);

            return result;
        }
    }
}
