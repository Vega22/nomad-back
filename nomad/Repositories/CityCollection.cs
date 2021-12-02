using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using nomad.Models;

namespace nomad.Repositories
{
    public class CityCollection : ICityCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<cityModel> Collection;

        public CityCollection()
        {
            Collection = _repository.db.GetCollection<cityModel>("cities");
        }

        public async Task DeleteCity(string id)
        {
            var filter = Builders<cityModel>.Filter.Eq(s => s.Id, new ObjectId(id));
                await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<cityModel>> GetAllCities()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<cityModel> GetCityById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertCity(cityModel city)
        {
            await Collection.InsertOneAsync(city);
        }

        public async Task UpdateCity(cityModel city)
        {
            var filter = Builders<cityModel>
                .Filter
                .Eq(s => s.Id, city.Id);

            await Collection.ReplaceOneAsync(filter, city);
        }
    }
}
