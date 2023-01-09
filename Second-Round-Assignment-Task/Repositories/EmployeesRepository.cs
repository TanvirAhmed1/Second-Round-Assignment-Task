using Second_Round_Assignment_Task.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Second_Round_Assignment_Task.Repositories
{
    public class EmployeesRepository : IEmployeeRepository
    {
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> DeleteEmployee(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Exists(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> GetEmployeeAsync(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Employee>> GetEmployeesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(int employeeId, Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}
