using System;
using System.Collections.Generic;
using System.Linq;

using tennisscoring.scoring;

namespace tennisscoring.client.mapping
{
	class Formatierer
	{
		public void Spielstand_formatieren(string spielstand)
		{
			Result(new[]{string.Format("  {0}", spielstand)});
		}
		
		public void Spielgewinn_formatieren(Tuple<int,int> spielgewinneImSet)
		{
			Result(new[]{"", string.Format("  Set: {0}-{1}", spielgewinneImSet.Item1, spielgewinneImSet.Item2)});
		}
		
		public void Setgewinn_formatieren(Tuple<int,int> setgewinneImMatch)
		{
			Result(new[]{"", string.Format("  Match: {0}-{1}", setgewinneImMatch.Item1, setgewinneImMatch.Item2)});
		}
		
		public void Spielliste_formatieren(IEnumerable<object> rawEvents)
		{
			var output = new List<string>();
			output.Add("");
			
			int setNr = 1;
			int spielNr = 1;
			var header = string.Format("Set {0} - Spiel {1}", setNr, spielNr);
			
			foreach(var e in rawEvents.Cast<string>())
			{
					 if (e.StartsWith("Spielgewinn:"))
				{
					spielNr++;
					header = string.Format("Set {0} - Spiel {1}", setNr, spielNr);
				}
				else if (e.StartsWith("Setgewinn:"))
				{
					setNr++;
					spielNr = 1;
					header = string.Format("Set {0} - Spiel {1}", setNr, spielNr);
				}
				else if (e.StartsWith("Matchgewinn:")) {}
				else
				{
					if (header != null)
					{
						output.Add(header);
						output.Add("".PadLeft(header.Length, '-'));
						header = null;
					}
					output.Add(string.Format("  {0}", e));
				}
			}
			
			output.Add("");
			
			Result(output.ToArray());
		}
		
		public event Action<IEnumerable<string>> Result;
	}
}

