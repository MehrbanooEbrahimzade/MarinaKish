using System;
using Infrastructure.Persist;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club
{
    public static class ServiceProviderExtensions
    {
        public static void MigrateDatabases(this IServiceProvider provider)
        {
            using (provider.CreateScope())
            using (var context = provider.GetRequiredService<DatabaseContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}
