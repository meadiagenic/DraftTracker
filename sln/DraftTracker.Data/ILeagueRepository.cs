namespace DraftTracker.Data
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using DraftTracker.Data.Models;

	public interface ILeagueRepository
	{
		IEnumerable<League> GetAllLeagues();
		League GetLeagueById(int id);
		void SaveLeague(League league);
		void AddTeam(League league, Team team);
	}
}
