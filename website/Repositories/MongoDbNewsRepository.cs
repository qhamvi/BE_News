using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using website.Entities;

namespace website.Repositories
{
    public class MongoDbNewsRepository : NNewsRepository
    {
        private readonly IMongoCollection<New> newsCollection;

        private const string databaseName = "website";
        public const string collectionName = "news";
        private readonly FilterDefinitionBuilder<New> filterBuilder = Builders<New>.Filter;

        public MongoDbNewsRepository(IMongoClient mongoClient3)
        {
            IMongoDatabase database = mongoClient3.GetDatabase(databaseName);
            newsCollection = database.GetCollection<New>(collectionName);
        }

        public List<New> News => throw new NotImplementedException();

        public async Task CreateNewAsync(New new2)
        {
            await newsCollection.InsertOneAsync(new2);
        }

        public async Task DeleteNewAsync(Guid idNeww)
        {
            var filter = filterBuilder.Eq(neww => neww._id, idNeww);
            await newsCollection.DeleteOneAsync(filter);
        }

        public async Task<New> GetNewAsync(Guid idNeww)
        {
            var filter = filterBuilder.Eq(neww => neww._id, idNeww);
            return await newsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<New> GetNewFalseAsync(Guid idNeww)
        {
            var filter = filterBuilder.Where(neww => neww._id == idNeww && neww.status == false);
            return await newsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<New>> GetNewsAsync() 
        {
            return await newsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<New>> GetNewsTrueAsync()
        {
            var filter = filterBuilder.Where(neww => neww.status == true);
            // return newsCollection.Find(new BsonDocument()).ToList();
            return await newsCollection.Find(filter).ToListAsync();
        }

        public async Task<New> GetNewTrueAsync(Guid idNeww)
        {
            // var filter = filterBuilder.Eq(neww => neww._id, idNeww);
            var filter2 = filterBuilder.Where(neww => neww._id == idNeww && neww.status == true);
            return await newsCollection.Find(filter2).SingleOrDefaultAsync();
        }

        public async Task OkeyUpdateNewAsync(New new2)
        {
            var filter = filterBuilder.Eq(existingNew => existingNew._id, new2._id);
            await newsCollection.ReplaceOneAsync(filter, new2);

        }

        public async Task UpdateNewAsync(New new2)
        {
            var filter = filterBuilder.Eq(existingNew => existingNew._id, new2._id);
            await newsCollection.ReplaceOneAsync(filter, new2);
        }

        public async Task DeleteNewFalseAsync(Guid idNeww)
        {
            var filter = filterBuilder.Where(neww => neww._id == idNeww && neww.status == false);
            await newsCollection.DeleteOneAsync(filter);
        }

    }

}