using System.Threading.Tasks;
using BackEntityManagement.Infrastructure.Controller;
using BackEntityManagement.Repository.Interface;
using BankEntityManagement.Database.Entities;
using BankEntityManagement.Service.Dto;
using BankEntityManagement.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGeteway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EntityController : GenericController
    {
        private readonly IEntityService _entityService;
        private readonly IEntityRepository _entityRepository;

        public EntityController(IEntityService entityService,
                                IEntityRepository entityRepository)
        {
            _entityService = entityService;
            _entityRepository = entityRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(DtoEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        
        public async Task<IActionResult> Get()
        {
            return Ok(await _entityService.GetAll());
        }
        
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Entity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _entityRepository.FindAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Add(DtoEntityAdd dtoEntity)
        {
            return Ok(await _entityService.Add(dtoEntity));
        }
    }
}