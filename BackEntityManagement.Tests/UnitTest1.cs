using AutoMapper;
using BackEntityManagement.Helpers.Exceptions;
using BackEntityManagement.Repository.Repository;
using BankEntityManagement.Database.Context;
using BankEntityManagement.Database.Entities;
using BankEntityManagement.Service.Dto;
using BankEntityManagement.Service.Interface;
using BankEntityManagement.Service.Service;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSupport.EfHelpers;
using Xunit;

namespace BackEntityManagement.Tests
{
    public class UnitTest1
    {
        private readonly IMapper _mapper;

        public UnitTest1()
        {
            _mapper = TsrAutoMapperConfiguration.GetIMapper();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task GetEntity_Return_OkResult_And_NotFound_Id_Item_Async(int id)
        {
            DbContextOptions<BankEntityManagementContext> options = SqliteInMemory.CreateOptions<BankEntityManagementContext>();

            using (var context = new BankEntityManagementContext(options))
            {
                List<Country> country = GetCountry(1);
                List<Province> Province = GetProvince(1);
                List<EntityGroup> EntityGroup = GetEntityGroup(1);
                List<Entity> entity = GetEntity(1);

                await ContextConfig.InitializeDatabaseContextSeed(context);

                await ContextConfig.AddDatabaseContext(context, country);
                await ContextConfig.AddDatabaseContext(context, Province);
                await ContextConfig.AddDatabaseContext(context, EntityGroup);
                await ContextConfig.AddDatabaseContext(context, entity);

                IEntityService entityService = InjectEvaluationTsrService(context);

                switch (id)
                {
                    case 0:                        
                        await Assert.ThrowsAsync<ResourceNotFoundException>(async () => await entityService.FindAsync(id));
                        break;
                    case 1:
                        Entity item = await entityService.FindAsync(id);
                        item.Id.Should().Be(id);
                        break;
                    default:
                        break;
                }
            }
        }

        [Theory]
        [InlineData(3)]        
        public async Task GetEntity_Return_OkResult_All_Items_Async(int numberElements)
        {
            DbContextOptions<BankEntityManagementContext> options = SqliteInMemory.CreateOptions<BankEntityManagementContext>();

            using (var context = new BankEntityManagementContext(options))
            {
                List<Country> country = GetCountry(numberElements);
                List<Province> Province = GetProvince(numberElements);
                List<EntityGroup> EntityGroup = GetEntityGroup(numberElements);
                List<Entity> entity = GetEntity(numberElements);

                await ContextConfig.InitializeDatabaseContextSeed(context);

                await ContextConfig.AddDatabaseContext(context, country);
                await ContextConfig.AddDatabaseContext(context, Province);
                await ContextConfig.AddDatabaseContext(context, EntityGroup);
                await ContextConfig.AddDatabaseContext(context, entity);

                IEntityService entityService = InjectEvaluationTsrService(context);

                List<DtoEntity> listItem = await entityService.GetAll();
                listItem = listItem.Take(numberElements).ToList();

                listItem.Should().HaveCount(numberElements);
            }
        }

        [Theory]
        [InlineData(3, 4, "Entidad 3", 1, 1, "Alicante", "03009", "965858523", "prueba@gmail.com", "", true)]
        public async Task Add(int numberElements, int id, string name, int IdEntityGroup, int idProvince, string city, string postalCode, string telephone, string email, string logo, bool active)
        {
            DbContextOptions<BankEntityManagementContext> options = SqliteInMemory.CreateOptions<BankEntityManagementContext>();

            using (var context = new BankEntityManagementContext(options))
            {
                List<Country> country = GetCountry(numberElements);
                List<Province> Province = GetProvince(numberElements);
                List<EntityGroup> EntityGroup = GetEntityGroup(numberElements);
                List<Entity> entity = GetEntity(numberElements);

                await ContextConfig.InitializeDatabaseContextSeed(context);

                await ContextConfig.AddDatabaseContext(context, country);
                await ContextConfig.AddDatabaseContext(context, Province);
                await ContextConfig.AddDatabaseContext(context, EntityGroup);
                await ContextConfig.AddDatabaseContext(context, entity);

                IEntityService entityService = InjectEvaluationTsrService(context);

                DtoEntityAdd entityAdd = new DtoEntityAdd
                {
                    Name = name,
                    IdEntityGroup = IdEntityGroup,
                    IdProvince = idProvince,
                    City = city,
                    PostalCode = postalCode,
                    Telephone = telephone,
                    Email = email,
                    Logo = logo,
                    Active = active
                };

                Entity entityResult = await entityService.Add(entityAdd);

                entityResult.Id.Should().Be(id);
            }
        }

        private List<Entity> GetEntity(int elements)
        {
            List<Entity> result = Builder<Entity>.CreateListOfSize(elements)

                                                   .Build() as List<Entity>;

            return result;
        }

        private List<Country> GetCountry(int elements)
        {
            List<Country> result = Builder<Country>.CreateListOfSize(elements)

                                                   .Build() as List<Country>;

            return result;
        }

        private List<Province> GetProvince(int elements)
        {
            List<Province> result = Builder<Province>.CreateListOfSize(elements)

                                                   .Build() as List<Province>;

            return result;
        }

        private List<EntityGroup> GetEntityGroup(int elements)
        {
            List<EntityGroup> result = Builder<EntityGroup>.CreateListOfSize(elements)

                                                   .Build() as List<EntityGroup>;

            return result;
        }



        private IEntityService InjectEvaluationTsrService(BankEntityManagementContext context)
        {            
            EntityRepository repository = new EntityRepository(context);
            return new EntityService(repository, _mapper);
        }
    }
}
