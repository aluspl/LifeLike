using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LifeLike.Shared;
using LifeLike.Shared.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LifeLike.CloudService.MongoDB
{
    internal class MongoDBRepository<T> : IRepository<T> where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;

        private readonly MongoClient _client;
        private readonly IMongoCollection<T> _collection;
        private const string DB = "DB";
        public MongoDBRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = configuration["CosmosDBName"];
            _client = new MongoClient(_connectionstring);
            _collection = GetCollection();
        }

        private IMongoDatabase GetDB()
        {
            return _client.GetDatabase(DB);
        }
        private IMongoCollection<T> GetCollection()
        {
            return GetDB().GetCollection<T>(typeof(T).Name);
        }
        public void Add(T entity)
        {
            _collection.InsertOne(entity);
        }

        public void Delete(Entity entity)
        {
            _collection.FindOneAndDelete(entity.Id);
        }

        public void DeleteAll()
        {
            GetDB().DropCollection(typeof(T).Name);
        }

        public T GetDetail(Expression<Func<T, bool>> predicate = null)
        {
            var item = GetCollection().Find(predicate);
            return item.SingleOrDefault();
        }

        public IEnumerable<T> GetOverview(Expression<Func<T, bool>> predicate = null)
        {
            var item = _collection.Find(predicate);
            return item.ToEnumerable();
        }

        public IQueryable<T> GetOverviewQuery(Expression<Func<T, bool>> predicate = null)
        {
            return _collection.AsQueryable();
        }

      
        public void Update(string id, T entity)
        {
            _collection.ReplaceOne(id, entity);
        }

        public void Update(Entity query, T entity)
        {
            _collection.ReplaceOne(query.Id, entity);
        }
    }
}