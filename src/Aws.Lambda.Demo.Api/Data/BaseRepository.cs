using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Aws.Lambda.Demo.Api.Data.Abstraction;

namespace Aws.Lambda.Demo.Api.Data
{
    public class BaseRepository<TModel, TKey> : IRepository<TModel, TKey>
        where TModel : class, ITable<TKey>
    {
        private readonly DynamoDBContext _dbContext;

        protected BaseRepository(AmazonDynamoDBClient dbClient)
        {
            _dbContext = new DynamoDBContext(dbClient);
        }

        public Task<TModel> GetById(TKey id)
        {
            return _dbContext.LoadAsync<TModel>(id);
        }

        public Task Update(TModel model)
        {
            return _dbContext.SaveAsync(model);
        }
    }
}
