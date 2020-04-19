using AutoMapper;
using BankEntityManagement.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEntityManagement.Tests
{
    public static class TsrAutoMapperConfiguration
    {
        public static IMapper GetIMapper()
        {
            DtoMappingProfile testProfile = new DtoMappingProfile();
            TestTsrAutoMapperProfile tsrProfileService = new TestTsrAutoMapperProfile();

            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {                
                cfg.AddProfile(tsrProfileService);
                cfg.AddProfile(testProfile);
            });

            return new Mapper(configuration);
        }
    }
}
