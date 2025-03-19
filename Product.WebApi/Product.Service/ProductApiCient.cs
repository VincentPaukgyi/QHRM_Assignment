using Microsoft.Extensions.Configuration;
using Product.Application.Features.ProductFeatures.DTOs;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using System.Net.Http.Json;
using System.Text.Json;

namespace Product.Service
{
    public class ProductApiCient : IProductApiClient
    {
        private readonly string apiUrl;
        public ProductApiCient(IConfiguration configuration)
        {
            apiUrl = configuration["WebApiUrl"];
        }
        public void Create(CreateProductDto product)
        {
            var httpClient= new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
            var uri= new Uri(apiUrl);
           var response= httpClient.PostAsJsonAsync(uri,product).Result;
            if (!response.IsSuccessStatusCode) throw new Exception("Product Creation Fail");
        }

        public Guid Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> GetAll()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
            var uri = new Uri(apiUrl);
            var response = httpClient.GetAsync(uri).Result;
            if (!response.IsSuccessStatusCode) throw new Exception("Get List Fail");
            var responseJson=response.Content.ReadAsStringAsync().Result;
            var productList=JsonSerializer.Deserialize<List<ProductDto>>(responseJson);
            return productList;
        }

        public ProductDto GetById(Guid id)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
            var uri = new Uri(apiUrl+id.ToString());
            var response = httpClient.GetAsync(uri).Result;
            if (!response.IsSuccessStatusCode) throw new Exception("Get Product Fail");
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var product = JsonSerializer.Deserialize<ProductDetailsDto>(responseJson);
            return product;
        }

        public Guid Update(UpdateProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
