using AutoMapper;
using BackEntityManagement.Helpers.Exceptions;
using BackEntityManagement.MapperConfig.Tests;
using BackEntityManagement.Repository.Repository;
using BankEntityManagement.Database.Context;
using BankEntityManagement.Database.Entities;
using BankEntityManagement.Service.Dto;
using BankEntityManagement.Service.Interface;
using BankEntityManagement.Service.Service;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSupport.EfHelpers;
using Xunit;

namespace BackEntityManagement.Tests.TestEntity
{
    public class UnitTestEntity
    {
        private readonly IMapper _mapper;

        public UnitTestEntity()
        {
            _mapper = MapperAdd.AddMapper();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task GetEntity_Return_OkResult_And_NotFound_Id_Item_Async(int id)
        {
            DbContextOptions<BankEntityManagementContext> options = SqliteInMemory.CreateOptions<BankEntityManagementContext>();

            using (var context = new BankEntityManagementContext(options))
            {
                await BuilderEntity.AddContext(context, 1);

                IEntityService entityService = InjectEvaluationService(context);

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
                await BuilderEntity.AddContext(context, numberElements);

                IEntityService entityService = InjectEvaluationService(context);

                List<DtoEntity> listItem = await entityService.GetAll();
                listItem = listItem.Take(numberElements).ToList();

                listItem.Should().HaveCount(numberElements);
            }
        }

        [Theory]
        [InlineData(3, 4, "Entidad 3", 1, 1, "Alicante", "03009", "965858523", "prueba@gmail.com", "", true)]
        public async Task PostEntity_Return_OkResult(int numberElements, int id, string name, int IdEntityGroup, int idProvince, string city, string postalCode, string telephone, string email, string logo, bool active)
        {
            DbContextOptions<BankEntityManagementContext> options = SqliteInMemory.CreateOptions<BankEntityManagementContext>();

            using (var context = new BankEntityManagementContext(options))
            {
                await BuilderEntity.AddContext(context, numberElements);

                IEntityService entityService = InjectEvaluationService(context);

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
        
        private IEntityService InjectEvaluationService(BankEntityManagementContext context)
        {            
            EntityRepository repository = new EntityRepository(context);
            return new EntityService(repository, _mapper);
        }
    }
}
