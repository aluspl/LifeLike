using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Category;
using LifeLike.Services.Domain.Services;

namespace LifeLike.Services.Page
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IRepository<CategoryEntity> _repository;

        public CategoryService(IRepository<CategoryEntity> repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<CategoryReadModel> Create(CategoryWriteModel model)
        {
            var item = _mapper.Map<CategoryEntity>(model);
            item = await _repository.Add(item);
            return _mapper.Map<CategoryReadModel>(item);
        }

        public async Task<IEnumerable<CategoryReadModel>> List()
        {
            var items = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CategoryReadModel>>(items);
        }

        public async Task<CategoryReadModel> Get(Guid id)
        {
            var item = await _repository.Get(o => o.Id == id);
            return _mapper.Map<CategoryReadModel>(item);
        }

        public async Task<CategoryReadModel> Update(Guid id, CategoryWriteModel model)
        {
            var item = await _repository.Get(o => o.Id == id);
            _mapper.Map(model, item);
            item = await _repository.Update(item);
            _mapper.Map(model, item);
            return _mapper.Map<CategoryReadModel>(item);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(o => o.Id == id);
        }
    }
}
