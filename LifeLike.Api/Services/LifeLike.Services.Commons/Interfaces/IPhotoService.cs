using LifeLike.Services.Commons.Models.Photo;

namespace LifeLike.Services.Commons.Interfaces;

public interface IPhotoService
{
    Task<PhotoModel> Create(PhotoWriteModel photoWriteModel);

    Task<PhotoModel> Get(Guid id);

    Task<ICollection<PhotoModel>> List();

    Task Delete(Guid id);
}