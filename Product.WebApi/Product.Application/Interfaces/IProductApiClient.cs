using Product.Application.Features.ProductFeatures.DTOs;

namespace Product.Application.Interfaces
{
    public interface IProductApiClient
    {
        void Create(CreateProductDto product);
        Guid Update(UpdateProductDto product);
        Guid Delete(Guid id);
        ProductDto GetById(Guid id);
        List<ProductDto> GetAll();
    }
}
