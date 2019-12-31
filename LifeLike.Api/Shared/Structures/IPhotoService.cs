using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeLike.Shared.Structures
{
    public interface IPhotoService
    {
        Task<Result> Create(Photo photo);
        Photo Get(string id);
        ICollection<Photo> List();
        Result Update(Photo photo);
        Result Delete(string id);

    }
}
