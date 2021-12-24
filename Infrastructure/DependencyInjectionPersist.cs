using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
