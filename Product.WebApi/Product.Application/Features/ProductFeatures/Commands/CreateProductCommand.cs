using MediatR;
using Microsoft.Extensions.Configuration;
using Product.Application.Interfaces;
using System.Data;
using productNamespace = Product.Domain.Entities;
using Microsoft.Data.SqlClient;
using Dapper;
using Product.Application.Helpers;


namespace Product.Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public class CreateProductCommandHandler : DapperHelper, IRequestHandler<CreateProductCommand, Guid>
        {
            public CreateProductCommandHandler(IConfiguration configuration) : base(configuration){}
            public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = productNamespace.Product.Create(command.Name, command.Description, command.Price);
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    string query = "INSERT INTO Products (Id,Name,Description,Price,CreatedDate) VALUES (@Id,@Name,@Description,@Price,@CreatedDate); SELECT @Id";
                    return await conn.ExecuteScalarAsync<Guid>(query, product);
                }
            }
        }
    }
}
