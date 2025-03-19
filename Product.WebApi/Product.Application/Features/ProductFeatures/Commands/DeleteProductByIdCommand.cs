using MediatR;
using Product.Application.Interfaces;

namespace Product.Application.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Guid>
        {
            private readonly IProductRepository _productRepository;
            public DeleteProductByIdCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Guid> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
               return await _productRepository.DeleteAsync(command.Id);
            }
        }
    }
}
