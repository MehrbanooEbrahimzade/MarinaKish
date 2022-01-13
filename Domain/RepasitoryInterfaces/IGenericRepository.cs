using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.RepasitoryInterfaces
{
    public interface IGenericRepository<T> where T :class
    {
        Task<List<T>> AllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
