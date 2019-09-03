using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using LifeLike.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            container.CreateIfNotExistsAsync().Wait();
            return container;
        }

        public CloudBlobClient BlobClient { get; }

        public async Task<string> Create(BlobItem item)
        {
            var container = GetContainer(item.Container);
            var blob = container.GetBlockBlobReference(item.Name);
            await blob.UploadFromStreamAsync(item.Stream);            
            return blob.Uri.AbsoluteUri;
        }
        public async Task<IEnumerable<BlobItem>> GetList(string folder)
        {
            var container = GetContainer(folder);
            var blob = await container.ListBlobsSegmentedAsync(null);
            return blob.Results.Select(p =>new BlobItem
            {
                StorageUri = p.StorageUri.PrimaryUri,
                Uri = p.Uri,
                Container = p.Container.Name
            });
        }
        public BlobItem Get(string name, string folder)
        {
            var container = GetContainer(folder);
            var blob = container.GetBlockBlobReference(name);

            return GenerateBlob(blob);
        }
        public async Task<Result> Update(BlobItem item)
        {          
            try
            {
                var container = GetContainer(item.Container);
                var blob = container.GetBlockBlobReference(item.Name);
                await blob.UploadFromStreamAsync(item.Stream);
                return Result.Success;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }

        private static BlobItem GenerateBlob(CloudBlockBlob blob)
        {
            return new BlobItem
            {
                Container = blob.Container.Name,
                StorageUri = blob.StorageUri.PrimaryUri,
                Uri = blob.Uri,
                Name = blob.Name
            };
        }


        public async Task<Result> Remove(string name, string folder)
        {
            try
            {
                var container = GetContainer(folder);

                var blob = container.GetBlockBlobReference(name);
                await blob.DeleteAsync();
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
