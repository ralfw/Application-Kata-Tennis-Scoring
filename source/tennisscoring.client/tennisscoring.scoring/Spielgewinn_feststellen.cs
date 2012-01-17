using System;
using System.Collections.Generic;

namespace tennisscoring.scoring
{
	public class Spielgewinn_feststellen
	{
		public void Process(string spielstand)
		{
			if (spielstand.IndexOf("Winner:") >= 0)
				Result("Spielgewinn:0");
			else if (spielstand.IndexOf(":Winner") >= 0)
				Result("Spielgewinn:1");
		}
		
		public event Action<string> Result;
	}
}

