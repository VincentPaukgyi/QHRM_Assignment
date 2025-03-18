using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using productNamespace = Product.Domain.Entities;
namespace Product.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<productNamespace.Product>
    {
        public void Configure(EntityTypeBuilder<productNamespace.Product> builder)
        {
            // Define table name
            builder.ToTable("Products");

            // Set primary key
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasDefaultValueSql("NEWID()");

            // Configure properties
            builder.Property(m => m.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(m => m.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(m => m.Price)
                   .IsRequired();

        }
    }
}
