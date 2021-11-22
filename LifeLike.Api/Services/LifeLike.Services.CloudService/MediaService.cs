#region Usings

using System.IO;
using LifeLike.Common.Config;
using LifeLike.Services.Commons.Interfaces.Media;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

#endregion

namespace LifeLike.Services.Media
{
    public class MediaService : IMediaService
    {
        #region Privates

        private readonly ILogger<MediaService> Logger;
        private readonly AzureStorageConfig AzureOptions;

        #endregion

        #region Constructors

        public MediaService(
            ILogger<MediaService> logger,
            IOptions<AzureStorageConfig> options)
        {
            AzureOptions = options.Value;
            Logger = logger;
        }

        #endregion

        #region Public Methods

        public byte[] ResizeImage(byte[] file)
        {
            if (file.Length <= 0)
            {
                return file;
            }

            using var image = Image.Load(file);
            using var outputStream = new MemoryStream();
            ResizeImage(image, AzureOptions.MaxImageSize);
            image.Save(outputStream, PngFormat.Instance);
            file = outputStream.ToArray();

            return file;
        }

        #endregion

        #region Utils

        private void ResizeImage(Image<Rgba32> image, int maxImageSize)
        {
            var width = image.Width;
            var height = image.Height;
            image.Mutate(
                p => p.Resize(new ResizeOptions
                {
                    Size = new Size(maxImageSize, maxImageSize),
                    Mode = ResizeMode.Max,
                }));
            Logger.LogInformation($"Image Resized from {width} x {height} to {image.Width} {image.Height}");
        }

        #endregion
    }
}
