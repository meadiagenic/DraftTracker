namespace DraftTracker.Data.SqlServer
{
	using System;
	using System.Collections.Generic;
	using DraftTracker.Data.Models;

	public class SqlLeagueRepository : ILeagueRepository
	{
		public dynamic DB { get; private set; }
		public SqlLeagueRepository(IDBFactory factory)
		{
			DB = factory.DB();
		}
		public IEnumerable<Models.League> GetAllLeagues()
		{
			return DB.Leagues.All().ToList<League>();
		}

		public void SaveLeague(Models.League league)
		{
			if (league.Id <= 0)
			{
				DB.Leagues.Insert(league);
			}
		}


		public void AddTeam(League league, Team team)
		{
			DB.Teams.Insert(Name: team.Name, LeagueId: league.Id);
		}


		public League GetLeagueById(int id)
		{
			League league = null;
			var l = DB.Leagues.FindById(id);
			league = (League)l;
			league.Teams = l.Teams.ToList<Team>();

			var lr = DB.LeagueRules.FindById(id);
			league.PassingRules = (PassingRules)lr;
			league.RushingRules = (RushingRules)lr;
			league.ReceivingRules = (ReceivingRules)lr;
			league.KickingRules = (KickingRules)lr;
			league.DefensiveRules = (DefensiveRules)lr;
			return league;
		}
	}
}
