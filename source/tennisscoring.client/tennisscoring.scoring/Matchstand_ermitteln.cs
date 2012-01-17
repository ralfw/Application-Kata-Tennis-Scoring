using System;
using System.Collections.Generic;
using System.Linq;

namespace tennisscoring.scoring
{
	public class Matchstand
	{
		public int Matchgewinner;
	}
	
	
	public class Matchstand_ermitteln
	{
		public void Process(IEnumerable<object> events)
		{
			var matchstand = new Matchstand{Matchgewinner=-1};
			
			var lastEvent = (string)events.Last();
			if (lastEvent.StartsWith("Matchgewinner:"))
			{
				matchstand.Matchgewinner = int.Parse(lastEvent.Split(':')[1]);
			}
			Result(matchstand);
		}
		
		public event Action<Matchstand> Result;
	}
}

