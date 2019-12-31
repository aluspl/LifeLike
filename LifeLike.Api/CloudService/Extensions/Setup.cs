using LifeLike.CloudService.BlobStorage;
using LifeLike.CloudService.Queue;
using LifeLike.Shared.Structures;
using Microsoft.Extensions.DependencyInjection;

namespace LifeLike.CloudService.Extensions
{
    public static class Setup
    {
        public static IServiceCollection UseCloudServices(this IServiceCollection services)
        {
            services.AddScoped<IBlobStorage, BlobStorageService>();
            services.AddScoped<IQueueService, QueueService>();
            return services;
        }
    }
}
