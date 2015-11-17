using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mongodb_Model;
using MongoDB.Driver;

namespace MongoDb_Repository
{
    public class MongoSessionFactory
    {
        public static MongoDatabase GetMongoDatabase()
        {
            string connectionString = "mongodb://localhost:27017/";
            var mongoClientSettings = new MongoClientSettings();
            mongoClientSettings.Server = new MongoServerAddress(connectionString);
            var client = new MongoClient();
            var db = client.GetDatabase("BookMVC");
            var collection = db.GetCollection<Book>("Book");

            return client.GetServer().GetDatabase("BookMVC");
        }
    }
}
