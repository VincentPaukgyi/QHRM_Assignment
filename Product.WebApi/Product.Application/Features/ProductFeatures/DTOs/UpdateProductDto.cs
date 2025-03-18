namespace Product.Application.Features.ProductFeatures.DTOs
{
    public record UpdateProductDto(Guid id, string name, string description, decimal price);
}
