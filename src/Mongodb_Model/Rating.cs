using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mongodb_Model
{
    public class Rating
    {
        public ObjectId UserId { get; set; }
        public int Value { get; set; }
    }
}
