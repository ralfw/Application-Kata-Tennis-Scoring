using System;

namespace tennisscoring.client
{
	class Text_roh_ausgeben
	{
		public void Process(IEnumerable<string> daten)
		{
			daten.ToList().ForEach(d => Console.WriteLine(d));
		}
	}
}

