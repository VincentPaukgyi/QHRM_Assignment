using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using System.Data;
using productNamespace = Product.Domain.Entities;

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
            private readonly IApplicationDbContext _context;
            private readonly string _connectionString;
            public UpdateProductCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            public IDbConnection Connection
            {
                get
                {
                    return new SqlConnection(_connectionString);
                }
            }
            public async Task<Guid> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    string selectquery = "SELECT * FROM Products WHERE Id = @Id";
                    var product= await conn.QuerySingleOrDefaultAsync<productNamespace.Product>(selectquery, new { command.Id });
                    product.Update(command.Name, command.Description, command.Price);
                    string query = "UPDATE Products SET Name = @Name,Description=@Description, Price = @Price,UpdatedDate=@UpdatedDate WHERE Id = @Id; SELECT @Id";
                    return await conn.ExecuteScalarAsync<Guid>(query, product);
                }
            }
        }
    }
}
