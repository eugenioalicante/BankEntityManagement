using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankEntityManagement.Service.Interface;
using BankEntityManagement.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGeteway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IEntityService _entityService;

        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {           
            return Ok(await _entityService.GetAll());
        }
    }
}