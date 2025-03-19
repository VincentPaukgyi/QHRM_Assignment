using Dapper;
using Microsoft.Extensions.Configuration;
using Product.Application.Helpers;
using Product.Application.Interfaces;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using productNamespace = Product.Domain.Entities;

namespace Product.Persistence.Services
{
    public class ProductRepository : DapperHelper, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration) { }
        public async Task<Guid> CreateAsync(productNamespace.Product product)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                string query = "INSERT INTO Products (Id,Name,Description,Price,CreatedDate) VALUES (@Id,@Name,@Description,@Price,@CreatedDate); SELECT @Id";
                return await conn.ExecuteScalarAsync<Guid>(query, product);
            }
        }

        public async Task<IEnumerable<productNamespace.Product>> GetAllAsync()
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                string allSelectQuery = "SELECT Id, Name, Description, Price, CreatedDate, UpdatedDate FROM Products";
                return await conn.QueryAsync<productNamespace.Product>(allSelectQuery);
            }
        }

        public async Task<productNamespace.Product> GetByIdAsync(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                string selectQuery = "SELECT Id, Name, Description, Price,CreatedDate,UpdatedDate FROM Products WHERE Id = @Id";
                return await conn.QuerySingleOrDefaultAsync<productNamespace.Product>(selectQuery, new { id });
            }
        }

        public async Task<Guid> UpdateAsync(productNamespace.Product product)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                string query = "UPDATE Products SET Name = @Name,Description=@Description, Price = @Price,UpdatedDate=@UpdatedDate WHERE Id = @Id; SELECT @Id";
                return await conn.ExecuteScalarAsync<Guid>(query, product);
            }
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                string query = "DELETE FROM Products WHERE Id = @Id";
                await conn.ExecuteAsync(query, new { id });
                return id;
            }
        }
    }
}
