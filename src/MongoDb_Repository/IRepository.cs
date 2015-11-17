using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mongodb_Model;

namespace MongoDb_Repository
{
    public interface IRepository
    {
        IEnumerable<Book> FindByTitle(string title);
        IEnumerable<Book> FindByAuthor(string author);
        void Add(Book book);
        void Delete(string id);
        void Update(Book book);
    }
}
