using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.ProductFeatures.DTOs
{
    public record UpdateProductDto(Guid id, string name, string description, decimal price);
}
