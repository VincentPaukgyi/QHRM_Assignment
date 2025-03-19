using MediatR;
using Product.Application.Interfaces;
using productNamespace = Product.Domain.Entities;

namespace Product.Application.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<productNamespace.Product>
    {
        public Guid Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, productNamespace.Product>
        {
            private readonly IProductRepository _productRepository;
            public GetProductByIdQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<productNamespace.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                return await _productRepository.GetByIdAsync(query.Id);
            }
        }
    }
}
