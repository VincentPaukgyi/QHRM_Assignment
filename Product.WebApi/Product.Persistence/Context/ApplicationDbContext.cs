using Microsoft.EntityFrameworkCore;
using Product.Application.Interfaces;

namespace Product.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product.Domain.Entities.Product> Products { get; set; }
        
    }
}
