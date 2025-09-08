using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class FractoDbContext : DbContext
{
    public FractoDbContext(DbContextOptions<FractoDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(u => u.Appointments).WithOne(a => a.User).HasForeignKey(a => a.UserId);
        modelBuilder.Entity<User>().HasMany(u => u.Ratings).WithOne(r => r.User).HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Doctor>().HasMany(d => d.Appointments).WithOne(a => a.Doctor).HasForeignKey(a => a.DoctorId);
        modelBuilder.Entity<Doctor>().HasMany(d => d.Ratings).WithOne(r => r.Doctor).HasForeignKey(r => r.DoctorId);

        modelBuilder.Entity<Specialization>().HasMany(s => s.Doctors).WithOne(d => d.Specialization).HasForeignKey(d => d.SpecializationId);
    }

}
