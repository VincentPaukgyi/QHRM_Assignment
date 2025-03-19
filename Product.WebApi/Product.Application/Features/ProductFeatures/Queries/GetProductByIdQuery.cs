using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Product.Application.Helpers;
using System.Data;
using productNamespace = Product.Domain.Entities;

namespace Product.Application.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<productNamespace.Product>
    {
        public Guid Id { get; set; }
        public class GetProductByIdQueryHandler : DapperHelper, IRequestHandler<GetProductByIdQuery, productNamespace.Product>
        {
            public GetProductByIdQueryHandler(IConfiguration configuration) : base(configuration) { }
            public async Task<productNamespace.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    string selectQuery = "SELECT Id, Name, Description, Price,CreatedDate,UpdatedDate FROM Products WHERE Id = @Id";
                    return await conn.QuerySingleOrDefaultAsync<productNamespace.Product>(selectQuery, new { query.Id });
                }
            }
        }
    }
}
