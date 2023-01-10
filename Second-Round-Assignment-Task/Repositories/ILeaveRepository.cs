using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Second_Round_Assignment_Task.Repositories
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        Task<Leave> GetByIdAsync(int id);
        List<Leave> GetByEmployeeAsync(int id);
        Task<Leave> UpdateLeaveAsync(int id, Leave entity);
    }
}
