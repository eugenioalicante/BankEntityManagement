using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEntityManagement.Repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(int id);
        T CreateGeneric<T>(T entity) where T : class;
        Task SaveChangesAsync();
    }
}
