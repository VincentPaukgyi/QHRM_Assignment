using Microsoft.EntityFrameworkCore;

namespace Product.Persistence.Context
{
    public class CreationApplicationDbContext : DbContext
    {
        public CreationApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product.Domain.Entities.Product> Products { get; set; }
    }
}
