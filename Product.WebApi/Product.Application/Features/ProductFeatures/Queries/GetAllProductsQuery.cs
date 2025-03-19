using MediatR;
using Product.Application.Interfaces;
using productNamespace = Product.Domain.Entities;

namespace Product.Application.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<productNamespace.Product>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<productNamespace.Product>>
        {
            private readonly IProductRepository _productRepository;
            public GetAllProductsQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IEnumerable<productNamespace.Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                return await _productRepository.GetAllAsync();
            }
        }
    }
}
