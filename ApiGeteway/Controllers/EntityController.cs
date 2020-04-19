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
    [Authorize]
    public class EntityController : GenericController
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
        
        [HttpGet]
        [Route("{id:int}")]       
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _entityService.FindAsync(id));
        }

        [HttpPost]       
        public async Task<IActionResult> Add(DtoEntityAdd dtoEntity)
        {
            return Ok(await _entityService.Add(dtoEntity));
        }
    }
}