using ASP.NET_CORE_MangoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ASP.NET_CORE_MangoDB.Controllers
{
    public class TestMongodb : Controller
    {

        public TestMongodb(IMongoClient mongoDB)
        {
            _mongoDB = mongoDB;

            //اگر این دیتابیس  نباشد میسازد
            _db = _mongoDB.GetDatabase("Persons");

            //اگر این کاایشن  نباشد میسازد
            _collection = _db.GetCollection<Person>("Person");
        }

        private readonly IMongoClient _mongoDB;

        private  IMongoDatabase _db;

        private  IMongoCollection<Person> _collection;

        // GET: TestMongodb
        public ActionResult Index()
        {
            var result= _collection.Aggregate<Person>();

            return View(result.ToList());
        }

        public ActionResult Details(string id)
        {
            var casttoobjectid = ObjectId.Parse(id);

            var filter = Builders<Person>.Filter.Eq(C => C._id, casttoobjectid);

            var result = _collection.Find<Person>(filter).FirstOrDefault();

            return View(result);
        }

        // GET: TestMongodb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestMongodb/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {
                _collection.InsertOne(person);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestMongodb/Edit/5
        public ActionResult Edit(string id)
        {
            var casttoobjectid = ObjectId.Parse(id);

            var filter=Builders<Person>.Filter.Eq(C=>C._id,casttoobjectid);

            var result = _collection.Find<Person>(filter).FirstOrDefault();
           
            return View(result);
        }

        // POST: TestMongodb/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string _id,Person person)
        {
            try
            {
                var updateOprator = Builders<Person>.Update.Set(C => C.Name, person.Name).Set(F=>F.Family,person.Family);

                var casttoobjectid = ObjectId.Parse(_id);

                var filter = Builders<Person>.Filter.Eq(C => C._id, casttoobjectid);

                _collection.FindOneAndUpdate(filter, updateOprator);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestMongodb/Delete/5
        public ActionResult Delete(string id)
        {
            var casttoobjectid = ObjectId.Parse(id);

            var filter = Builders<Person>.Filter.Eq(C => C._id, casttoobjectid);

            var result = _collection.Find<Person>(filter).FirstOrDefault();

            return View(result);
        }

        // POST: TestMongodb/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id,Person person)
        {
            try
            {
                var casttoobjectid = ObjectId.Parse(id);

                var filter = Builders<Person>.Filter.Eq(C => C._id, casttoobjectid);

                _collection.FindOneAndDelete(filter);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //hh
                return View();
            }
        }
    }
}
