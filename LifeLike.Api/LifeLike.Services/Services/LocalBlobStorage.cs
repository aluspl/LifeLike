using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using LifeLike.Shared.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LifeLike.Services.Services
{
    public class LocalBlobStorage : IBlobStorage
    {
        private readonly IHostingEnvironment _hostingEnv;

        public LocalBlobStorage(IHostingEnvironment hosting)
        {
            _hostingEnv = hosting;
        }
        public async Task<string> Create(BlobItem item)
        {
            var uploadPath = Path.Combine(_hostingEnv.WebRootPath, item.Container);

            using (var fileStream = new FileStream(Path.Combine(uploadPath, item.Name), FileMode.Create))
            {
                await item.Stream.CopyToAsync(fileStream);
            }
            return $"http://localhost/{item.Container}/{item.Name}";
        }

        public async Task<string> CreateThumb(string name, string folder)
        {
            await Task.Delay(100);
            return $"http://localhost/{folder}/{name}";
        }

        public async Task<Result> Remove(string fileName, string folder)
        {
            await Task.Delay(100);
            return Result.Success;
        }
    }
}
