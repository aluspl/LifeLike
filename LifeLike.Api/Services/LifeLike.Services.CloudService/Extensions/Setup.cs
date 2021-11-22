using LifeLike.Services.Commons.Interfaces.Media;
using Microsoft.Extensions.DependencyInjection;

namespace LifeLike.Services.Media.Extensions
{
    public static class Setup
    {
        public static IServiceCollection UseCloudServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            return services;
        }
    }
}
