using System.Linq;
using BankEntityManagement.Database.Entities;

namespace BackEntityManagement.Repository.Interface
{
    public interface IEntityRepository : IGenericRepository<Entity>
    {
        IQueryable<Entity> GetAll();
    }
}