using System;
using System.Collections.Generic;
using System.Linq;

namespace tennisscoring.client.view
{
	class Text_roh_ausgeben
	{
		public void Zwischenstand(IEnumerable<string> daten)
		{
			daten.ToList().ForEach(d => Console.WriteLine(d));
		}
		
		public void Endstand(IEnumerable<string> daten)
		{
			Zwischenstand(daten);
			Environment.Exit(0);
		}
	}
}

