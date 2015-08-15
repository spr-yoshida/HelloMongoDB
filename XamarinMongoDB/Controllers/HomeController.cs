using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MongoDB.Bson;

namespace XamarinMongoDB.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRepository _repository;
		public HomeController(){
			_repository = new MongoRepository ();
		}


		public ActionResult Index ()
		{
			var mvcName = typeof(Controller).Assembly.GetName ();
			var isMono = Type.GetType ("Mono.Runtime") != null;

			ViewData ["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData ["Runtime"] = isMono ? "Mono" : ".NET";


			var t = _repository.FindAll ();
			var x = t.Result;

			foreach (var item in x) 
			{
				Console.WriteLine (item.name);
			}
			var model = new HomeIndexViewModel ();
			model.People = t.Result;
			return View (model);
		}
			
		[HttpGet]
		public ActionResult Detail()
		{
			var id = Request["id"];
			var objectId = ObjectId.Parse (id);
			var data = _repository.FindById (objectId).Result;
			var model = new HomeDetailViewModel (){
				Name=data.name,
				Email=data.email,
				Age=data.age
			};

			return View (model);
		}
			
	}
}

