using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using System.Collections.Generic;

namespace LifeLike.Shared.Structures
{
    public interface IVideoService
    {
        Result Create(Video model);
        Result Delete(string id);
        IEnumerable<Video> List(VideoCategory category);
        IEnumerable<Video> List();
    }
}
