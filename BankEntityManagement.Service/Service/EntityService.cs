using AutoMapper;
using AutoMapper.QueryableExtensions;
using BackEntityManagement.Helpers.Exceptions;
using BackEntityManagement.Repository.Interface;
using BankEntityManagement.Database.Entities;
using BankEntityManagement.Service.Dto;
using BankEntityManagement.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankEntityManagement.Service.Service
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IMapper _mapper;

        public EntityService(IEntityRepository entityRepository,
                             IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        public async Task<List<DtoEntity>> GetAll()
        {
            return await _entityRepository.GetAll().
                                ProjectTo<DtoEntity>(_mapper.ConfigurationProvider)
                                    .ToListAsync();
        }

        public async Task<Entity> FindAsync(int id)
        {
            var response = await _entityRepository.FindAsync(id);

            if (response == null)
            {
                throw new ResourceNotFoundException("No se ha encontrado la entidad");
            }

            return response;
        }

        public async Task<Entity> Add(DtoEntityAdd dtoEntity)
        {
            Entity entity = _mapper.Map<Entity>(dtoEntity);

            _entityRepository.CreateGeneric(entity);

            await _entityRepository.SaveChangesAsync();

            return entity;
        }
    }
}
