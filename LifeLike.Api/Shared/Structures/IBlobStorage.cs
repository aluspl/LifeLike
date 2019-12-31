using LifeLike.Shared.Enums;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LifeLike.Shared.Structures
{
    public interface IBlobStorage
    {
        Task<string> Create(Stream stream, string fileName, string folder);
        Result Remove(string fileName, string folder);
        Task<string> CreateThumb(string name, string folder);
    } 
}
