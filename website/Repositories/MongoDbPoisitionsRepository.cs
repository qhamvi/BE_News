using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using website.Entities;

namespace website.Repositories
{
    public class MongoDbPoisitionsRepository : PPositionsRepository
    {
        private readonly IMongoCollection<Position> positionsCollection;

        private const string databaseName = "website";
        public const string collectionName = "positions";
        private readonly FilterDefinitionBuilder<Position> filterBuilder = Builders<Position>.Filter;


        public MongoDbPoisitionsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            positionsCollection = database.GetCollection<Position>(collectionName);
        }

        public List<Position> Positions => throw new System.NotImplementedException();

        public async Task CreatePositionAsync(Position position)
        {
            await positionsCollection.InsertOneAsync(position);
        }

        public async Task DeletePositionAsync(string idPosition)
        {
            var filter = filterBuilder.Eq(position => position._id,idPosition);
            await positionsCollection.DeleteOneAsync(filter);        
        }

        public async Task<Position> GetPositionAsync(string idPosition)
        {
            var filter = filterBuilder.Eq(position => position._id,idPosition);
            return await positionsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await positionsCollection.Find(new BsonDocument()).ToListAsync();

        }

        public async Task UpdatePositionAsync(Position position)
        {
            var filter = filterBuilder.Eq(existingPosition => existingPosition._id, position._id);
            await positionsCollection.ReplaceOneAsync(filter, position);
        }

    }
}