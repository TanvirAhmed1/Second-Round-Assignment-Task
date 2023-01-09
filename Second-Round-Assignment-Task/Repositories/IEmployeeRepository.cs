using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System;
using Second_Round_Assignment_Task.DataModels;

namespace Second_Round_Assignment_Task.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int employeeId);
        Task<bool> Exists(int employeeId);
        Task<Employee> UpdateEmployee(int employeeId, Employee employee);
        Task<Employee> DeleteEmployee(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
    }
}
