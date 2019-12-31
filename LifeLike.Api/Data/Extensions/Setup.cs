using LifeLike.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace LifeLike.Data.Extensions
{
    public static class Setup
    {
        private static string local= "Data Source=lifelike.db";

        public static IServiceCollection SetupSQL(this IServiceCollection services, string connection)
        {
            services.AddDbContext<PortalContext>(options => {
                options.UseSqlServer(connection, sqloption => sqloption.MigrationsAssembly("API"));
            });
            Debug.WriteLine("Using SQL");
            return services;
        }
        public static IServiceCollection SetupSQLite(this IServiceCollection services, string connection)
        {
            services.AddDbContext<PortalContext>(options =>
            {
                options.UseSqlite(local, sqloption => sqloption.MigrationsAssembly("API"));

            });
            Debug.WriteLine("Using SQLite");
            return services;
        }

    }
}
