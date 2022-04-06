using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using website.Entities;

namespace website.Repositories
{
    public class MongoDbUserRepository : UUsersRepository
    {
        private string databaseName ="website";
        private string collectionName = "users";
        private readonly IMongoCollection<User> usersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;
        
        public MongoDbUserRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);
        }
        public  async Task CreateUserAsync(User user)
        {
            await usersCollection.InsertOneAsync(user);
        }

        public  async Task<User> GetUserAsync(Guid idUser)
        {
            var filter = filterBuilder.Eq(user => user._id, idUser);
            return await usersCollection.Find(filter).SingleOrDefaultAsync();
        }

        public  async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await usersCollection.Find(new BsonDocument()).ToListAsync();        
        }

        public  async Task UpdateUserAsync(User user)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser._id , user._id);
            await usersCollection.ReplaceOneAsync(filter, user);
        }

        public  async Task DeleteUserAsync(Guid idUser)
        {
            var filter = filterBuilder.Eq(user => user._id, idUser);
            await usersCollection.DeleteOneAsync(filter);
        }
    }
}