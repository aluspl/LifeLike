using AutoMapper;

namespace LifeLike.Services.Domain.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper _mapper;

        protected BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
