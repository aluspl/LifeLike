using LifeLike.Shared.Enums;
using LifeLike.Shared.Services;
using LifeLike.Structures.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LifeLike.CloudService.BlobStorage
{
    public class BlobStorage: IBlobStorage
    {
        public BlobStorage(IConfiguration configuration)
        {
            var storageAccount = CloudStorageAccount.Parse(configuration["BlobStorage"]);

            BlobClient = storageAccount.CreateCloudBlobClient();
            Container = BlobClient.GetContainerReference("images");
            Task.Run(async ()=>await Container.CreateIfNotExistsAsync());
        }

        public CloudBlobClient BlobClient { get; }
        public CloudBlobContainer Container { get; }

        public async Task<string> Create(Stream stream, string name)
        {
            var blob = Container.GetBlockBlobReference(name);
            await blob.UploadFromStreamAsync(stream);
            return blob.Uri.AbsoluteUri;
        }

        public Result Remove(string name)
        {
            try
            {
                var blob = Container.GetBlockBlobReference(name);
                Task.Run(async () => await blob.DeleteAsync());
                return Result.Success;
            }
            catch (Exception)        
            {
                return Result.Failed;
            }        
        }
    }
}
