using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Database.Data.Entities.Photo;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Interfaces.Media;
using LifeLike.Services.Commons.Models.Photo;
using LifeLike.Services.Domain.Services;

namespace LifeLike.Services.Media
{
    public class PhotoService : BaseService, IPhotoService
    {
        private readonly IRepository<PhotoEntity> _repo;
        private readonly IStorageService _storage;

        public PhotoService(IRepository<PhotoEntity> repo, IMapper mapper, IStorageService storage)
            : base(mapper)
        {
            _repo = repo;
            _storage = storage;
        }

        public async Task<ICollection<PhotoReadModel>> List()
        {
            var items = await _repo.GetAll();
            return _mapper.Map<ICollection<PhotoReadModel>>(items);
        }

        public async Task<PhotoReadModel> Get(Guid id)
        {
            var items = await _repo.Get(p => p.Id == id);
            return _mapper.Map<PhotoReadModel>(items);
        }

        public async Task<PhotoReadModel> Create(PhotoWriteModel model)
        {
            var photo = _mapper.Map<PhotoEntity>(model);

            photo = await _repo.Add(photo);
            return _mapper.Map<PhotoReadModel>(photo);
        }

        public async Task Delete(Guid id)
        {
            var item = await _repo.Get(p => p.Id == id);
            await _storage.Remove(item.Filename);
            await _repo.Delete(id);
        }
    }
}
