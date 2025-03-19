using Product.Application.Features.ProductFeatures.DTOs;

namespace Product.Application.Interfaces
{
    public interface IProductApiClient
    {
        void Create(CreateProductDto product);
        void Update(UpdateProductDto product);
        void Delete(Guid id);
        ProductDetailsDto GetById(Guid id);
        List<ProductDto> GetAll();
    }
}
