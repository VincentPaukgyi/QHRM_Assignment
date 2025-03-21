﻿using MediatR;
using Product.Application.Interfaces;
using productNamespace = Product.Domain.Entities;


namespace Product.Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
        {
            private readonly IProductRepository _productRepository;
            public CreateProductCommandHandler(IProductRepository productRepository) 
            {
                _productRepository = productRepository;
            }
            public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = productNamespace.Product.Create(command.Name, command.Description, command.Price);
                return await _productRepository.CreateAsync(product);
            }
        }
    }
}
