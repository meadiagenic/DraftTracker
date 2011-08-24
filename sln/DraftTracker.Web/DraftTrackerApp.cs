namespace DraftTracker.Web
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using MvcTurbine.Web;
	using MvcTurbine.ComponentModel;
	using MvcTurbine.Ninject;

	public class DraftTrackerApp : TurbineApplication
	{
		static DraftTrackerApp()
		{
			ServiceLocatorManager.SetLocatorProvider(() => new NinjectServiceLocator());
		}
	}
}
