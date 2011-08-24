namespace DraftTracker.Web.Controllers
{
	using System.Web.Mvc;
	using System.Linq;
	using DraftTracker.Data;

	public class PlayersController : Controller
	{
		public PlayersController(IPlayerRepository players)
		{
			Players = players;
		}

		public IPlayerRepository Players { get; private set; }


		//
		// GET: /Player/

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Position(string id)
		{
			var players = Players.FindByPosition(id);
			if ((string)RouteData.Values["format"] == "json")
			{
				return Json(new { Players = players.ToArray() }, JsonRequestBehavior.AllowGet);
			} 
			ViewBag.PositionName = id;
			return View(players);
		} 

		//
		// GET: /Player/Details/5

		public ActionResult Details(int id)
		{
			return View();
		}

		//
		// GET: /Player/Create

		public ActionResult Create()
		{
			return View();
		} 

		//
		// POST: /Player/Create

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
		
		//
		// GET: /Player/Edit/5
 
		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /Player/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here
 
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Player/Delete/5
 
		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /Player/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here
 
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

	}
}
