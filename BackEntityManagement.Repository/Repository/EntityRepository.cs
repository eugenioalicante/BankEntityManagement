using BackEntityManagement.Repository.Interface;
using BankEntityManagement.Database.Context;
using BankEntityManagement.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackEntityManagement.Repository.Repository
{   
    public class EntityRepository : IEntityRepository
    {       
        private readonly BankEntityManagementContext _context;

        /// <summary>
        /// 
        /// </summary>
        public EntityRepository(BankEntityManagementContext context)
        {
            _context = context;
        }

        public IQueryable<Entity> GetAll()
        {
            return _context.Entity.
                        Include(i => i.IdEntityGroupNavigation).
                        Include(i => i.IdProvinceNavigation).
                            ThenInclude(t => t.IdCountryNavigation).
                    AsNoTracking();
        }
    }
}
