namespace DraftTracker.Web.Controllers
{
	using System.Web.Mvc;
	using DraftTracker.Data;
	using DraftTracker.Data.Models;

	public class LeagueController : Controller
	{

		public ILeagueRepository Leagues { get; private set; }
		public LeagueController(ILeagueRepository leagues)
		{
			Leagues = leagues;
		}

		public ActionResult Index()
		{
			return View(Leagues.GetAllLeagues());
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(League league)
		{
			Leagues.SaveLeague(league);
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var league = Leagues.GetLeagueById(id);
			return View(league);
		}

		[HttpPost]
		public ActionResult Edit(int id, League league)
		{
			Leagues.SaveLeague(league);
			return RedirectToAction("Index", "Home");
		}
	}
}
