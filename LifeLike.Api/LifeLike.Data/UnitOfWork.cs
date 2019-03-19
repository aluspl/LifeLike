using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LifeLike.Data
{
    public class UnitOfWork : IUnitOfWork 
    {
        //public UnitOfWork(IConfiguration configuration)
        //{
        //    this.db= CreateDbContext(configuration["DB"]);
        //}
        //public PortalContext CreateDbContext(string args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<PortalContext>();
        //    if (args == null)
        //    {
        //            optionsBuilder.UseSqlite("Data Source=lifelike.db");
        //    }
        //    else
        //    {
        //               optionsBuilder.UseSqlServer(args,
        //               b => b.MigrationsAssembly("LifeLike.Data"));
        //    }
        //    return new PortalContext(optionsBuilder.Options);
        //}
        public UnitOfWork(PortalContext context)
        {
            this.db = context;
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