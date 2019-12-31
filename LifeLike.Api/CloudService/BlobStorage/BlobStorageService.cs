using LifeLike.Shared.Enums;
using LifeLike.Shared.Structures;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LifeLike.CloudService.BlobStorage
{
    public class BlobStorageService : IBlobStorage
    {
        public BlobStorageService(IConfiguration configuration)
        {

            var storageAccount = CloudStorageAccount.Parse(configuration["BlobStorage"]);
            BlobClient = storageAccount.CreateCloudBlobClient();
        }

        private CloudBlobContainer GetContainer(string folder)
        {
            var container = BlobClient.GetContainerReference(folder);
            container.CreateIfNotExistsAsync().Wait();
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

        public async Task<string> CreateThumb(string name, string folder)
        {
            var mainContainer = GetContainer("photos");
            var max = mainContainer.GetBlockBlobReference(name);
            var thumbContainer = GetContainer(folder);
            var thumb = thumbContainer.GetBlockBlobReference(name);

            await thumb.StartCopyAsync(max.Uri);
            return thumb.Uri.AbsoluteUri;
        }
    }
}
