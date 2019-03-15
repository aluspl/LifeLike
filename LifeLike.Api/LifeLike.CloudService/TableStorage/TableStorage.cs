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


        public async Task<IEnumerable<Statistic>> StatisticList()
        {
            var query = new TableQuery<StatisticEntity>();
            var result = await GetTable("Statistic").ExecuteQuerySegmentedAsync(query, null);
            return result.Results.Select(item => StatisticEntity.Convert(item));
            
        }

        public async Task<Result> Create(Statistic item)
        {
            var model = StatisticEntity.Convert(item);
            
            var insert = TableOperation.Insert(model);
            await GetTable("Statistic").ExecuteAsync(insert);
            return Result.Success;
        }


        public async Task<Result> Create(Log item)
        {
            var model = LogEntity.Convert(item);
           
            var insert = TableOperation.Insert(model);
            await GetTable("Log").ExecuteAsync(insert);
            return Result.Success;
        }
        
        public async Task<Result> Delete(Log item)
        {
            var model = LogEntity.Convert(item);

            var delete = TableOperation.Delete(model);
            await GetTable("Log").ExecuteAsync(delete);
            return Result.Success;
        }

        public async Task<IEnumerable<Log>> LogList()
        {
            var query = new TableQuery<LogEntity>();
            var result = await GetTable("Log").ExecuteQuerySegmentedAsync(query, null);
            return result.Results.Select(item => LogEntity.Convert(item));
        }

        public async Task<IEnumerable<Log>> LogList(EventLogType type)
        {
            var query = new TableQuery<LogEntity>();
            var result = await GetTable("Log").ExecuteQuerySegmentedAsync(query, null);
            return result.Results.Select(item => LogEntity.Convert(item));
        }

        public async Task<Result> Delete(Statistic item)
        {
            var model = StatisticEntity.Convert(item);

            TableOperation delete = TableOperation.Delete(model);
            await GetTable("Log").ExecuteAsync(delete);
            return Result.Success;
        }

        public async  Task<Result> DeleteAll(string v)
        {
            await GetTable(v).DeleteAsync();
            return Result.Success;
        }
    }
}
