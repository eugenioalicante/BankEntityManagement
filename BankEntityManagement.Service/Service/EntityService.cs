using BackEntityManagement.Repository.Interface;
using BankEntityManagement.Database.Entities;
using BankEntityManagement.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankEntityManagement.Service.Service
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;

        public EntityService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<List<Entity>> GetAll()
        {
            return await _entityRepository.GetAll().ToListAsync();
        }
    }
}
