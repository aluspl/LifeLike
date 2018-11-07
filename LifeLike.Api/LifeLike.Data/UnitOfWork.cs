using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;

namespace LifeLike.Data
{
    public class UnitOfWork : IUnitOfWork 
    {
        public UnitOfWork(PortalContext db)
        {
            this.db= db;
        }

        public IRepository<T> Get<T>() where T : class
        {
            IRepository<T> repo = new Repository<T>(db);
            return repo;
        }
        public Result Save()
        {
            try
            {
                db.SaveChanges();
                return Result.Success;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }
        private readonly PortalContext db;
    }
       
}