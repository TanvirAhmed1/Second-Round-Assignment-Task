using Microsoft.EntityFrameworkCore;
using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<Employee>> GetByRequest(Employee request)
        {
            var result = db.Employees.AsQueryable();
            if(request == null)
            {
                return await result.ToListAsync();
            }
            if(request.Id > 0)
            {
                result = result.Where(x => x.Id == request.Id);
            }
            if (!string.IsNullOrEmpty(request.FirstName))
            {
                result = result.Where(x => x.FirstName == request.FirstName);
            }
            if (!string.IsNullOrEmpty(request.MiddleName))
            {
                result = result.Where(x => x.MiddleName == request.MiddleName);
            }
            if (!string.IsNullOrEmpty(request.LastName))
            {
                result = result.Where(x => x.LastName == request.LastName);
            }
            if (!string.IsNullOrEmpty(request.Designation))
            {
                result = result.Where(x => x.Designation == request.Designation);
            }
            if (!string.IsNullOrEmpty(request.Department))
            {
                result = result.Where(x => x.Department == request.Department);
            }
            return result.ToList();
        }

        public async Task<ICollection<Employee>> GetByRequestPaging(int pageSize, int pageNumber, Employee request)
        {
            var result = db.Employees.AsQueryable();
            if (request == null)
            {
                return await result.ToListAsync();
            }
            if (request.Id > 0)
            {
                result = result.Where(x => x.Id == request.Id);
            }
            if (!string.IsNullOrEmpty(request.FirstName))
            {
                result = result.Where(x => x.FirstName == request.FirstName);
            }
            if (!string.IsNullOrEmpty(request.MiddleName))
            {
                result = result.Where(x => x.MiddleName == request.MiddleName);
            }
            if (!string.IsNullOrEmpty(request.LastName))
            {
                result = result.Where(x => x.LastName == request.LastName);
            }
            if (!string.IsNullOrEmpty(request.Designation))
            {
                result = result.Where(x => x.Designation == request.Designation);
            }
            if (!string.IsNullOrEmpty(request.Department))
            {
                result = result.Where(x => x.Department == request.Department);
            }
            result = result.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
            return result.ToList();
        }
    }
}
