using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingPlatform.Models;

namespace ShoppingPlatform.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
   // public DbSet<RegisterViewModel> RegisterViewModel { get; set; }
    
    
}
