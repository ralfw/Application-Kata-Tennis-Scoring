using System;
using System.Collections.Generic;
using System.Linq;

namespace tennisscoring.client.mapping
{
	public class Endergebnis_formatieren
	{
		public void Process(IEnumerable<object> rawEvents)
		{
			var events = rawEvents.Cast<string>();
			
			var output = new List<string>();
			output.Add("");
		
			var setgewinner = events.Where(e => e.StartsWith("Setgewinn:"))
								    .Select(e => int.Parse(e.Split(':')[1]))
								    .GroupBy(spielerIndex => spielerIndex)
								    .Select(spielerIndex => new {Spielerindex=spielerIndex.Key, 
															     Spielgewinne=spielerIndex.Count()});
			
			int[] setgewinne = new int[2];
			setgewinner.ToList().ForEach(sg => setgewinne[sg.Spielerindex] = sg.Spielgewinne);
			
			output.Add(string.Format("Winner: Player {0} with {1} : {2}",
			                         setgewinne[0]>setgewinne[1] ? "A" : "B",
			                         setgewinne[0],
			                         setgewinne[1]));
			
			// Die weitere Formatierung der Ausgabe spare ich mir.
			// Die Daten lassen sich leicht aus den Events herauslesen.
			
			output.Add("");
			
			Result(output.ToArray());
		}
		
		
		public event Action<IEnumerable<string>> Result;
	}
}

