using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using productNamespace = Product.Domain.Entities;

namespace Product.Application.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<productNamespace.Product>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<productNamespace.Product>>
        {
            private readonly string _connectionString;

            public GetAllProductsQueryHandler(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            public IDbConnection Connection
            {
                get
                {
                    return new SqlConnection(_connectionString);
                }
            }
           
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
