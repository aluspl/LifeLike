using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Repositories;

namespace LifeLike.Repositories
{
    
    public  class ConfigRepository : IConfigRepository
    {
        private readonly IEventLogRepository _logger;
        private readonly PortalContext _context;

        public ConfigRepository( PortalContext context, IEventLogRepository logger)
        {
            _logger = logger;
            _context = context;
        }

        public static string WelcomeVideo = "WelcomeVideo";
        public static string WelcomeText = "WelcomeText";
        public static string RSS1 = "RSS1";
        public static string RSS2 = "RSS2";
        public static string RSSCount = "RSS2Count";
        public static string ADSLOT="ADSLOT";
        public static string  ADCLIENT="ADCLIENT";
        
        public async Task<Result> Create(Config model)
        {
            try
            {
                  _context.Add(model);
                 _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
              await _logger.AddExceptionLog(e);
                return   Result.Failed;
            }    
        }

        public  async Task<IEnumerable<Config>> List()
        {
            try
            {
                return _context.Configs.ToList();

            }
            catch (System.Exception e)
            {
                await _logger.AddExceptionLog(e);
                throw;
            }
        }

        public async Task<Config> Get(long id)
        {
            return await _context.Configs.FindAsync(id);
        }

        public async Task<Result> Update(Config model)
        {
            try
            {
                _context.Update(model);
                 _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                await _logger.AddExceptionLog(e);
                return   Result.Failed;
            }        
        }

        public async Task<Result> Delete(Config model)
        {
            try
            {
                _context.Remove(model);
                 _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                await _logger.AddExceptionLog(e);
                return Result.Failed;
            }
        }

        public async Task<Config> Get(string id)
        {
            try
            {
                return _context.Configs.FirstOrDefault(config => config.Name == id);
            }
            catch (Exception e)
            {
               await _logger.AddExceptionLog(e);
               return null;
            };
        }

    }

    public interface IConfigRepository: IRepository<Config>
    {
        Task<Config> Get(string id);
    }
}