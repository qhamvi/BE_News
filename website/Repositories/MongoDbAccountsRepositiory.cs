using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using website.Entities;

namespace website.Repositories
{
    public class MongoDbAccountsRepository : AAccountsRepository
    {
        // public List<Account> Accounts => throw new NotImplementedException();

        private readonly IMongoCollection<Account> accountsCollection;

        private const string databaseName = "website";
        public const string collectionName = "accounts";
        private readonly FilterDefinitionBuilder<Account> filterBuilder = Builders<Account>.Filter;


        public MongoDbAccountsRepository(IMongoClient mongoClient)
        {
            // my csdl = mongo khach hang. co duoc csdl(databaseName)
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            accountsCollection = database.GetCollection<Account>(collectionName);
        }

        public async Task CreateAccountAsync(Account account)
        {
            await accountsCollection.InsertOneAsync(account);
        }
        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await accountsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Account> GetAccountAsync(Guid idAccount)
        {
            var filter = filterBuilder.Eq(account => account._id, idAccount);
            return await accountsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            var filter = filterBuilder.Eq(existingAccount => existingAccount._id, account._id);
            await accountsCollection.ReplaceOneAsync(filter, account);
        }

        public async Task DeleteAccountAsync(Guid idAccount)
        {
            var filter = filterBuilder.Eq(account => account._id, idAccount);
            await accountsCollection.DeleteOneAsync(filter);
        }
    }

}