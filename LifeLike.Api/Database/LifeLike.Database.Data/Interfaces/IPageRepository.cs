using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LifeLike.Database.Data.Entities;
using LifeLike.Database.Data.Entities.Page;

namespace LifeLike.Database.Data.Interfaces
{
    public interface IPageRepository : IRepository<PageEntity>
    {
    }
}
