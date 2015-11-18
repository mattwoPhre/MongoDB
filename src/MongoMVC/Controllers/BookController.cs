using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mongodb_Model;
using MongoDb_Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Core.Configuration;
using MongoMVC.Models;

namespace MongoMVC.Controllers
{
    public class BookController : Controller
    {
        public MongoDatabase _mongoDatabase;
        public IMongoCollection<Book> _mongoCollection;
        Repository _repo;
        public BookRisultatiViewModel bvm;

        public BookController()
        {
            _repo = new Repository();
            string connectionString = "mongodb://localhost:27017/";
            var mongoClientSettings = new MongoClientSettings();
            mongoClientSettings.Server = new MongoServerAddress(connectionString);
            var client = new MongoClient();
            var db = client.GetDatabase("BookMVC");
            var collection = db.GetCollection<Book>("Book");

        }



        // GET: Book
        public ActionResult Index()
        {

            return View("BookIndex");
        }



        [HttpPost]
        public ActionResult Cerca(string titolo)
        {
            List<Book> listaLibri = _repo.FindByTitle(titolo).ToList();

            TempData["Model"] = listaLibri;

            return View("Risultati", new BookRisultatiViewModel(listaLibri));
        }

        [HttpPost]
        public ActionResult CercaAutore(string autore)
        {
            List<Book> listaLibriAutori = _repo.FindByAuthor(autore).ToList();

			TempData["Model"] = listaLibriAutori;
			
            return View("RisultatiAutori", new BookRisultatiViewModel(listaLibriAutori));
        }

        public ActionResult CancellaLibro(string id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");

        }

        public ActionResult Aggiungi()
        {
            return View("AggiuntaLibro");
        }

        [HttpPost]
        public ActionResult AggiuntaLibro(Book book)
        {
            _repo.Add(book);
            return RedirectToAction("Index");
        }


        public ActionResult ModificaLibro(string id)
        {
            var bookList = TempData["Model"] as List<Book>;
            var Id = ObjectId.Parse(id);
            Book bookSearched = null;
            foreach (var item in bookList)
            {
                if (item.Id.Equals(Id))
                {
                    bookSearched = item;
                }
            }

            var bVM = new BookRisultatiViewModel();
            bVM.__book = bookSearched;

            return View("ModificaLibro", bVM);
        }

        [HttpPost]
        public ActionResult SalvaModifiche(string id, string titolo, string autore, string isbn, string publisher)
        {
            Book libro = new Book();
            libro.Id = ObjectId.Parse(id);
            libro.Title = titolo;
            libro.Author = autore;
            libro.ISBN = isbn;
            libro.Publisher = publisher;
            _repo.Update(libro);
            return RedirectToAction("Index");
        }

        
    }
}
