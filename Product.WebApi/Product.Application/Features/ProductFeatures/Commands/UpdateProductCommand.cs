using MediatR;
using Product.Application.Interfaces;

namespace Product.Application.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
        {
            private readonly IProductRepository _productRepository;
            public UpdateProductCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Guid> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id);
                product.Update(command.Name, command.Description, command.Price);
               return await _productRepository.UpdateAsync(product);
            }
        }
    }
}
