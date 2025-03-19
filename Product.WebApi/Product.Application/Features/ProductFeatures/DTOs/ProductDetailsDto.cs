using System.Text.Json.Serialization;

namespace Product.Application.Features.ProductFeatures.DTOs
{
    public class ProductDetailsDto : BaseProductDto
    {
       
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
