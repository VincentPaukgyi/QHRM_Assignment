using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Product.Application.Helpers;
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
        public class UpdateProductCommandHandler : DapperHelper, IRequestHandler<UpdateProductCommand, Guid>
        {
            public UpdateProductCommandHandler(IConfiguration configuration) : base(configuration){}
            public async Task<Guid> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    string selectquery = "SELECT Id, Name, Description, Price,CreatedDate,UpdatedDate FROM Products WHERE Id = @Id";
                    var product= await conn.QuerySingleOrDefaultAsync<productNamespace.Product>(selectquery, new { command.Id });
                    product.Update(command.Name, command.Description, command.Price);
                    string query = "UPDATE Products SET Name = @Name,Description=@Description, Price = @Price,UpdatedDate=@UpdatedDate WHERE Id = @Id; SELECT @Id";
                    return await conn.ExecuteScalarAsync<Guid>(query, product);
                }
            }
        }
    }
}
