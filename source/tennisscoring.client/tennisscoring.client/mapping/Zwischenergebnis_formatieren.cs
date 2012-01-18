using System;
using System.Collections.Generic;
using System.Linq;

using tennisscoring.scoring;

namespace tennisscoring.client.mapping
{
	class Zwischenergebnis_formatieren
	{
		public void Spielstand_formatieren(string spielstand)
		{
			Result(new[]{string.Format("  {0}", spielstand)});
		}
		
		public void Spielgewinn_formatieren(Tuple<int,int> spielgewinneImSet)
		{
			Result(new[]{"", string.Format("  Set: {0}-{1}", spielgewinneImSet.Item1, spielgewinneImSet.Item2), ""});
		}
		
		public void Setgewinn_formatieren(Tuple<int,int> setgewinneImMatch)
		{
			Result(new[]{string.Format("  Match: {0}-{1}", setgewinneImMatch.Item1, setgewinneImMatch.Item2), ""});
		}
		
		
		public event Action<IEnumerable<string>> Result;
	}
}

