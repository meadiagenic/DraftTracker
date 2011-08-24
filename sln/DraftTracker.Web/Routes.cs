namespace DraftTracker.Web
{
	using System.Web.Mvc;
	using System.Web.Routing;
	using MvcTurbine.Routing;

	public class Routes : IRouteRegistrator
	{
		public void Register(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"DefaultWithFormat",
				"{controller}/{action}/{id}.{format}",
				new { controller = "Home", action = "Index", id = UrlParameter.Optional, format = UrlParameter.Optional },
				new { format = "(json|xml)?" }
				);

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional, format = "" }
				);
		}
	}
}
