using KPT_back.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace KPT_back.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Gpu> _gpusCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _gpusCollection = database.GetCollection<Gpu>(mongoDBSettings.Value.CollectionName);
        }

        public async Task CreateAsync(Gpu gpu)
        {
            await _gpusCollection.InsertOneAsync(gpu);
            return;
        }

        public async Task<List<Gpu>> GetAsync()
        {
            //var filter = new BsonDocument();
            return await _gpusCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddToGpuAsync(string id, string gpuId)
        {
            FilterDefinition<Gpu> filter = Builders<Gpu>.Filter.Eq("Id", id);
            UpdateDefinition<Gpu> update = Builders<Gpu>.Update.AddToSet<string>("gpus", gpuId);
            await _gpusCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Gpu> filter = Builders<Gpu>.Filter.Eq("Id", id);
            await _gpusCollection.DeleteOneAsync(filter);
            return;
        }
        
    }
}