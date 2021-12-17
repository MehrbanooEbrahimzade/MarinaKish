using Infrastructure.Persist;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repository.classes;
using Infrastructure.Repository.interfaces;
namespace Infrastructure
{
    public static class DependencyInjectionPersist
    {
        public static IServiceCollection ConfigureApplicationPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("DB"));
            });
            return services; 

        }

    }
}
