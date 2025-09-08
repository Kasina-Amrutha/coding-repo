using Microsoft.EntityFrameworkCore;
using MVCExample1.Models;

namespace MVCExample1.Data
{
    public class EcomContext: DbContext
    {
       
            public EcomContext(DbContextOptions<EcomContext> options) : base(options)
            {

            }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }
        
    }
}
