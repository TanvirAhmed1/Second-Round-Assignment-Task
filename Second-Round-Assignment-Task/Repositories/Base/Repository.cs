using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Second_Round_Assignment_Task.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext _db;
        private DbSet<T> Table
        {
            get
            {
                return _db.Set<T>();
            }
        }
        public Repository(DbContext db)
        {
            _db = db;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var employee = await Table.AddAsync(entity);
            await _db.SaveChangesAsync();
            return employee.Entity;
        }

        //public virtual async Task<bool> Exists(int id)
        //{
        //    return await Table.AnyAsync(x => x.Id == id);
        //}

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<T> RemoveAsync(T entity)
        {
            Table.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Table.FirstOrDefaultAsync(predicate);
        }
    }
}
