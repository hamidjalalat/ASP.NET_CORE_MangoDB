using MongoDB.Bson;

namespace ASP.NET_CORE_MangoDB.Controllers
{
    public class Person
    {
        public Person()
        {
                
        }
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

    }
}