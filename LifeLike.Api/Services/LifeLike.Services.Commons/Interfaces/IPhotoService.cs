using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Services.Commons.Models.Photo;

namespace LifeLike.Services.Commons.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoReadModel> Create(PhotoWriteModel photoWriteModel);

        Task<PhotoReadModel> Get(Guid id);

        Task<ICollection<PhotoReadModel>> List();

        Task Delete(Guid id);
    }
}
