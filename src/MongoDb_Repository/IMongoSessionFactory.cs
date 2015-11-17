using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDb_Repository
{
    public interface IMongoSessionFactory
    {
        MongoDatabase GetMongoDatabase();
    }
}
