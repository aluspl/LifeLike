using LifeLike.CloudService.CosmosDB;
using LifeLike.Shared;
using LifeLike.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LifeLike.CloudService
{
    public static class Config
    {
        public static void SetupCloudServices(this IServiceCollection services)
        {
            services.AddScoped<IBlobStorage, BlobStorage.BlobStorage>();
            services.AddScoped<IQueueService, Queue.QueueService>();
        }
        public static void SetupCosmosDB(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, CosmosUnitOfWork>();
        }
    }
}
