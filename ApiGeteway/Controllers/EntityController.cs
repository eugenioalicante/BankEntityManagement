using System.Threading.Tasks;
using BankEntityManagement.Service.Dto;
using BankEntityManagement.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGeteway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EntityController : ControllerBase
    {
        private readonly IEntityService _entityService;

        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(DtoEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        
        public async Task<IActionResult> Get()
        {
            return Ok(await _entityService.GetAll());
        }
    }
}