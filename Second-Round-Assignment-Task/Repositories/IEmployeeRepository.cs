using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System;
using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.Repositories.Base;

namespace Second_Round_Assignment_Task.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> UpdateEmployeeAsync(int id, Employee entity);
        Task<ICollection<Employee>> GetByRequest(Employee request);
        Task<ICollection<Employee>> GetByRequestPaging(int pageSize, int pageNumber, Employee request);
    }
}
