namespace DraftTracker.Data.Models
{

	public class Player
	{
		public int Id { get; set; }
		public string MyFantasyLeagueId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public Position Position { get; set; }
		public string Team { get; set; }
	}
}
