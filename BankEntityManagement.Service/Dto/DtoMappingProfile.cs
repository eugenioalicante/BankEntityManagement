using AutoMapper;
using BankEntityManagement.Database.Entities;
using System.Collections.Generic;

namespace BankEntityManagement.Service.Dto
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Entity, DtoEntity>().
                ForMember(dest => dest.Province,    opt => opt.MapFrom(src => src.IdProvinceNavigation.Name)).
                ForMember(dest => dest.Country,     opt => opt.MapFrom(src => src.IdProvinceNavigation.IdCountryNavigation.Name)).
                ForMember(dest => dest.EntityGroup, opt => opt.MapFrom(src => src.IdEntityGroupNavigation));

            CreateMap<EntityGroup, DtoEntityGroup>();

            CreateMap<DtoEntityAdd, Entity>();            
        }
    }
}
