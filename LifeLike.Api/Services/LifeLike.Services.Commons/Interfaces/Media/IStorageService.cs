#region Usings

using System.Threading.Tasks;
using LifeLike.Services.Commons.Models.Photo;
using Microsoft.AspNetCore.Http;

#endregion

namespace LifeLike.Services.Commons.Interfaces.Media
{
    public interface IStorageService
    {
        Task Remove(string filename);

        Task<PhotoWriteModel> Add(IFormFile model);
    }
}
