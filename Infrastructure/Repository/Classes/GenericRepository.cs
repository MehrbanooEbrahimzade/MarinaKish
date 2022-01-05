using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Classes
{
    public class GenericRepository<T>: IGenericRepository<T> where T:class
    { 
        protected DatabaseContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(DatabaseContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var result=  await dbSet.FindAsync(id);
            dbSet.Remove(result);
            return true;
        }
    }
}
