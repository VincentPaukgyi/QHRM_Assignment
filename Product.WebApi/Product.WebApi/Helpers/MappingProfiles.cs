using AutoMapper;
using Product.Application.Features.ProductFeatures.Commands;
using Product.Application.Features.ProductFeatures.DTOs;
using productNamespace = Product.Domain.Entities;

namespace Product.WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<productNamespace.Product, ProductDto>();
            CreateMap<productNamespace.Product, ProductDetailsDto>();
            CreateMap<CreateProductDto, CreateProductCommand>();
            CreateMap<UpdateProductDto, UpdateProductCommand>();    
           
        }
    }
}
