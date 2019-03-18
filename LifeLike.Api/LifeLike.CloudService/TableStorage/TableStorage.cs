using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using LifeLike.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeLike.CloudService.TableStorage
{
    public class TableStorage : ITableStorage
    {
        private readonly CloudTableClient _tableClient;

        public bool IsWorking { get => _tableClient != null; }

        public TableStorage(IConfiguration configuration)
        {
            try
            {
                var storageAccount = CloudStorageAccount.Parse(configuration["BlobStorage"]);
                _tableClient = storageAccount.CreateCloudTableClient();

            }
            catch
            {
                _tableClient = null;
            }
        }

        private CloudTable GetTable(string tableName)
        {
            var _table = _tableClient.GetTableReference("photos");
            _table.CreateIfNotExistsAsync().Wait();
            return _table;
        }


        public async Task<IEnumerable<Log>> List()
        {
            var query = new TableQuery<ItemEntity>();
            var result = await GetTable("Logs").ExecuteQuerySegmentedAsync(query, null);
            return result.Results.Select(item => ItemEntity.Convert(item));            
        }
        public async Task<IEnumerable<Log>> List(string type)
        {
            var query = new TableQuery<ItemEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey",QueryComparisons.Equal, type));

            var result = await GetTable("Logs").ExecuteQuerySegmentedAsync(query, null);
            return result.Results.Select(item => ItemEntity.Convert(item));
        }
        public async Task<Log> GetItem(string type, string id)
        {
            var query = TableOperation.Retrieve<ItemEntity>(type, id);
            var result = await GetTable("Logs").ExecuteAsync(query);
            return ItemEntity.Convert((ItemEntity)result.Result);
        }
        public async Task<Result> Create(Log item)
        {
            var model = ItemEntity.Convert(item);
           
            var insert = TableOperation.Insert(model);
            await GetTable("Logs").ExecuteAsync(insert);
            return Result.Success;
        }
        
        public async Task<Result> Delete(Log item)
        {
            var model = ItemEntity.Convert(item);

            var delete = TableOperation.Delete(model);
            await GetTable("Logs").ExecuteAsync(delete);
            return Result.Success;
        }
        public async  Task<Result> DeleteAll(string v)
        {
            await GetTable(v).DeleteAsync();
            return Result.Success;
        }

        public async Task<Result> Update(string id, Log value)
        {
            var model = ItemEntity.Convert(value);

            var replace = TableOperation.Replace(model);
            await GetTable("Logs").ExecuteAsync(replace);
            return Result.Success;
        }
    }
}
