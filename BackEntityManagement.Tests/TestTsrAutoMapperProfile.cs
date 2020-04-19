using AutoMapper;
using BankEntityManagement.Database.Entities;
using BankEntityManagement.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEntityManagement.Tests
{
    public class TestTsrAutoMapperProfile : Profile
    {
        public TestTsrAutoMapperProfile()
        {
            CreateMap<Entity, DtoEntity>().
               ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.IdProvinceNavigation.Name)).
               ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.IdProvinceNavigation.IdCountryNavigation.Name)).
               ForMember(dest => dest.EntityGroup, opt => opt.MapFrom(src => src.IdEntityGroupNavigation));

            CreateMap<EntityGroup, DtoEntityGroup>();

            CreateMap<DtoEntityAdd, Entity>();
        }

    }
}
