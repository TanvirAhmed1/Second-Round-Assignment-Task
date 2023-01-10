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
            this.db = (EmployeeLeaveContext)dbContext;
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            return GetFirstOrDefaultAsync(x => x.Id==id);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee entity)
        {
            var existingEmployee = await GetByIdAsync(id);
            if(existingEmployee != null)
            {
                existingEmployee.FirstName = entity.FirstName;
                existingEmployee.LastName = entity.LastName;
                existingEmployee.MiddleName = entity.MiddleName;
                existingEmployee.DateOfBirth = entity.DateOfBirth;
                existingEmployee.JoiningDate = entity.JoiningDate;
                existingEmployee.Designation = entity.Designation;
                existingEmployee.Department = entity.Department;
                await db.SaveChangesAsync();
                return existingEmployee;
            }
            return null;
        }
    }
}
