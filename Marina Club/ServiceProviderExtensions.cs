using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
