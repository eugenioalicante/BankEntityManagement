using AutoMapper;
using BackEntityManagement.Helpers.Exceptions;
using BackEntityManagement.Repository.Repository;
using BankEntityManagement.Database.Context;
using BankEntityManagement.Database.Entities;
using BankEntityManagement.Service.Interface;
using BankEntityManagement.Service.Service;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
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
        public async Task Get(int id)
        {
            DbContextOptions<BankEntityManagementContext> options = SqliteInMemory.CreateOptions<BankEntityManagementContext>();

            using (var context = new BankEntityManagementContext(options))
            {
                List<Country> country = GetCountry();
                List<Province> Province = GetProvince();
                List<EntityGroup> EntityGroup = GetEntityGroup();
                List<Entity> entity = GetEntity();

                await ContextConfig.InitializeDatabaseContextSeed(context);

                await ContextConfig.AddDatabaseContext(context, country);
                await ContextConfig.AddDatabaseContext(context, Province);
                await ContextConfig.AddDatabaseContext(context, EntityGroup);
                await ContextConfig.AddDatabaseContext(context, entity);

                IEntityService entityService = InjectEvaluationTsrService(context);

                switch (id)
                {
                    case 0:
                        //var response = await entityService.FindAsync(id);
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

        private List<Entity> GetEntity()
        {
            List<Entity> result = Builder<Entity>.CreateListOfSize(1)

                                                   .Build() as List<Entity>;

            return result;
        }

        private List<Country> GetCountry()
        {
            List<Country> result = Builder<Country>.CreateListOfSize(1)

                                                   .Build() as List<Country>;

            return result;
        }

        private List<Province> GetProvince()
        {
            List<Province> result = Builder<Province>.CreateListOfSize(1)

                                                   .Build() as List<Province>;

            return result;
        }

        private List<EntityGroup> GetEntityGroup()
        {
            List<EntityGroup> result = Builder<EntityGroup>.CreateListOfSize(1)

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
