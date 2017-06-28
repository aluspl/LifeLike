using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;

namespace LifeLike.Repositories
{
    
    public  class ConfigRepository : IConfigRepository
    {
        private readonly PortalContext _context;

        public ConfigRepository(PortalContext context)
        {
            _context = context;
        }

        public Result Create(Config model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();
                return   Result.Failed;
            }    
        }

        public IEnumerable<Config> List()
        {
            return _context.Configs.ToList();
        }

        public Config Get(long id)
        {
            return _context.Configs.Find(id);
        }

        public Result Update(Config model)
        {
            try
            {
                _context.Update(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();
                return   Result.Failed;
            }        
        }

        public Result Delete(Config model)
        {
            try
            {
                _context.Remove(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();
                throw;
            }
        }

        public Config Get(string id)
        {
            try
            {
                return _context.Configs.FirstOrDefault(config => config.Name == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            };
        }
    }

    public interface IConfigRepository: IRepository<Config>
    {
        Config Get(string id);
    }
}