using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using website.Entities;

namespace website.Repositories
{
    public class MongoDbReasonsRepository : RReasonsRepository
    {

        private readonly IMongoCollection<Reason> reasonsCollection;

        private const string databaseName = "website";
        public const string collectionName = "reasons";
        private readonly FilterDefinitionBuilder<Reason> filterBuilder = Builders<Reason>.Filter;


        public MongoDbReasonsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            reasonsCollection = database.GetCollection<Reason>(collectionName);
        }

        public List<Reason> Reasons => throw new NotImplementedException();

        public async Task CreateReasonAsync(Reason reason)
        {
            await reasonsCollection.InsertOneAsync(reason);
        }

        public async Task DeleteReasonAsync(Guid idReason)
        {
            var filter = filterBuilder.Eq(reason => reason._id, idReason);
            await reasonsCollection.DeleteOneAsync(filter);
        }

        public async Task<Reason> GetReasonAsync(Guid idReason)
        {
            var filter = filterBuilder.Eq(reason => reason._id, idReason);
            return await reasonsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Reason>> GetReasonsAsync()
        {
            return await reasonsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateReasonAsync(Reason reason)
        {
            var filter = filterBuilder.Eq(existingReason => existingReason._id, reason._id);
            await reasonsCollection.ReplaceOneAsync(filter, reason);

        }
    }

}