using System;
using MongoDB.Driver;

namespace nomad.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbUser:zKUbff-#kL4!eyR@cluster0.csdgr.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            client = new MongoClient(settings);
            db = client.GetDatabase("myFirstDatabase");
        }
    }
}
