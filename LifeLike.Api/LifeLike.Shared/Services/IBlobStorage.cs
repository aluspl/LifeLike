using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LifeLike.Shared.Services
{
    public interface IBlobStorage
    {
        Task<string> Create(BlobItem item);
        Task<Result> Remove(string fileName, string folder);
        Task<string> CreateThumb(string name, string folder);
    } 
}
