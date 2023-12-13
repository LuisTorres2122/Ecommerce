using Ecommerce.Repository.DBConext;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Repository.Implementation;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Utility;

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

                //AutoMapperService
                services.AddAutoMapper(typeof(AutoMapperProfile));
            });
        }

        
    }
}
