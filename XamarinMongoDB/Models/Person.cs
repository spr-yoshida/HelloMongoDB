using System;
using MongoDB.Bson;

namespace XamarinMongoDB
{
	public class Person
	{
		public Person ()
		{
		}

		public ObjectId Id {
			get;
			set;
		}
		public string name {
			get;
			set;
		}
		public string email {
			get;
			set;
		}
		public string age {
			get;
			set;
		}
	}
}

