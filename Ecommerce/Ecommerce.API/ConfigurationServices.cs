using Ecommerce.Repository.DBConext;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Repository.Implementation;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Utility;
using Microsoft.AspNetCore.Identity;
using ecommerce.Services.Interfaces;
using ecommerce.Services.Implementation;

namespace Ecommerce.API
{
    public static class ConfigurationServices
    {
    
        public static void ConfigurationDb(this IServiceCollection services, IConfiguration configuration)
        {
            //EF
            services.AddDbContext<EcommerceContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));



                //Services
                services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped<ISaleRepository, SaleRepository>();
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<ICategorySevice, CategoryService>();
                services.AddScoped<ISaleService, ISaleService>();
                services.AddScoped<IProductService, ProductService>();
                services.AddScoped<IDashBoardService, DashBoardService>();

                //AutoMapperService
                services.AddAutoMapper(typeof(AutoMapperProfile));
            });
        }

        
    }
}
