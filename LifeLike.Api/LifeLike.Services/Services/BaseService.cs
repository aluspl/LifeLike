using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using LifeLike.Data;

namespace LifeLike.Services
{
    public class BaseService<T> where T : class
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<T> _repo;
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.Get<T>();
        }
        public T GetEntity(Expression<Func<T, bool>> predicate = null)
        {
           return _repo.GetDetail(predicate);
        }
        public void DeleteEntity(Expression<Func<T, bool>> predicate = null)
        {
            var item =_repo.GetDetail(predicate);    
            _repo.Delete(item);   
        }
        public IEnumerable<T> GetAllEntities()
        {
            return _repo.GetOverview();
        }
        public void CreateEntity(T item)
        {
            _repo.Add(item);
        }
        public bool IsAnyEntity(Expression<Func<T, bool>> predicate = null)
        {
            return _repo.GetOverviewQuery(predicate).Any();
        }
        public void UpdateEntity(T item)
        {
            _repo.Update(item);
        }
    }
}
