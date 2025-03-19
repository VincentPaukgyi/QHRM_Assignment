using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Product.Application.Features.ProductFeatures.DTOs
{
    public abstract class BaseProductDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public virtual string Name { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }
    }

    

}
