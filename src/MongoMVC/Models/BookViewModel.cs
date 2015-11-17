using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Mongodb_Model;
using MongoDb_Repository;
using MongoDB.Driver;

namespace MongoMVC.Models
{
    public class BookViewModel
    {

        public IMongoDatabase _mongoDatabase;
        public MongoCollection<Book> _mongoCollection;

        public List<Book> _libri;
        public Repository repo;

        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string ISBN { get; set; }

        public BookViewModel()
        {
            
        }

        public BookViewModel(IEnumerable<Book> libri )
        {
            repo = new Repository(_mongoDatabase);
            _libri = repo.FindByTitle(Titolo) as List<Book>;
        }


    }
}