﻿using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using productNamespace = Product.Domain.Entities;

namespace Product.Application.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<productNamespace.Product>
    {
        public Guid Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, productNamespace.Product>
        {
            private readonly string _connectionString;
            public GetProductByIdQueryHandler(IConfiguration configuration)
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
            public async Task<productNamespace.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    string selectQuery = "SELECT * FROM Products WHERE Id = @Id";
                    return await conn.QuerySingleOrDefaultAsync<productNamespace.Product>(selectQuery, new { query.Id });
                }
            }
        }
    }
}
