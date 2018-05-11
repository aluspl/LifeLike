using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;

        public VideoRepository(PortalContext context, IEventLogRepository logger)
        {
            _context = context;
            _logger = logger;
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
            return await _context.Videos.ToListAsync();
        }

        public async Task<Video> Get(long id)
        {
            return await _context.Videos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Result> Update(Video model)
        {
            try
            {
                _context.Update(model);
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
                _context.Remove(model);
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
                return await _context.Videos.Where(p => p.Category == category).ToListAsync();
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