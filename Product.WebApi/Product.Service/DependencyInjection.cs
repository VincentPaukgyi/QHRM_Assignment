using Microsoft.Extensions.DependencyInjection;
using Product.Application.Interfaces;

namespace Product.Service
{
    public static class DependencyInjection
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IProductApiClient, ProductApiCient>();
        }
    }
}
