using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;
        private IMapper _mapper;

        public VideoRepository(PortalContext context, IEventLogRepository logger, IMapper mapper )
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Result> Create(Video model)
        {
            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return Result.Failed;
            }
        }

        public async Task<IEnumerable<Video>> List()
        {
            var items = await _context.Videos.ToListAsync();
            return _mapper.Map<IEnumerable<Video>>(items);

        }

        public async Task<Video> Get(long id)
        {
            var item = await _context.Videos.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Video>(item);
        }

        public async Task<Result> Update(Video model)
        {
            try
            {
                _context.Update(_mapper.Map<VideoEntity>(model));
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Result> Delete(Video model)
        {
            try
            {
                
                _context.Remove(_mapper.Map<VideoEntity>(model));
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return Result.Failed;
            }
        }

        public async Task<IEnumerable<Video>> List(VideoCategory category)
        {
            try
            {
                var items =await _context.Videos.Where(p => p.Category == category).ToListAsync();
                return _mapper.Map<IEnumerable<Video>>(items);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return null;
            }
        }
    }

    public interface IVideoRepository : IRepository<Video>
    {
        Task<IEnumerable<Video>> List(VideoCategory category);
    }
}