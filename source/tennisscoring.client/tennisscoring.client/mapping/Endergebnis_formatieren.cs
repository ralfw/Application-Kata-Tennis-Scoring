using System;
using System.Collections.Generic;
using System.Linq;

namespace tennisscoring.client.mapping
{
	public class Endergebnis_formatieren
	{
		public void Process(IEnumerable<object> rawEvents)
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
				else
				{
					if (header != null)
					{
						output.Add("");
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

