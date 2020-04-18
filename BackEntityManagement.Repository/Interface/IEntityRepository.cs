using System.Linq;
using BankEntityManagement.Database.Entities;

namespace BackEntityManagement.Repository.Interface
{
    public interface IEntityRepository
    {
        IQueryable<Entity> GetAll();
    }
}