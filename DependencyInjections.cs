using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Contents.Application.Interfaces;

namespace Contents.Persistence
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ContentsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IContentsDbContext>(provider =>
                provider.GetService<ContentsDbContext>());

            return services;
        }
    }
}
