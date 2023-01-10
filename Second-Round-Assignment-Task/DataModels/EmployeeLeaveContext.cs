using Microsoft.EntityFrameworkCore;

namespace Second_Round_Assignment_Task.DataModels
{
    public class EmployeeLeaveContext : DbContext
    {
        public EmployeeLeaveContext(DbContextOptions<EmployeeLeaveContext> options): base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leave { get; set; }
    }
}
