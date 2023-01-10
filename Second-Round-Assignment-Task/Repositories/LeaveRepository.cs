using Microsoft.EntityFrameworkCore;
using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Second_Round_Assignment_Task.Repositories
{
    public class LeaveRepository : Repository<Leave>, ILeaveRepository
    {
        EmployeeLeaveContext db;
        public LeaveRepository(DbContext dbContext) : base(dbContext)
        {
            db = (EmployeeLeaveContext)dbContext;
        }

        public List<Leave> GetByEmployeeAsync(int id)
        {
            return db.Leave.Where(x => x.EmployeeId == id).ToList();
        }

        public async Task<Leave> GetByIdAsync(int id)
        {
            return await GetFirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Leave> UpdateLeaveAsync(int id, Leave entity)
        {
            var existingLeave = await GetByIdAsync(id);
            if (existingLeave != null)
            {
                existingLeave.LeaveType = entity.LeaveType;
                existingLeave.StartDate = entity.StartDate;
                existingLeave.EndDate = entity.EndDate;
                existingLeave.Description = entity.Description;
                await db.SaveChangesAsync();
                return existingLeave;
            }
            return null;
        }
    }
}
