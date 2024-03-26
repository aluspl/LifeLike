using LifeLike.Database.Data.Entities.Photo;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Interfaces.Media;
using LifeLike.Services.Commons.Models.Photo;
using LifeLike.Services.Domain.Profiles;
using LifeLike.Services.Domain.Services;

namespace LifeLike.Services.Media;

public class PhotoService : BaseService, IPhotoService
{
    private readonly IRepository<ImageEntity> _repo;
    private readonly IStorageService _storage;

    public PhotoService(IRepository<ImageEntity> repo, IStorageService storage)
        : base()
    {
        _repo = repo;
        _storage = storage;
    }

    public async Task<ICollection<PhotoModel>> List()
    {
        var items = await _repo.GetAll();
        return items.Select(x => x.Map()).ToList();
    }

    public async Task<PhotoModel> Get(Guid id)
    {
        var item = await _repo.Get(p => p.Id == id);
        return item.Map();
    }

    public async Task<PhotoModel> Create(PhotoWriteModel model)
    {
        var photo = ImageEntity.New(model.Url, model.Filename, model.ThumbnailFilename, model.ThumbnailUrl);
        photo = await _repo.Add(photo);
        return photo.Map();
    }

    public async Task Delete(Guid id)
    {
        var item = await _repo.Get(p => p.Id == id);
        await _storage.Remove(item.Filename);
        await _repo.Delete(id);
    }
}