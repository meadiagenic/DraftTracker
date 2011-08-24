namespace DraftTracker.Data.SqlServer
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Configuration;
	using Simple.Data;

	public class DBFactory : IDBFactory
	{
		public static string DBConnectionName { get; set; }
		static DBFactory()
		{
			DBConnectionName = "DraftTracker";
		}

		public dynamic DB()
		{

			var s = ConfigurationManager.ConnectionStrings[DBConnectionName];
			if (!string.IsNullOrWhiteSpace(s.ConnectionString))
			{
				return Database.OpenConnection(s.ConnectionString);
			}
			
			throw new InvalidOperationException("Database not configured.");
			
		}
	}
}
