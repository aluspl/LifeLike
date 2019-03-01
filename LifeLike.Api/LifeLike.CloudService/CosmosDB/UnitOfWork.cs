using System;
using LifeLike.CloudService.CosmosDB;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using Microsoft.Extensions.Configuration;

namespace LifeLike.CloudService.CosmosDB
{
    public class CosmosUnitOfWork : IUnitOfWork 
    {
        public CosmosUnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IRepository<T> Get<T>() where T : class
        {
            IRepository<T> repo = new DocumentDBRepository<T>(_configuration);
            return repo;
        }
        public Result Save()
        {
            try
            {
                return Result.Success;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }
        private readonly IConfiguration _configuration;
    }
       
}