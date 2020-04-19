using System.Collections.Generic;
using System.Threading.Tasks;
using BankEntityManagement.Database.Entities;
using BankEntityManagement.Service.Dto;

namespace BankEntityManagement.Service.Interface
{
    public interface IEntityService
    {
        Task<List<DtoEntity>> GetAll();
        Task<Entity> Add(DtoEntityAdd entity);
    }
}