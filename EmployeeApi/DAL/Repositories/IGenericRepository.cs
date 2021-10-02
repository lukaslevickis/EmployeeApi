using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task<TEntity> GetByIDAsync(object id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
