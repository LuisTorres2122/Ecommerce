using Blazored.LocalStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Ecommerce.WebAssembly.Extensions;
using Ecommerce.WebAssembly.Services.Implementation;
using Ecommerce.WebAssembly.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

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
           // services.AddBlazoredToast();
            services.AddSweetAlert2();

            //servicios
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDashboard, DashBoardService>();
            services.AddScoped<IProducService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();

            //Authetication
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, AutenticationExtension>();

        }
    }
}
