using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;

        public GalleryRepository(PortalContext context, IEventLogRepository logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Result> Create(Gallery model)
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

        public async Task<IEnumerable<Gallery>> List()
        {
            return await _context.Galleries
                .Include(p => p.Photos)
                .ToListAsync();
        }

        public async Task<Gallery> Get(long id)
        {
            var gallery = await _context.Galleries
                .Where(p => p.Id == id)
                .Include(p => p.Photos)
                .SingleOrDefaultAsync();
            return gallery;
        }

        public async Task<Result> Update(Gallery model)
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

        public async Task<Result> Delete(Gallery model)
        {
            try
            {
                model = await Get(model.Id);
                if (model == null) return Result.Failed;

                foreach (var photo in model.Photos)
                {
                    _context.Remove(photo);
                }

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

        public async Task<Gallery> Get(string shortTitle)
        {
            try
            {
                var gallery = await _context.Galleries
                    .Where(p => p.ShortTitle == shortTitle)
                    .Include(p => p.Photos)
                    .SingleOrDefaultAsync();
                return gallery;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return null;
            }
        }
    }

    public interface IGalleryRepository : IRepository<Gallery>
    {
        Task<Gallery> Get(string id);
    }
}