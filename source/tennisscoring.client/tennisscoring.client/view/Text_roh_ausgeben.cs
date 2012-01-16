using System;
using System.Collections.Generic;
using System.Linq;

namespace tennisscoring.client.view
{
	class Text_roh_ausgeben
	{
		public void Process(IEnumerable<string> daten)
		{
			daten.ToList().ForEach(d => Console.WriteLine(d));
		}
	}
}

