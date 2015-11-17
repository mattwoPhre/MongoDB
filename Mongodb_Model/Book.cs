using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mongodb_Model
{
    public class Book : IIdentified
    {
        private readonly List<Book> _libri;
        public ObjectId Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Published { get; set; }
        public string Publisher { get; set; }
        public ImageUrl[] ImageUrls { get; set; }
        public Rating[] Ratings { get; set; }


        public Book(List<Book> libri)
        {
            _libri = libri;
        }

        public Book()
        {

        }
    }


    public interface IIdentified
    {
        ObjectId Id { get; }
    }
}
