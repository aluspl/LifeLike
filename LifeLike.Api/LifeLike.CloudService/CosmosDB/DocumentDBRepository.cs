using LifeLike.Shared;
using LifeLike.Shared.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LifeLike.CloudService.CosmosDB
{
    public class DocumentDBRepository<T> : IRepository<T>
    {
        private readonly IConfiguration _configuration;
        private readonly string _CosmosDBName;

        private DocumentClient _client { get; }

        public DocumentDBRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var EndpointUri = configuration["CosmosDBEndpoint"];
            var CosmosDBKey = configuration["CosmosDBKey"];
            _CosmosDBName = configuration["CosmosDBName"];

            _client = new DocumentClient(new Uri(EndpointUri), CosmosDBKey);
            _client.CreateDatabaseIfNotExistsAsync(new Database { Id = _CosmosDBName }).Wait();
            _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_CosmosDBName), new DocumentCollection { Id = typeof(T).Name }).Wait();
        }
        private Uri GetCollection()
        {
            return UriFactory.CreateDocumentCollectionUri(_CosmosDBName, typeof(T).Name);
        }
        private Uri GetDocument(string id)
        {
            return UriFactory.CreateDocumentUri(_CosmosDBName, typeof(T).Name, id);
        }
        public void Add(T entity)
        {
            _client.CreateDocumentAsync(GetCollection(), entity).Wait();
        }

        public void Delete(Entity entity)
        {            
            _client.DeleteDocumentAsync(GetDocument(entity.Id)).Wait();
        }

        public void DeleteAll()
        {
            _client.DeleteDocumentCollectionAsync(GetCollection()).Wait();
        }

        public T GetDetail(Expression<Func<T, bool>> predicate = null)
        {
            var queryOptions = new FeedOptions { MaxItemCount = 1 };

            var query = this._client.CreateDocumentQuery<T>(GetCollection()).Where(predicate);
            return query.Single();
        }

        public IEnumerable<T> GetOverview(Expression<Func<T, bool>> predicate = null)
        {
            var queryOptions = new FeedOptions { MaxItemCount = -1 };
            var query = predicate != null ? _client.CreateDocumentQuery<T>(GetCollection()).Where(predicate) : _client.CreateDocumentQuery<T>(GetCollection());
            return query.AsEnumerable();     
        }

        public IQueryable<T> GetOverviewQuery(Expression<Func<T, bool>> predicate = null)
        {
            var queryOptions = new FeedOptions { MaxItemCount = -1 };
            var query = predicate != null ? _client.CreateDocumentQuery<T>(GetCollection()).Where(predicate) : _client.CreateDocumentQuery<T>(GetCollection());
            return query;
        }

        public void Update(T entity)
        {
            _client.ReplaceDocumentAsync(GetDocument("0"), entity).Wait();
        }
    }
}
