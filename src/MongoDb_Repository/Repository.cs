using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Mongodb_Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver.Linq;

namespace MongoDb_Repository
{
    public class Repository : IRepository
    {
        public MongoClient _mongoClient;
        public  IMongoDatabase _mongoDatabase;
        public MongoDatabase mongoDb;
        public  IMongoCollection<Book> _mongoCollection;
        public MongoCollection<Book> mongoColl;
        public MongoSessionFactory _msf;
        

        public Repository(IMongoDatabase database)
        {
            _mongoClient = new MongoClient();
            _mongoDatabase = _mongoClient.GetDatabase("BookMVC");
            mongoDb = _mongoClient.GetServer().GetDatabase("BookMVC");

            _mongoCollection = _mongoDatabase.GetCollection<Book>("Book");
            mongoColl = mongoDb.GetCollection<Book>("Book");

        }

        public Repository()
        {
            _mongoClient = new MongoClient();
            _mongoDatabase = _mongoClient.GetDatabase("BookMVC");
            mongoDb = _mongoClient.GetServer().GetDatabase("BookMVC");
            mongoColl = mongoDb.GetCollection<Book>("Book");
            _mongoCollection = _mongoDatabase.GetCollection<Book>("Book");

        }

        public IEnumerable<Book> FindByTitle(string title)
        {
            return _mongoCollection.AsQueryable().Where(book => book.Title.Contains(title) );
        }

        public IEnumerable<Book> FindByAuthor(string author)
        {
            return _mongoCollection.AsQueryable().Where(book => book.Author.Contains(author));
        }

        public void Add(Book book)
        {
            mongoColl.Insert(book);
        }

      

        public void Delete(string id)
        {
            var query = (Query.EQ("_id", ObjectId.Parse(id)));

            mongoColl.Remove(query);
        }

        public void Update(Book book)
        {
            mongoColl.Save(book);
        }

       
    }
}
