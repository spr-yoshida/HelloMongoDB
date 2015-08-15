using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;

namespace XamarinMongoDB
{
	public interface IRepository
	{
		void Find();
		Task<List<Person>> FindAll();
		Task<Person> FindById (ObjectId id);
	}
}

