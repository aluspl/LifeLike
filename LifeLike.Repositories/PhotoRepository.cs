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
    
    public  class PhotoService : IPhotoService
    {
        private readonly PortalContext _context;
        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        public PhotoService(PortalContext context, ILogService logger, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public static readonly string PhotoPath =  "/photos/";


        public async Task<Result> Create(Photo model)
        {
            try
            {
                
                _context.Add(_mapper.Map<PhotoEntity>(model));
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
              await _logger.AddException(e);
                return   Result.Failed;
            }    
        }

        public async Task<IEnumerable<Photo>> List()
        {
            var items =   await _context.Photos.ToListAsync();
            return _mapper.Map<IEnumerable<Photo>>(items);

        }

        public async Task<Photo> Get(long id)
        {
            try
            {
                var items=  await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);       
                return _mapper.Map<Photo>(items);
            }
            catch (Exception e)
            {
                 await _logger.AddException(e);

                return   null;
            }
        }
  
        public async Task<Result> Update(Photo model)
        {
            try
            {
                _context.Update(_mapper.Map<PhotoEntity>(model));
              await  _context.SaveChangesAsync();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return   Result.Failed;
            }        
        }

        public async Task<Result> Delete(Photo model)
        {
            try
            {
                _context.Remove(_mapper.Map<PhotoEntity>(model));
                await _context.SaveChangesAsync();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
               await _logger.AddException(e);

                return   Result.Failed;
            }
        }

        public async Task<Result> Create(Photo photo, long modelGalleryId)
        {
            try
            {
                var gallery = _context.Galleries
                    .Where(p => p.Id == modelGalleryId)
                    .Include(p=>p.Photos)
                    .SingleOrDefault();
                if (gallery == null) return Result.Failed;
                gallery.Photos.Add(_mapper.Map<PhotoEntity>(photo));
                _context.SaveChanges();
                return  Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return   Result.Failed;
            }           
        }
    }
    
    public interface IPhotoService : IRepository<Photo>
    {
        Task<Result> Create(Photo photo, long modelGalleryId);
    }
}