using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Product.Application.Features.ProductFeatures.DTOs
{
    public class ProductDto : BaseProductDto
    {
        [JsonPropertyName("name")]
        [DisplayName("Product")]
        public override string Name { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
