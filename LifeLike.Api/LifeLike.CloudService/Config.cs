using LifeLike.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LifeLike.CloudService
{
    public class Config
    {
        public static void SetupCloudServices(IServiceCollection services)
        {
            services.AddScoped<IBlobStorage, BlobStorage.BlobStorage>();
            services.AddScoped<IQueueService, Queue.QueueService>();
        }
    }
}
