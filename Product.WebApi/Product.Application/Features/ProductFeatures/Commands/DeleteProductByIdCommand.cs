using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Product.Application.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Guid>
        {
            private readonly string _connectionString;
            public DeleteProductByIdCommandHandler(IConfiguration configuration)
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
            public async Task<Guid> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    string query = "DELETE FROM Products WHERE Id = @Id";
                    await conn.ExecuteAsync(query, new { command.Id });
                    return command.Id;
                }
            }
        }
    }
}
