using BackEntityManagement.Repository.Interface;
using BankEntityManagement.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BackEntityManagement.Repository.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly BankEntityManagementContext _context;

        /// <summary>
        /// 
        /// </summary>
        public GenericRepository(BankEntityManagementContext context)
        {
            _context = context;
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public T CreateGeneric<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
