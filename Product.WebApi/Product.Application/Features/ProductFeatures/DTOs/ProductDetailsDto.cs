using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Features.ProductFeatures.DTOs
{
    public class ProductDetailsDto : ProductDto
    {
       
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
