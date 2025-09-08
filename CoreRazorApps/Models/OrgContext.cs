using Microsoft.EntityFrameworkCore;

namespace CoreRazorApps.Models
{
    public class OrgContext:DbContext
    {
        public OrgContext(DbContextOptions<OrgContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrgLocations>(entity =>
            {
                entity.HasKey(e => e.OrgId);
                entity.HasKey(e => e.LocationId);
            });

        }
        public int ID { get; set; }
        public DbSet<Organization> organizations { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees {  get; set; }  
        public DbSet<Location> locations { get; set; }
        public DbSet<OrgLocations> orglocation { get; set; }
    }
}
