using AutoMapper;
using BackEntityManagement.Repository.Interface;
using BackEntityManagement.Repository.Repository;
using BankEntityManagement.Database.Context;
using BankEntityManagement.Service.Dto;
using BankEntityManagement.Service.Interface;
using BankEntityManagement.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BankEntityManagement.Service.Startup
{
    public static class BackEntityManagementCollectionExtensions
    {
        public static void AddBackEntityManagement(this IServiceCollection services)
        {
            // Register service                     
            services.AddScoped<IEntityService, EntityService>();

            // Register service                     
            services.AddScoped<IEntityRepository, EntityRepository>();                       

            services.AddDbContext<BankEntityManagementContext>();

            services.AddAutoMapper(typeof(DtoMappingProfile));
        }
    }
}
