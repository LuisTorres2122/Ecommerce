using Blazored.LocalStorage;
using Blazored.Toast;
using Ecommerce.WebAssembly.Services.Implementation;
using Ecommerce.WebAssembly.Services.Interfaces;

namespace Ecommerce.WebAssembly
{
    public static class ServiceConfiguration
    {
        public static void ConfigurationService(this IServiceCollection services)
        {
            //API
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5191/api/") });
           
            //Imports Package Nuget
            services.AddBlazoredLocalStorage();
            services.AddBlazoredToast();

            //servicios
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDashboard, DashBoardService>();
            services.AddScoped<IProducService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();

        }
    }
}
