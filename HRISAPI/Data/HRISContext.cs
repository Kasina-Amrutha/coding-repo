using Microsoft.EntityFrameworkCore;
using Model;

namespace HRISAPI.Data
{
    public class HRISContext:DbContext
    {
        public HRISContext(DbContextOptions<HRISContext> options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
