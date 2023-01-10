using Microsoft.EntityFrameworkCore;
using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Second_Round_Assignment_Task.Repositories
{
    public class EmployeesRepository : Repository<Employee>, IEmployeeRepository
    {
        EmployeeLeaveContext db;
        public EmployeesRepository(DbContext dbContext) : base(dbContext)
        {
            db = (EmployeeLeaveContext)dbContext;
        }

        public Task<Employee> GetById(int id)
        {
            return GetFirstOrDefaultAsync(x => x.Id==id);
        }
    }
}
