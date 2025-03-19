using Dapper;
using Microsoft.Extensions.Configuration;
using Product.Application.Helpers;
using Product.Application.Interfaces;
using System.Data;
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
                DynamicParameters dynamicParameters = new();
                dynamicParameters.Add("id", product.Id);
                dynamicParameters.Add("name", product.Name);
                dynamicParameters.Add("description", product.Description);
                dynamicParameters.Add("price", product.Price);
                dynamicParameters.Add("createdDate", product.CreatedDate);

                return await conn.ExecuteScalarAsync<Guid>("CreateProduct", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<productNamespace.Product>> GetAllAsync()
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                return await conn.QueryAsync<productNamespace.Product>("GetAllProduct");
            }
        }

        public async Task<productNamespace.Product> GetByIdAsync(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                return await conn.QuerySingleOrDefaultAsync<productNamespace.Product>("GetProductById", new { id });
            }
        }

        public async Task<Guid> UpdateAsync(productNamespace.Product product)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                DynamicParameters dynamicParameters = new();
                dynamicParameters.Add("id", product.Id);
                dynamicParameters.Add("name", product.Name);
                dynamicParameters.Add("description", product.Description);
                dynamicParameters.Add("price", product.Price);
                dynamicParameters.Add("updatedDate", product.UpdatedDate);
                return await conn.ExecuteScalarAsync<Guid>("UpdateProduct", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                await conn.ExecuteAsync("DeleteProductById", new { id });
                return id;
            }
        }
    }
}
