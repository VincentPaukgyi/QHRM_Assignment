﻿using AutoMapper;
using Product.Application.Features.ProductFeatures.Commands;
using Product.Application.Features.ProductFeatures.DTOs;
using productNamespace= Product.Domain.Entities;

namespace Product.WebApp.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<productNamespace.Product, ProductDto>();
            CreateMap<CreateProductDto, CreateProductCommand>();
            CreateMap<UpdateProductDto, UpdateProductCommand>();
            CreateMap<ProductDetailsDto, UpdateProductDto>();
        }
    }
}
