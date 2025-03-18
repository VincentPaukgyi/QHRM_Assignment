using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.ProductFeatures.DTOs
{
    public record ProductDto(string Name, string Description, decimal Price);
}
