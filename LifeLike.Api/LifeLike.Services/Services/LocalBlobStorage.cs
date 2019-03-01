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
        public async Task<string> Create(Stream stream, string fileName)
        {
            var uploadPath = Path.Combine(_hostingEnv.WebRootPath, "photos");

            using (var fileStream = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }
            return uploadPath;
        }

        public Result Remove(string fileName)
        {
            return Result.Success;
        }
    }
}
