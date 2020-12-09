using AutoMapper;
using Loyalty.Business.DTO;
using Loyalty.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Business.AutoMapperProfile
{
    public class LoyaltyProfile : Profile
    {

        public static MapperConfiguration Configuration()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Owner, OwnerDTO>();
                cfg.CreateMap<OwnerDTO, Owner>();
                cfg.CreateMap<Store, StoreDTO>();
                cfg.CreateMap<CustomerStore, CustomerStoreDTO>();
                cfg.CreateMap<CustomerStoreDTO, CustomerStore>();
        });
            return mapperConfiguration;
        }

  
}
}
