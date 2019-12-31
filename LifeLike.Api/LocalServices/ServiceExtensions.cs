using LifeLike.Shared.Structures;
using Microsoft.Extensions.DependencyInjection;

namespace LifeLike.LocalServices
{
    public static class ServiceExtensions
    {
        public static IServiceCollection UseLocalServices(this IServiceCollection services)
        {
            services.AddScoped<IBlobStorage, LocalBlobStorage>();
            services.AddScoped<IQueueService, QueueService>();
            return services;
        }
    }
}
