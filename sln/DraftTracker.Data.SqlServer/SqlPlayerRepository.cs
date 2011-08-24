namespace DraftTracker.Data.SqlServer
{
	using System.Collections.Generic;
	using DraftTracker.Data.Models;

	public class SqlPlayerRepository : IPlayerRepository
	{
		protected dynamic DB;
		public SqlPlayerRepository(IDBFactory dbFactory)
		{
			DB = dbFactory.DB();
		}

		public IEnumerable<Player> GetAllPlayers()
		{
			return DB.Players.FindAll().Cast<Player>();
		}


		public Player SavePlayer(Player p)
		{
			var player = DB.Players.FindByMyFantasyId(p.MyFantasyLeagueId);
			if (player == null)
			{
				player = DB.Players.Insert(LastName: p.LastName, FirstName: p.FirstName, Team: p.Team, MyFantasyId: p.MyFantasyLeagueId, PositionId: p.Position.Id);
			}
			return player;
		}


		public Position FindPositionByName(string positionName)
		{
			var position = DB.Positions.FindByName(positionName);
			if (position == null)
			{
				position = DB.Positions.Insert(Name: positionName);
			}
			return position;
		}


		public IEnumerable<Player> FindByPosition(string positionName)
		{
			//var position = FindPositionByName(positionName);

			//var players = DB.Players.Query().FindAll(DB.Players.Position.Name == positionName);

			var players = DB.Positions.FindByName(positionName).Players;
			var playerList = new List<Player>();
			foreach (var player in players)
			{
				var p = (Player)player;
				p.Position = player.Position;
				playerList.Add(p);
			}
			return playerList;
			
		}
	}
}
