using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace XamarinMongoDB
{

	public class MongoRepository : IRepository
	{
		public async Task<List<Person>> FindAll()
		{
			var client = new MongoClient ("mongodb://localhost");
			var database = client.GetDatabase ("testdb");
			var collection = database.GetCollection<Person> ("people");
			var list = await collection.Find(_ => true).ToListAsync();

			return list;
		}

		public async void Find ()
		{
			var client = new MongoClient ("mongodb://localhost");
			var database = client.GetDatabase ("testdb");
			var collection = database.GetCollection<Person> ("people");

			//await collection.InsertOneAsync (new People{ name = "Jack", email = "jac@test.com", age = "30" });
			var list = await collection.Find (x => x.name == "Jack").ToListAsync ();


			foreach (var item in list) {
				var format = string.Format ("output => Name:{0}", item.name);
				System.Diagnostics.Debug.WriteLine (format);
			}

//			var item = collection.Find (new BsonDocument ("age", "18"));
//
//			System.Diagnostics.Debug.WriteLine ("Output:{0}", item.ToString ());

//			foreach (var item in list) {
//				System.Diagnostics.Debug.WriteLine (item.ToString());
//			}
		}

		public async Task<Person> FindById (ObjectId id)
		{
			var client = new MongoClient ("mongodb://localhost");
			var database = client.GetDatabase ("testdb");
			var collection = database.GetCollection<Person> ("people");

			var result = await collection.Find (x => x.Id == id).FirstOrDefaultAsync ();

			return result;
		}

	}
}

