namespace DraftTracker.Web
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using MvcTurbine.ComponentModel;
	using DraftTracker.Data;
	using DraftTracker.Data.SqlServer;

	public class ServiceRegistrations : IServiceRegistration
	{
		public void Register(IServiceLocator locator)
		{
			locator.Register<IDBFactory, DBFactory>();
			locator.Register<IPlayerRepository, SqlPlayerRepository>();
			locator.Register<ILeagueRepository, SqlLeagueRepository>();
		}
	}
}
