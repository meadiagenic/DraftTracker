namespace DraftTracker.Data.Models
{
	using System.Collections.Generic;

	public class League
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<Team> Teams { get; set; }
		public PassingRules PassingRules { get; set; }
		public RushingRules RushingRules { get; set; }
		public ReceivingRules ReceivingRules { get; set; }
		public KickingRules KickingRules { get; set; }
		public DefensiveRules DefensiveRules { get; set; }

	}
}
