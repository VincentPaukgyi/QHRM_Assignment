using Microsoft.EntityFrameworkCore;

namespace Product.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product.Domain.Entities.Product> Products { get; set; }
    }
}
