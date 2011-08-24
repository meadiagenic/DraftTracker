namespace DraftTracker.Web.Controllers
{
	using System.Web.Mvc;
	using DraftTracker.Data;

	public class HomeController : Controller
	{
		public HomeController(ILeagueRepository leagues)
		{
			Leagues = leagues;
		}
		//
		// GET: /Home/

		public ActionResult Index()
		{
			return View(Leagues.GetAllLeagues());
		}


		public ILeagueRepository Leagues { get; private set; }
	}
}
