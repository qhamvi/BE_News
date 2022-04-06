using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using website.Entities;

namespace website.Repositories

{
    public class MongoDbImagesRepository : IImagesRepository
    {
        private readonly IMongoCollection<Image> imagesCollection;

        private const string databaseName = "website";
        public const string collectionName = "images";
        private readonly FilterDefinitionBuilder<Image> filterBuilder = Builders<Image>.Filter;

        public MongoDbImagesRepository(IMongoClient mongoClient2)
        {
            IMongoDatabase database = mongoClient2.GetDatabase(databaseName);
            imagesCollection = database.GetCollection<Image>(collectionName);
        }
        public List<Image> Images => throw new NotImplementedException();

        public async Task<IEnumerable<Image>> GetImagesAsync()
        {
            return await imagesCollection.Find(new BsonDocument()).ToListAsync();

        }
        public async Task<Image> GetImageAsync(Guid idImage)
        {
            var filter = filterBuilder.Eq(account => account._id, idImage);
            return await imagesCollection.Find(filter).SingleOrDefaultAsync();
        }
        public async Task UpdateImageAsync(Image image)
        {
            var filter = filterBuilder.Eq(existingAccount => existingAccount._id, image._id);
            await imagesCollection.ReplaceOneAsync(filter, image);
        }
        public async Task DeleteImageAsync(Guid idImage)
        {
            var filter = filterBuilder.Eq(account => account._id, idImage);
            await imagesCollection.DeleteOneAsync(filter);
        }

        public async Task CreateImageAsync(Image image)
        {
            await imagesCollection.InsertOneAsync(image);
        }
    }
}