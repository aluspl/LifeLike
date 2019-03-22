using LifeLike.Services.ViewModel;
using LifeLike.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeLike.Services.Structures
{
    public interface IPhotoService
    {
        Task<Result> Create(Photo photo);
        Photo Get(string id);
        ICollection<Photo> List();
        Result Update(Photo photo);
        Result Delete(string id);
        Task<string> Upload(IFormFile file);
    }
}
