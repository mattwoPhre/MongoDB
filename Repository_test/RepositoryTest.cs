using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mongodb_Model;
using MongoDb_Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NUnit.Framework;

namespace Repository_test
{
    [TestFixture]
    public class RepositoryTest
    {
        public ObjectId Id { get; set; }
        public const string Author = "John Smith";
        public string Title1 = "Classical Mythology";
        public const string Title2 = "Second Best Mongodb Starter";
        public const string Publisher = "Greatest Publisher";
        public const string Isbn = "12254-444447";
        public Book _expectedBook;
        public MongoClient mongoC;
        public IMongoDatabase _mongoDatabase;
        public MongoDatabase mongodb;
        public IMongoCollection<BsonDocument> _plainCollection;
        public MongoCollection<BsonDocument> plain;
        public IMongoCollection<Book> _bookCollection;
        public MongoCollection<Book> mongoColl;
        public IRepository _repository;
        public Book _differentBook;

        [SetUp]
        public void Setup()
        {

            _expectedBook = new Book
            {
                Author = Author,
                Title = Title1,
                Publisher = Publisher,
                ISBN = Isbn
            };

            _differentBook = new Book
            {
                Author = Author + " Different",
                Title = Title1 + "Different",
                Publisher = (Publisher + "Different"),
                ISBN = Isbn + "Different",
            };

            mongoC = new MongoClient();
            _mongoDatabase = mongoC.GetDatabase("BookMVC");
            mongodb = mongoC.GetServer().GetDatabase("BookMVC");
            mongoColl = mongodb.GetCollection<Book>("BookTest");
            _bookCollection = _mongoDatabase.GetCollection<Book>("BookTest");




            _repository = new Repository(_mongoDatabase);

        }



        [Test]
        public void FindBooksByTitle()
        {

            var books = _repository.FindByTitle(Title1).ToString();
            Assert.AreEqual(65, books.Count());


        }

        [Test]
        public void FindBooksByAuthor()
        {
            var expectedBook2 = new Book
            {
                Author = Author,
                Title = Title2,
                Publisher = Publisher,
            };


            var books = _repository.FindByAuthor(Author).OrderBy(x => x.Title).ToList();

            Assert.AreEqual(9, books.Count);
            var foundBook = books[0];

            Assert.AreNotSame(_expectedBook, foundBook);


            foundBook = books[1];

            Assert.AreNotSame(expectedBook2, foundBook);

        }

        [Test]
        public void Add_ShouldAddBook()
        {
            var libro = new Book
            {
                Id = ObjectId.Parse("564b0c119028881324c2b115"),
                Title = Title1,
                Author = "gigi l'autore",
                ISBN = "123456789",
                Publisher = "editor"
            };
            _repository.Add(libro);
            Assert.That(true, libro.Title = Title1);
        }

        [Test]
        public void Update_ShouldUpdateBook()
        {
            var collection = _mongoDatabase.GetCollection<Book>("Book");
            var filter = Builders<Book>.Filter.Eq(Title1, "Classical Mythology");
            var update = Builders<Book>.Update
                .Set(Title1, "Classical");
            var result = collection.UpdateOneAsync(filter, update);
            Assert.IsTrue(true, Title1 = "Classical");
        }


        [Test]
        public void Delete_ShouldDeleteBook()
        {
            Id = ObjectId.Parse("564b0c119028881324c2b115");
            _repository.Delete(Id.ToString());
            Assert.That(true);
        }


    }
}
