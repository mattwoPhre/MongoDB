using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mongodb_Model;
using MongoDb_Repository;
using MongoDB.Bson;

namespace MongoMVC.Models
{
    public class BookRisultatiViewModel
    {
        public List<Book> books { get; set; }
        public List<Book> booksAutori { get; set; } 
        public IEnumerable<Book> _book { get; set; }
        public Book __book { get; set; }
        

        public BookRisultatiViewModel(Book libro)
        {
            Repository repo = new Repository();
            __book = libro;
            books = repo.FindByTitle(libro.Title).ToList();
            booksAutori = repo.FindByAuthor(libro.Author).ToList();
        }

        public BookRisultatiViewModel()
        {
            
        }

        public BookRisultatiViewModel(List<Book> _books)
        {
            
            books = _books;
            booksAutori = _books;

        }

        public string Id
        {
            get
            {
               
                return __book.Id.ToString() ;
            }
        }

        public string Titolo
        {
            
            get {
                if (string.IsNullOrWhiteSpace(__book.Title))
                {
                    return "No titolo";
                }
                return __book.Title; }
        }

        public string Autore
        {
            get {
                if (string.IsNullOrWhiteSpace(__book.Author))
                {
                    return "No autore";
                }
                return __book.Author; }
        }

        public string Isbn
        {
            get
            {
                if (string.IsNullOrWhiteSpace(__book.ISBN))
                {
                    return "No ISBN";
                }
                return __book.ISBN;
            }
        }

        public string Publisher
        {
            get
            {
                if (string.IsNullOrWhiteSpace(__book.Publisher))
                {
                    return "No Publisher";
                }
                return __book.Publisher;
            }
        }
    }
}