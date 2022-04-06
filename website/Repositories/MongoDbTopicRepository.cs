using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using website.Entities;

namespace website.Repositories
{
    public class MongoDbTopicsRepository : TTopicsRepository
    {
        private readonly IMongoCollection<Topic> topicsCollection;

        private const string databaseName = "website";
        public const string collectionName = "topics";
        private readonly FilterDefinitionBuilder<Topic> filterBuilder = Builders<Topic>.Filter;

        public MongoDbTopicsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            topicsCollection = database.GetCollection<Topic>(collectionName);
        }

        public List<Topic> Topics => throw new System.NotImplementedException();

        public async Task CreateTopicAsync(Topic topic)
        {
            await topicsCollection.InsertOneAsync(topic);
        }

        public async Task DeleteTopicAsync(string idTopic)
        {
            var filter = filterBuilder.Eq(topic => topic._id,idTopic);
            await topicsCollection.DeleteOneAsync(filter);
        }

        public async Task<Topic> GetTopicAsync(string idTopic)
        {
            var filter = filterBuilder.Eq(topic => topic._id,idTopic);
            return await topicsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsAsync()
        {
            return await topicsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateTopicAsync(Topic topic)
        {
            var filter = filterBuilder.Eq(existingTopic => existingTopic._id, topic._id);
            await topicsCollection.ReplaceOneAsync(filter, topic);
        }
    }
}