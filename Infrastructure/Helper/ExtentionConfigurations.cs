using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helper
{
    public static class ExtentionConfigurations
    {
        public static void AppSettingConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<JwtToken>(Configuration.GetSection("Jwt"));

        }
    }
}
