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
    public class GalleryRepository : IGalleryRepository
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;
        private readonly IMapper _mapper;

        public GalleryRepository(PortalContext context, IEventLogRepository logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
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
            var items =  await _context.Galleries
                .Include(p => p.Photos)
                .ToListAsync();
            return _mapper.Map<IEnumerable<Gallery>>(items);
        }

        public async Task<Gallery> Get(long id)
        {
            var gallery = await _context.Galleries
                .Where(p => p.Id == id)
                .Include(p => p.Photos)
                .SingleOrDefaultAsync();
            return _mapper.Map<Gallery>(gallery);
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

                if (model.Photos!=null)
                {
                    var photo = _mapper.Map<IEnumerable<PhotoEntity>>(model);
                    _context.RemoveRange(photo);
                }
                _context.Remove( _mapper.Map<GalleryEntity>(model));
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
                return _mapper.Map<Gallery>(gallery);
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