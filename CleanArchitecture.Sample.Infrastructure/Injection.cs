using CleanArchitecture.Sample.Application.Interfaces.Repositories;
using CleanArchitecture.Sample.Infrastructure.Data;
using CleanArchitecture.Sample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Sample.Infrastructure
{
    public static class Injection
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    options => {
                        options.MigrationsAssembly(typeof(SqlDbContext).Assembly.FullName);
                        options.EnableRetryOnFailure();
                    });
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}