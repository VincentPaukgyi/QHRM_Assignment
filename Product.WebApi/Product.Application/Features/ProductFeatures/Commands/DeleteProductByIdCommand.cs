using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Product.Application.Helpers;
using System.Data;

namespace Product.Application.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public class DeleteProductByIdCommandHandler : DapperHelper, IRequestHandler<DeleteProductByIdCommand, Guid>
        {
            public DeleteProductByIdCommandHandler(IConfiguration configuration) : base(configuration){}
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
