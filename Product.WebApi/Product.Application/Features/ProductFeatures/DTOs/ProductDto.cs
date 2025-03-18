namespace Product.Application.Features.ProductFeatures.DTOs
{
    public record ProductDto(Guid Id,string Name, string Description, DateTime CreatedDate);
}
