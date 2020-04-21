using BankEntityManagement.Database.Context;
using BankEntityManagement.Database.Entities;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEntityManagement.Tests.TestEntity
{
    public static class BuilderEntity
    {
        public static async Task AddContext (BankEntityManagementContext context, int numberElements)
        {
            await ContextConfig.InitializeDatabaseContextSeed(context);

            await ContextConfig.AddDatabaseContext(context, GetCountry(numberElements));
            await ContextConfig.AddDatabaseContext(context, GetProvince(numberElements));
            await ContextConfig.AddDatabaseContext(context, GetEntityGroup(numberElements));
            await ContextConfig.AddDatabaseContext(context, GetEntity(numberElements));
        }

        private static List<Entity> GetEntity(int elements)
        {
            return Builder<Entity>.CreateListOfSize(elements).All().With(w => w.Active = true).Build() as List<Entity>;
        }

        private static List<Country> GetCountry(int elements)
        {
            return Builder<Country>.CreateListOfSize(elements).Build() as List<Country>;            
        }

        private static List<Province> GetProvince(int elements)
        {
            return Builder<Province>.CreateListOfSize(elements).Build() as List<Province>;            
        }

        private static List<EntityGroup> GetEntityGroup(int elements)
        {
            return Builder<EntityGroup>.CreateListOfSize(elements).Build() as List<EntityGroup>;            
        }
    }
}
