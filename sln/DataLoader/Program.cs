using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using DraftTracker.Data;
using DraftTracker.Data.Models;
using DraftTracker.Data.SqlServer;

namespace DataLoader
{
	class Program
	{
		static IDictionary<string, Position> positionCache = new Dictionary<string, Position>();
		static IPlayerRepository Players { get; set; }
		static string[] WhiteListPositions = { "Def", "QB", "PK", "WR", "RB", "TE" };
		static void Main(string[] args)
		{
			var dbFactory = new DBFactory();
			Players = new SqlPlayerRepository(dbFactory);

			var url = string.Format("http://football.myfantasyleague.com/2011/export?TYPE=players");
			var result = Send(url, verb: "GET");
			//Console.WriteLine(result);
			dynamic d = ToDynamic(result);
			foreach (dynamic player in d.player)
			{
				if (WhiteListPositions.Contains((string)player.position, StringComparer.OrdinalIgnoreCase))
				{
					var names = ((string)player.name).Split(',');
					var p = new Player { FirstName = names[1], LastName = names[0], Team = player.team, MyFantasyLeagueId = player.id, Position = GetPositionByName(player.position) };
					Console.WriteLine("Saving {0}, {1}: {2} {3}", p.LastName, p.FirstName, p.Position, p.Team);
					Players.SavePlayer(p);
				}
				else
				{
					Console.WriteLine("Skipped {0}: {1}", player.position, player.name);
				}
			}

			Console.WriteLine("Done....");
			Console.ReadLine();
		}

		static Position GetPositionByName(string name)
		{
			Position p = null;
			if (!positionCache.TryGetValue(name, out p))
			{
				p = Players.FindPositionByName(name);
				positionCache.Add(name, p);
			}
			return p;
		}

		static XDocument ToXDoc(string xml)
		{
			byte[] byteArray = Encoding.UTF8.GetBytes(xml);
			XDocument doc;
			using (var stream = new MemoryStream(byteArray))
			{
				doc = XDocument.Load(stream);
			}
			return doc;
		}

		static dynamic ToDynamic(string xml)
		{
			return new DynamicXml(xml);
		}

		private static string Send(string url, string data = "", string verb = "POST")
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = verb;
			request.ContentType = "application/xml";

			if (!string.IsNullOrEmpty(data))
			{
				byte[] byteArray = Encoding.UTF8.GetBytes(data);
				request.ContentLength = byteArray.Length;
				using (var stream = request.GetRequestStream())
				{
					stream.Write(byteArray, 0, byteArray.Length);
				}
			}

			var response = (HttpWebResponse)request.GetResponse();
			string result = "";
			using (var stream = response.GetResponseStream())
			{
				var sr = new StreamReader(stream);
				result = sr.ReadToEnd();
				sr.Close();
			}
			return result;
		}

		
	}
}
