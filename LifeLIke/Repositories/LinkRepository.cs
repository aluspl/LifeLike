using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;

namespace LifeLike.Repositories
{
    
    public  class LinkRepository : ILinkRepository
    {
        private readonly LifeLikeContext _context;

        public LinkRepository(LifeLikeContext context)
        {
            _context = context;
        }

        public IEnumerable<LinkDataModel> List()
        {
            return _context.Links.ToList();
        }

        public LinkDataModel Get(long id)
        {
            return _context.Links.Find(id);
        }

        public Result Update(LinkDataModel model)
        {
            try
            {
                _context.Update(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                _context.EventLogs.Add(EventLogDataModel.Generate(e));
                _context.SaveChanges();
                return   Result.Failed;
            }        }

        public Result Delete(LinkDataModel model)
        {
            try
            {
                _context.Remove(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                _context.EventLogs.Add(EventLogDataModel.Generate(e));
                _context.SaveChanges();
                return   Result.Failed;
            }
        }

        public IEnumerable<LinkDataModel> List(LinkCategory category)
        {
            return _context.Links.Where(p=>p.Category==category);
        }
    }
    
    public interface ILinkRepository : IRepository<LinkDataModel>
    {
        IEnumerable<LinkDataModel> List(LinkCategory category);
    }
}