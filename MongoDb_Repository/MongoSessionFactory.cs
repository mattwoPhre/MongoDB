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
            //const string uri = "mongodb://localhost:27017/";
            //var client = new MongoClient(uri);
            //var db = client.GetDatabase(new MongoUrl(uri).DatabaseName);
            //var collection = db.GetCollection<Book>("Books");
            //return client.GetServer().GetDatabase("BookMVC");




            //var connectionString = "mongodb://localhost:27017/";
            //var client = new MongoClient(connectionString).GetServer();
            //var db = client.GetDatabase("BookMVC");
            //var collection = db.GetCollection<Book>("Books");
            //return client.GetDatabase("BookMVC");

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
