using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.ProductFeatures.DTOs
{
    public record CreateProductDto(string Name, string Description, decimal Price);
}
