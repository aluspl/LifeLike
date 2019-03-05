using LifeLike.Shared.Enums;
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
        public async Task<string> Create(Stream stream, string fileName, string folder)
        {
            var uploadPath = Path.Combine(_hostingEnv.WebRootPath, folder);

            using (var fileStream = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }
            return $"http://localhost/{folder}/{fileName}";
        }

        public Task<string> CreateThumb(string name, string folder)
        {
            throw new NotImplementedException();
        }

        public Result Remove(string fileName, string folder)
        {
            return Result.Success;
        }
    }
}
