using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Product.Application.Helpers;
using System.Data;
using productNamespace = Product.Domain.Entities;

namespace Product.Application.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<productNamespace.Product>>
    {

        public class GetAllProductsQueryHandler : DapperHelper, IRequestHandler<GetAllProductsQuery, IEnumerable<productNamespace.Product>>
        {
            public GetAllProductsQueryHandler(IConfiguration configuration) : base(configuration){}
            public async Task<IEnumerable<productNamespace.Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    string allSelectQuery = "SELECT Id, Name, Description, Price, CreatedDate, UpdatedDate FROM Products";
                    return await conn.QueryAsync<productNamespace.Product>(allSelectQuery);
                }
            }
        }
    }
}
