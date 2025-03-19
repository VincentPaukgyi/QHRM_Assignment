using productNamespace = Product.Domain.Entities;

namespace Product.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Guid> CreateAsync(productNamespace.Product product);
        Task<Guid> UpdateAsync(productNamespace.Product product);
        Task<Guid> DeleteAsync(Guid id);
        Task<IEnumerable<productNamespace.Product>> GetAllAsync();
        Task<productNamespace.Product> GetByIdAsync(Guid id);
    }
}
