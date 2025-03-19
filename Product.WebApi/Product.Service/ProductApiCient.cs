using Microsoft.Extensions.Configuration;
using Product.Application.Features.ProductFeatures.DTOs;
using Product.Application.Interfaces;
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

        public void Delete(Guid id)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
            var uri = new Uri(apiUrl + id.ToString());
            var response = httpClient.DeleteAsync(uri).Result;
            if (!response.IsSuccessStatusCode) throw new Exception("Get Product Fail");
            var responseJson = response.Content.ReadAsStringAsync().Result;
            
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

        public ProductDetailsDto GetById(Guid id)
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

        public void Update(UpdateProductDto product)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
            var uri = new Uri(apiUrl);
            var response = httpClient.PutAsJsonAsync(uri, product).Result;
            if (!response.IsSuccessStatusCode) throw new Exception("Product Update Fail");
        }
    }
}
