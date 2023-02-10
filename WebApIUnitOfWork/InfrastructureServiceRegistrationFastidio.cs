using Microsoft.EntityFrameworkCore;
using WebApIUnitOfWork.Contracts;
using WebApIUnitOfWork.Models;
using WebApIUnitOfWork.Repositories;

namespace WebApIUnitOfWork
{
    public static  class InfrastructureServiceRegistrationFastidio
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepositoryFastidio<>), typeof(RepositoryBase<>));
            services.AddScoped<ITablaRepository, TablaRepository>();

            return services;
        }
    }
}
