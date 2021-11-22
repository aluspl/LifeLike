#region Usings

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

#endregion

namespace LifeLike.Services.Commons.Extensions
{
    public static class BlobExtensions
    {
        public static async Task<byte[]> DownloadToByteArrayAsync(this BlobClient blobClient)
        {
            try
            {
                await using var stream = new MemoryStream();
                await blobClient.DownloadToAsync(stream);
                return stream.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Stream ConvertJsonToStream(this string json)
        {
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(json);
            writer.Flush();
            ms.Position = 0;
            return ms;
        }
    }
}
