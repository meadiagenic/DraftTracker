namespace DraftTracker.Data
{
	using System.Collections.Generic;
	using DraftTracker.Data.Models;

	public interface IPlayerRepository
	{
		IEnumerable<Player> GetAllPlayers();
		Player SavePlayer(Player p);
		IEnumerable<Player> FindByPosition(string positionName);
		
		Position FindPositionByName(string positionName);
	}
}
