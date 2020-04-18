using System.Collections.Generic;
using System.Threading.Tasks;
using BankEntityManagement.Database.Entities;

namespace BankEntityManagement.Service.Interface
{
    public interface IEntityService
    {
        Task<List<Entity>> GetAll();
    }
}