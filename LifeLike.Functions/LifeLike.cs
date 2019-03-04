using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace LifeLike.Function
{
    public static class LifeLike
    {  
        private static readonly Size size = new Size(320,240);

        [FunctionName("ImageResize")]
        public static void Run([BlobTrigger("photos/{name}", Connection = "ImageRepository")] Stream original, [Blob("thumbs/{name}", FileAccess.Write)] Stream resized)
        {
            var image = Image.FromStream(original);
            var thumbnail = image.GetThumbnailImage(size.Width, size.Height, null, IntPtr.Zero);
            thumbnail.Save(resized, ImageFormat.Jpeg);
        }
    }
}
