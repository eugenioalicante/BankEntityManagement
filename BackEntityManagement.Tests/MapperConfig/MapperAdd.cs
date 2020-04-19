using AutoMapper;
using BankEntityManagement.Service.Dto;

namespace BackEntityManagement.MapperConfig.Tests
{
    public static class MapperAdd
    {
        public static IMapper AddMapper()
        {
            DtoMappingProfile testProfile = new DtoMappingProfile();
            TestMappingProfile testProfileService = new TestMappingProfile();

            MapperConfiguration configuration = new AutoMapper.MapperConfiguration(map =>
            {
                map.AddProfile(testProfileService);
                map.AddProfile(testProfile);
            });

            return new Mapper(configuration);
        }
    }
}
