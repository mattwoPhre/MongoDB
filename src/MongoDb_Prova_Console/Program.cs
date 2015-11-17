using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mongodb_Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDb_Prova_Console;

namespace MongoDb_Prova_Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("BookMVC");
            var collection = db.GetCollection<Book>("Book");

            var author = "John Smith";

            var books = collection
                .Find(b => b.Author == author)
                .Limit(5)
                .SortBy(b => b.Title)
                .ToListAsync()
                .Result;

            Console.WriteLine("Books : ");

            foreach (var book in books)
            {
                Console.WriteLine(" * " + book.Title);
            }

            Console.ReadLine();


            var firstBook = books.First();
            firstBook.Title = firstBook.Title.ToUpper(); //-- .ToLower() if u want to have back te original title
            SaveAsync(collection, firstBook).Wait();
        }

        public static async Task<ReplaceOneResult> SaveAsync<T>
            (this IMongoCollection<T> mongoCollection, T entity)
                        where T : IIdentified
        {
            return await mongoCollection.ReplaceOneAsync(i => i.Id == entity.Id,
                entity,
                new UpdateOptions() { IsUpsert = true }); //-- after .ToLower(), IsUpsert need to be false;
        }
    }
}

