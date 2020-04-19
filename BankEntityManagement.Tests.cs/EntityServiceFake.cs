using BankEntityManagement.Database.Entities;
using BankEntityManagement.Service.Dto;
using BankEntityManagement.Service.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankEntityManagement.Tests.cs
{
    [TestClass]
    public class EntityServiceFake : IEntityService
    {
        //private SqLiteDbFake sqLiteDbFake;

        [TestMethod]
        public async Task<List<DtoEntity>> GetAll()
        {
            return null;
        }

        public async Task<Entity> Add(DtoEntityAdd entity)
        {
            return null;
        }
    }
}
