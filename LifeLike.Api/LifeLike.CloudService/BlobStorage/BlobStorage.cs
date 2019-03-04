using LifeLike.Shared.Enums;
using LifeLike.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LifeLike.CloudService.BlobStorage
{
    public class BlobStorage : IBlobStorage
    {
        public BlobStorage(IConfiguration configuration)
        {

            var storageAccount = CloudStorageAccount.Parse(configuration["BlobStorage"]);
            BlobClient = storageAccount.CreateCloudBlobClient();
        }

        private CloudBlobContainer GetContainer(string folder)
        {
            var container = BlobClient.GetContainerReference(folder);
            Task.Run(async () => await container.CreateIfNotExistsAsync());
            return container;
        }

        public CloudBlobClient BlobClient { get; }

        public async Task<string> Create(Stream stream, string name, string folder)
        {
            var container = GetContainer(folder);
            var blob = container.GetBlockBlobReference(name);
            await blob.UploadFromStreamAsync(stream);
            return blob.Uri.AbsoluteUri;
        }

        public Result Remove(string name, string folder)
        {
            try
            {
                var container = GetContainer(folder);

                var blob = container.GetBlockBlobReference(name);
                blob.DeleteAsync().Wait();
                return Result.Success;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }
    }
}
