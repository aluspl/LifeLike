using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace LifeLike.CloudService.Search
{
    public class SearchService
    {
        private readonly SearchServiceClient _serviceClient;

        private readonly SearchIndexClient _indexClient;

        public SearchService(IConfiguration configuration)
        {
            string searchServiceName = configuration["SearchServiceName"];
            string ApiKey = configuration["SearchServiceAdminApiKey"];

            _serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(ApiKey));
            _indexClient = new SearchIndexClient(searchServiceName, "hotels", new SearchCredentials(ApiKey));

        }
        public ICollection<T> Search<T>(string filter, string[] Select) where T : class
        {
            ICollection < T > returns= new List<T>();
            var parameters = new SearchParameters()
            {
                Filter = filter,
                Select = Select
            };

            var results = _indexClient.Documents.Search<T>("*", parameters);
            foreach(var result in results.Results)
            {
                returns.Add(result.Document);
            }
            return null;
        }
    }
}
