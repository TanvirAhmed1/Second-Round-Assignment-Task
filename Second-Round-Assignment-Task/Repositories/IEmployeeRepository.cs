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
        Task<Employee> GetById(int id);
    }
}
