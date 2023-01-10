using Second_Round_Assignment_Task.DataModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Second_Round_Assignment_Task.Repositories.Base
{
    public interface IRepository<T> where T: class
    {
        Task<T> AddAsync(T entity);
        Task<T> RemoveAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
