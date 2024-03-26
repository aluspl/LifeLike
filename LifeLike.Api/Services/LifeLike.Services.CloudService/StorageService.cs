#region Usings

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using LifeLike.Common.Config;
using LifeLike.Services.Commons.Interfaces.Media;
using LifeLike.Services.Commons.Models.Photo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

#endregion

namespace LifeLike.Services.Media;

public class StorageService : IStorageService
{
    #region Private members

    private readonly AzureStorageConfig _azureStorageConfig;
    private readonly BlobServiceClient _cloudBlobClient;
    private readonly IMediaService _mediaService;
    private readonly ILogger<StorageService> _logger;

    #endregion

    #region Constructor(s)

    public StorageService(
        IOptions<AzureStorageConfig> options,
        IMediaService mediaService,
        ILogger<StorageService> logger)
    {
        _azureStorageConfig = options.Value;
        _mediaService = mediaService;
        _logger = logger;
        _cloudBlobClient = GetStorageAccount();
    }

    #endregion

    #region Public


    public async Task Remove(string id)
    {
        await DeleteFiles(id);
    }

    public async Task<PhotoWriteModel> Add(IFormFile model)
    {
        var result = new PhotoWriteModel
        {
            Filename = $"{DateTime.UtcNow.ToLongTimeString()}.{model.Name}",
        };

        var image = await UploadImageAsync(model, result.Filename);
        var thumb = await UploadThumbAsync(model, result.Filename);
        result.Url = image.Uri.ToString();
        result.ThumbnailUrl = thumb.Uri.ToString();
        result.ThumbnailFilename = result.Filename;
        return result;
    }

    #endregion
    #region Helpers

    #region Cloud

    private BlobServiceClient GetStorageAccount()
    {
        try
        {
            return new BlobServiceClient(_azureStorageConfig.ConnectionString);
        }
        catch (Exception exception)
        {
            throw new Exception("Unexpected error while creating cloud client.", exception);
        }
    }

    #endregion

    #region Blob

    private async Task<BlockBlobClient> UploadImageAsync(IFormFile formFile, string resultFilename)
    {
        var container = await GetPhotoContainer();

        var file = container.GetBlockBlobClient(resultFilename);
        await file.DeleteIfExistsAsync();

        await using var stream = formFile.OpenReadStream();
        await file.UploadAsync(stream);

        return file;
    }

    private async Task<BlockBlobClient> UploadThumbAsync(IFormFile formFile, string resultFilename)
    {
        var container = await GetThumbContainer();

        var file = container.GetBlockBlobClient(resultFilename);
        await file.DeleteIfExistsAsync();

        await using var stream = formFile.OpenReadStream();
        var bytes = ReadFully(stream);

        var image = _mediaService.ResizeImage(bytes);

        await using var writeStream = new MemoryStream(image);
        await file.UploadAsync(writeStream);

        return file;
    }

    private async Task DeleteFiles(string fileName)
    {
        var container = await GetPhotoContainer();

        var file = container.GetBlockBlobClient(fileName);
        await file.DeleteIfExistsAsync();
    }

    private async Task<BlobContainerClient> GetPhotoContainer()
    {
        var container = _cloudBlobClient.GetBlobContainerClient(Photos);
        await container.CreateIfNotExistsAsync();
        await container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
        return container;
    }

    public static byte[] ReadFully(Stream input)
    {
        using var ms = new MemoryStream();
        input.CopyTo(ms);
        return ms.ToArray();
    }

    private async Task<BlobContainerClient> GetThumbContainer()
    {
        var container = _cloudBlobClient.GetBlobContainerClient(Thumbs);
        await container.CreateIfNotExistsAsync();
        await container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
        return container;
    }
    private const string Photos = "Photos";

    private const string Thumbs = "Thumbs";

    #endregion

    #endregion
}